using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using data_guard.Exceptions;

namespace data_guard.Storage;

class EmailsInputReader : IEmailsInputReader
{
    ILogger Logger { get; set; }
    public EmailsInputReader(ILogger logger)
    {
        Logger = logger;
    }
    public List<Dictionary<string, string>> Read(string sorce, string[] featureArr)
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

        for (int i = 0; i < lines.Count; i++)
        {

            Dictionary<string, string> dataDict = new Dictionary<string, string>();

            string[] lineArr = lines[i].Split(",");

            if (lineArr.Length != featureArr.Length)
            {
                Logger.WriteLog($"Line {i}: data is not secure, mising or is overFlowed");
            }
            else
            {
                for (int j = 0; j < featureArr.Length; j++)
                {
                    dataDict.Add(featureArr[j], lineArr[j]);
                }
                dataDictList.Add(dataDict);
            }
        }
        return dataDictList;
    }
}
