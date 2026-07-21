using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Interfaces;

interface IEmailInputFileReader
{
	public List<Dictionary<string, string>> Read(string sorce, string[] featureArr);

}
