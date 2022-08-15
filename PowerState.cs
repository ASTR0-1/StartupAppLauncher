using StartupAppLauncher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StartupAppLauncher
{
    [StructLayout(LayoutKind.Sequential)]
    public class PowerState
    {
        public ACLineStatus ACLineStatus;
        public BatteryFlag BatteryFlag;
        
        private PowerState() { }

        public static PowerState GetPowerState()
        {
            PowerState state = new PowerState();
            if (GetSystemPowerStatusRef(state))
                return state;

            throw new ApplicationException("Unable to get power state");
        }

        [DllImport("Kernel32", EntryPoint = "GetSystemPowerStatus")]
        private static extern bool GetSystemPowerStatusRef(PowerState sps);
    }
}
