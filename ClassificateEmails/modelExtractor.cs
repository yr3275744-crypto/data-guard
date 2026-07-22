// TODO: add validations on the raw table (lest 2 colmens..), 

using data_guard.Exceptions;
using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class ModelExtractor : IModelExtractor
{
    public List<Dictionary<string, string>> RawTable { get; private set; }
    public string[]? Features { get; private set; }

    public string TargetColumnKey { get; private set; }
    public List<string> Labels { get; private set; }
    public Dictionary<string, double> Priors { get; private set; }
    public Dictionary<(string, string, string), double> Cond { get; private set; }
    public Dictionary<(string, string), double> Unseen { get; private set; }

    public ModelExtractor()
    {
        RawTable = new();
        TargetColumnKey = "";
        Labels = new();
        Priors = new();
        Cond = new();
        Unseen = new();
    }
    public Model GetModel(List<Dictionary<string, string>> rawTable)
    {
        if (rawTable.Count == 0)
        {
            throw new UnClassificationTable("Not enough rows");
        }

        RawTable = rawTable;
        DefineFeatuersAndTarget();
        DefineLabels();
        DefinePriors();
        DefineCondAndUnseen();
        return new Model(Labels, Priors, Cond, Unseen);

    }
    private void DefineFeatuersAndTarget()
    {
        Features = RawTable[0].Keys.ToArray();
        if (Features.Length < 2)
        {
            throw new UnClassificationTable("Not enough columns");
        }
        TargetColumnKey = Features[Features.Length - 1];
    }
    private void DefineLabels()
    {
        Labels = RawTable.GroupBy(row => row[TargetColumnKey])
            .Select(grop => grop.Key)
            .ToList();
    }
    private void DefinePriors()
    {
        foreach (string label in Labels)
        {
            Priors[label] = RawTable.Count(row => row[TargetColumnKey] == label) / (double)RawTable.Count();
        }
    }
    private void DefineCondAndUnseen()
    {
        foreach (string label in Labels)
        {
            foreach (string feature in Features[..(Features.Length - 1)])
            {
                List<string> values = RawTable
                    .GroupBy(row => row[feature])
                    .Select(g => g.Key)
                    .ToList();
                int labelCount = RawTable.Count(row => row[TargetColumnKey] == label);
                Unseen[(label, feature)] = 1.0 / (labelCount + values.Count);
                foreach (string value in values)
                {
                    int count = RawTable
                        .Where(row => row[TargetColumnKey] == label)
                        .Count(row => row[feature] == value);
                    if (count != 0)
                    {
                        Cond[(label, feature, value)] = (double)(count + 1) / (labelCount + values.Count);
                    }
                }
            }
        }
    }
}
