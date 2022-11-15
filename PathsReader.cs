using System.Collections.Generic;
using System.IO;

namespace StartupAppLauncher
{
    internal static class PathsReader
    {
        private static readonly List<string> _paths = new();

        public static List<string> ReadTxt(string txtPath)
        {
            using StreamReader streamReader = new(txtPath);

            // Skipping instructions
            for (int i = 0; i < 2; i++)
                streamReader.ReadLine();

            string line;
            while ((line = streamReader.ReadLine()) != null)
                _paths.Add(line);

            return _paths;
        }
    }
}
