using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupAppLauncher
{
    public static class PathsReader
    {
        private static List<string> _paths = new();

        public static List<string> ReadTxt(string txtPath)
        {
            using StreamReader streamReader = new StreamReader(txtPath);

            // Skipping instructions
            for(int i = 0; i < 2; i++)
                streamReader.ReadLine();

            string line;
            while ((line = streamReader.ReadLine()) != null)
                _paths.Add(line);

            return _paths;
        }
    }
}
