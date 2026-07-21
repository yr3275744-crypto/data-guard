// TODO: add validations on the raw table (lest 2 colmens..), 

using data_guard.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class ModelExtractor
{
    public List<Dictionary<string, string>> RawTable { get; private set; }

    public string[]? Keys { get; private set; }
    public List<string> Labels { get; private set; }
    public Dictionary<string, double> Priors { get; private set; }
    public Dictionary<(string, string, double), double> Cond { get; private set; }
    public Dictionary<(string, string), double> Unseen { get; private set; }

    public ModelExtractor()
    {
        RawTable = new();
        Labels = new();
        Priors = new();
        Cond = new();
        Unseen = new();
    }
    public Model GetModel(List<Dictionary<string, string>> rawTable, string[] keys)
    {
        if (keys.Length == 0)
        {
            throw new UnClassificationTable("Not enough columns");
        }
        if (rawTable.Count == 0)
        {
            throw new UnClassificationTable("Not enough rows");
        }
        RawTable = rawTable;
        Keys = keys;
        //Labels = GetLabels();
        //Priors = GetPriors();
    }
    private void DefineLabels()
    {
        //int rowsNumber = RawTable.Count;
        Labels = RawTable.GroupBy(row => row[Keys[Keys.Length - 1]])
            .Select(grop => grop.Key)
            .ToList();
    }
    private void definePriors()
    {
        foreach (string label in Labels)
        {
            Priors[label] = RawTable.Count(row => row[Keys[Keys.Length - 1]] == label) / (double)RawTable.Count();
        }
    }
    private void DefineCond()
    {

    }
}
