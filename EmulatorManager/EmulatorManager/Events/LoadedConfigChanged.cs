using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Events
{
    public delegate void LoadedConfigChanged(LoadedConfigChangedArgs args);

    public class LoadedConfigChangedArgs : EventArgs
    {
        string ConfigFileName;
    }
}
