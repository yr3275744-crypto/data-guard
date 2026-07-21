using System;
using System.Collections.Generic;
using System.Text;
using data_guard.ClassificateEmails;
namespace data_guard.Interfaces;

interface IModelExtractor
{
    public abstract Model GetModel(List<Dictionary<string, string>> rawTable);
}

