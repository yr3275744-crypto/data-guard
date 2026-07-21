using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Exceptions;

class FileIsEmptyException : Exception
{
    FileIsEmptyException(string mesege) : base(mesege) { }
}

