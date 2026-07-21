using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace data_guard.Storage;

class EmailsReader: IEmailsReader
{
    public string FilePath { get; private set; }
    public EmailsReader(string filePath) { FilePath = filePath; }

        public List<string> Read()
        {
            string[] lines = File.ReadAllLines(FilePath);
            return lines.ToList();
        }
}

