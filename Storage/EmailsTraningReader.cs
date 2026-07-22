using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using data_guard.Exceptions;

namespace data_guard.Storage;

class EmailsTraningReader : IEmailsTraningReader
{
    public List<Dictionary<string, string>> Read(string sorce)
    {
        string path = PathCreator.GetPath(sorce);

        List<string> lines = File.ReadLines(path).ToList();

        if (lines.Count == 0)
        {
            throw new FileIsEmptyException("no data to run algoritem on!");
        }
        if (lines[0].Split(',').Length <= 1)
        {
            throw new UnClassificationTable("not valid for algorithem");
        }
        List<Dictionary<string, string>> dataDictList = new List<Dictionary<string, string>>();

        List<string> featureList = lines[0].Split(",").ToList();
        lines.RemoveAt(0);

        foreach (string line in lines)
        {

            Dictionary<string, string> dataDict = new Dictionary<string, string>();

            string[] lineArr = line.Split(",");

            if (lineArr.Length != featureList.Count)
            {
                throw new UnClassificationTable("data is not secure, mising or is overFlowed");
            }
            for (int i = 0; i < featureList.Count; i++)
            {
                dataDict.Add(featureList[i], lineArr[i]);
            }
            dataDictList.Add(dataDict);

        }
        return dataDictList;
    }
}

