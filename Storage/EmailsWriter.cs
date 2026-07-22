using System;
using System.Collections.Generic;
using System.Text;
using data_guard.Interfaces;

namespace data_guard.Storage;

class EmailsWriter : IEmailsWriter
{
    public void Write(string target, List<string> emails)
    {
        string path = PathCreator.GetPath(target);
        File.WriteAllLines(path, emails);
    }
}

