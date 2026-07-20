using System;
using System.Collections.Generic;
using System.Text;
using data_guard.ClassificateEmails;
namespace data_guard.Interfaces;

interface IModelExtractor
{
    public Model CreateModel(List<string> rows);
}

