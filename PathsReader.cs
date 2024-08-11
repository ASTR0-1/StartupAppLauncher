using System.Collections.Generic;
using System.IO;

namespace StartupAppLauncher
{
    internal class PathsReader
    {
        private readonly List<string> Paths = new();

        public List<string> ReadTxt(string txtPath)
        {
            using StreamReader streamReader = new(txtPath);

            while (streamReader.ReadLine() is { } line)
                Paths.Add(line);

            return Paths;
        }
    }
}
