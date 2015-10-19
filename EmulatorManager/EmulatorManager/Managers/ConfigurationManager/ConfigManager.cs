using EmulatorManager.Events;
using EmulatorManager.Managers.ConfigurationManager.DataContracts;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Managers.ConfigurationManager
{
    public class ConfigManager
    {
        private EmulatorManagerConfig loadedConfig;

        /// <summary>
        /// Fired when the loaded configuration changes in some way
        /// </summary>
        public event LoadedConfigChanged ConfigutationChanged;

        private ILog mLogger;

        public ConfigManager()
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
            mLogger.Info(String.Format("Adding new emulator {0}", newEmu.ToString()));

            loadedConfig.Emulators.Add(newEmu);

            onLoadedConfigChanged();
        }

        private void onLoadedConfigChanged()
        {
            LoadedConfigChangedArgs args = new LoadedConfigChangedArgs(loadedConfig);

            if(ConfigutationChanged != null)
            {
                ConfigutationChanged(args);
            }
        }
    }
}
