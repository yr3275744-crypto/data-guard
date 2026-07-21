using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class ModelExtractor
{
    public List<Dictionary<string, string>> RawTable { get; private set; }

    public string[] Keys { get; private set; }
    public string[]? Labels { get; private set; }
    public Dictionary<string, int>? Priors { get; private set; }
    public Dictionary<(string, string, int), int>? Cond { get; private set; }
    public Dictionary<(string, string), int>? Unseen { get; private set; }

    public ModelExtractor(List<Dictionary<string, string>> rawTable, string[] keys)
    {
        RawTable = rawTable;
        Keys = keys;
        Labels = GetLabels();
    }
    private string[] GetLabels()
    {
        //int rowsNumber = RawTable.Count;
        string[] labels = RawTable.GroupBy(row => row[Keys[Keys.Length - 1]])
            .Select(grop => grop.Key)
            .ToArray();
        return labels;
    }
}
