using data_guard.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using data_guard.Exceptions;

namespace data_guard.Storage;

class EmailsInputFileReader : IEmailInputFileReader
{
	public List<Dictionary<string, string>> Read(string sorce, string[] featureArr)
	{
		string path = PathCreator.GetPath(sorce);

		List<string> lines = File.ReadLines("file.txt").ToList();

		if (lines.Count == 0)
		{
			throw new FileIsEmptyException("no data to run algoritem on!");
		}
		if (lines[0].Split(',').Length <= 1)
		{
			throw new UnClassificationTable("not valid for algorithem");
		}
		List<Dictionary<string, string>> dataDictList = new List<Dictionary<string, string>>();

		foreach (string line in lines)
		{

			Dictionary<string, string> dataDict = new Dictionary<string, string>();

			string[] lineArr = line.Split(",");

			if (lineArr.Length != featureArr.Length)
			{
				throw new UnClassificationTable("data is not secure, mising or is overFlowed");
			}
			for (int i = 0; i < featureArr.Length; i++)
			{
				dataDict.Add(featureArr[i], lineArr[i]);
			}
			dataDictList.Add(dataDict);

		}
		return dataDictList;
	}
}
