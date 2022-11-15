using System.Collections.Generic;
using System.Diagnostics;
using StartupAppLauncher.Enums;

namespace StartupAppLauncher
{
    class Program
    {
        static void Main()
        {
            string txtPath = "Paths.txt";

            List<string> executePaths;

            PowerState powerState = PowerState.GetPowerState();
            var status = powerState.ACLineStatus;

            // If is on battery or uknown state => exit program
            if (status == ACLineStatus.Offline || status == ACLineStatus.Unknown)
                return;

            // Else if battery is on charge => read paths and execute them
            executePaths = PathsReader.ReadTxt(txtPath);

            foreach (string executePath in executePaths)
                Process.Start(executePath);
        }
    }
}
