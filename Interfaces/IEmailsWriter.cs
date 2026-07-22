using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Interfaces;

interface IEmailsWriter
{
    public void Write(string target, List<string> emails);
}