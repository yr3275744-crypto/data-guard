using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Interfaces;

interface IEmailsReader
{
    public List<string> Read(string sorce);

}

