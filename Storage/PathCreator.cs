using System;
using System.Collections.Generic;
using System.Text;

namespace data_guard.Storage;

class PathCreator
{
    public static string GetPath(string path)
    {
        string currentPath = Directory.GetCurrentDirectory();
        return Path.Combine(currentPath, path);
    }
}

