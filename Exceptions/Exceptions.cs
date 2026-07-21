using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Exceptions;


class FileIsEmptyException : Exception
{
    public FileIsEmptyException(string mesege) : base(mesege) { }
}
class UnClassificationTable : Exception
{
    public UnClassificationTable(string message) : base(message) { }

}

