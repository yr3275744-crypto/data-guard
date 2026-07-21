using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.loggers;

class ConsoleLogger
{
    public void WriteLog(string message)
    {
        Console.WriteLine(message);
    }
}
