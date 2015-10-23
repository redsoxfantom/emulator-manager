
using EmulatorManager.Components.ConfigurationManager.DataContracts;
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
        public String FileName { get; private set; }

        public IReadOnlyList<Emulator> LoadedEmulators { get; private set; }

        public IReadOnlyList<RomPath> LoadedPaths { get; private set; }

        public bool ConfigIsDirty { get; private set; }

        public LoadedConfigChangedArgs(EmulatorManagerConfig newConfig)
        {
            FileName = newConfig.GetFileName();
            LoadedEmulators = newConfig.GetLoadedEmulators();
            LoadedPaths = newConfig.GetLoadedRomPaths();
            ConfigIsDirty = newConfig.GetIsDirty();
        }
    }
}
