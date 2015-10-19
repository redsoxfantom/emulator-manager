﻿using EmulatorManager.Events;
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
        }

        public void Initialize()
        {
            loadedConfig = new EmulatorManagerConfig();
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
