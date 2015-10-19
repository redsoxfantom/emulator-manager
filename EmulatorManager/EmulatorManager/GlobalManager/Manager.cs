using EmulatorManager.Events;
using EmulatorManager.GlobalManager.DataContracts;
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

        public Manager()
        {
            loadedConfig = new EmulatorManagerConfig();
        }

        public void Initialize()
        {
            onLoadedConfigChanged();
        }

        private void onLoadedConfigChanged()
        {
            LoadedConfigChangedArgs args = new LoadedConfigChangedArgs();
            args.ConfigFileName = loadedConfig.GetFileName();
        }
    }
}
