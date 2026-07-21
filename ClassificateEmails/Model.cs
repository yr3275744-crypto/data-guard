using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class Model
{
    // ליצור את השדות האלו:
    //(string[], Dictionary<string, int>, Dictionary<(string, string), int>, Dictionary<(string, string, int), int>)
    public List<Dictionary<string, string>> RawTable { get; private set; }
    public string[] Labels { get; private set; }
    public Dictionary<string, int> Priors { get; private set; }
    public Dictionary<(string, string, int), int> Cond { get; private set; }
    public Dictionary<(string, string), int> Unseen { get; private set; }
    public Model(List<Dictionary<string, string>> rawTable)
    {
        RawTable = rawTable;
    }
}
