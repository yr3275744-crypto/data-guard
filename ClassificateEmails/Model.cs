using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class Model
{
    // ליצור את השדות האלו:
    //(string[], Dictionary<string, int>, Dictionary<(string, string), int>, Dictionary<(string, string, int), int>)
    private List<Dictionary<string, string>> _rawTable;
    public string[] Labels { get; private set; }
    public Dictionary<string, double> Priors { get; private set; }
    public Dictionary<(string, string, double), int> Cond { get; private set; }
    public Dictionary<(string, string), double> Unseen { get; private set; }
    public Model(List<Dictionary<string, string>> rawTable)
    {
        _rawTable = rawTable;
    }
}
