using System;
using System.Diagnostics;
using StartupAppLauncher;
using StartupAppLauncher.Enums;
using System.IO;

var pathsTxt = "Paths.txt";

var powerState = PowerState.GetPowerState();
var status = powerState.ACLineStatus;

// If is on battery or unknown state => exit program
if (status is ACLineStatus.Offline or ACLineStatus.Unknown)
    return;

var pathReader = new PathsReader();
// Else if battery is on charge => read paths and execute them
var executePaths = pathReader.ReadTxt(pathsTxt);

foreach (var executePath in executePaths)
{
    try
    {
        Process.Start(executePath);
    }
    catch (Exception ex)
    {
        var logPath = "error.log";
        var errorMessage = $"Error: {ex.Message} |\t While starting the process with path: {executePath}";
        File.AppendAllText(logPath, errorMessage + Environment.NewLine);
    }
}