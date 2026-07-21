using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using data_guard.Exceptions;

namespace data_guard.Storage;

class EmailsReader: IEmailsReader
{
    public List<string> Read(string sorce)
    {
        string path = PathCreator.GetPath(sorce);

        List<string> lines = File.ReadLines("file.txt").ToList();

        if (lines.Count == 0 )
        {
            throw new FileIsEmptyException("no data to run algoritem on!");
        }
        if (lines[0].Split(',').Length <= 1)
        {
            throw new UnClassificationTable("not valid for algorithem");
        }
    return lines;
    }
}

