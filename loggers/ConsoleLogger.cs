using System;
using System.Collections.Generic;
using System.Text;
using data_guard.Interfaces;

namespace data_guard.loggers;

class ConsoleLogger:ILogger
{
    public void WriteLog(string message)
    {
        Console.WriteLine(message);
    }
}
