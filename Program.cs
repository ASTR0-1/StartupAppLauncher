using StartupAppLauncher.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace StartupAppLauncher
{
    class Program
    {
        static void Main()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string txtPath = projectDirectory + @"\Paths.txt";

            List<string> executePaths;

            PowerState powerState = PowerState.GetPowerState();
            var status = powerState.ACLineStatus;

            // If is on battery or uknown state => exit program
            if (status == ACLineStatus.Offline || status == ACLineStatus.Unknown)
                return;

            // Else if battery is on charge => read paths and execute them
            executePaths = PathsReader.ReadTxt(txtPath);

            foreach(string executePath in executePaths)
                Process.Start(executePath);
        }
    }
}
