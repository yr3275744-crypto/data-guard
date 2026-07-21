using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.ClassificateEmails;

class Model
{
    // ליצור את השדות האלו:
    //(string[], Dictionary<string, int>, Dictionary<(string, string), int>, Dictionary<(string, string, int), int>)
    public List<string> Labels { get; private set; }
    public Dictionary<string, double> Priors { get; private set; }
    public Dictionary<(string, string, string), double> Cond { get; private set; }
    public Dictionary<(string, string), double> Unseen { get; private set; }
    public Model(List<string> labels,
        Dictionary<string, double> priors,
        Dictionary<(string, string, string), double> cond,
        Dictionary<(string, string), double> unseen)
    {
        Labels = labels;
        Priors = priors;
        Cond = cond;
        Unseen = unseen;
    }
}
