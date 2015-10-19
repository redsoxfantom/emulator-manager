using EmulatorManager.Events;
using EmulatorManager.GlobalManager.DataContracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager
{
    public class Manager
    {
        private EmulatorManagerConfig loadedConfig;

        /// <summary>
        /// Fired when the loaded configuration changes in some way
        /// </summary>
        public event LoadedConfigChanged ConfigutationChanged;

        private ILog mLogger;

        public Manager()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public void Initialize()
        {
            mLogger.Info("Initializing Manager with no parameters");
            loadedConfig = new EmulatorManagerConfig();
            onLoadedConfigChanged();
        }

        public void AddEmulator(string Name, string Path, string Args)
        {
            Emulator newEmu = new Emulator();
            newEmu.Name = Name;
            newEmu.Path = Path;
            newEmu.Arguments = Args;

            loadedConfig.Emulators.Add(newEmu);

            onLoadedConfigChanged();
        }

        private void onLoadedConfigChanged()
        {
            LoadedConfigChangedArgs args = new LoadedConfigChangedArgs();
            args.ConfigFileName = loadedConfig.GetFileName();

            if(ConfigutationChanged != null)
            {
                ConfigutationChanged(args);
            }
        }
    }
}
