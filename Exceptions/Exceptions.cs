using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Exceptions;

class UnClassificationTable : Exception
{
    public UnClassificationTable(string message) : base(message) { }
}
