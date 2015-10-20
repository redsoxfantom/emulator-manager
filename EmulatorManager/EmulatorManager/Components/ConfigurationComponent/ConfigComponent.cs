using EmulatorManager.Events;
using EmulatorManager.Components.ConfigurationManager.DataContracts;
using EmulatorManager.Utilities;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ConfigurationManager
{
    public class ConfigComponent
    {
        private EmulatorManagerConfig loadedConfig;

        /// <summary>
        /// Fired when the loaded configuration changes in some way
        /// </summary>
        public event LoadedConfigChanged ConfigutationChanged;

        private ILog mLogger;

        public ConfigComponent()
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

        public void AddRomPath(string Path, string AssociatedEmulator)
        {
            RomPath newPath = new RomPath();
            newPath.FolderPath = Path;
            newPath.AssociatedEmulator = AssociatedEmulator;
            mLogger.Info(String.Format("Adding new rom path {0}", newPath.ToString()));

            loadedConfig.Paths.Add(newPath);

            onLoadedConfigChanged();
        }

        public void SaveConfig(String path)
        {
            mLogger.Info(String.Format("Saving loaded config to {0}", path));

            try
            {
                FileManager.SaveObject(loadedConfig, path);
                String fileName = Path.GetFileName(path);
                loadedConfig.SetFileName(fileName);

                onLoadedConfigChanged();
                mLogger.Info("Successfully loaded configuration");
            }
            catch(Exception ex)
            {
                mLogger.Error(String.Format("Failed to save config to {0}", path), ex);
            }
        }

        public void LoadConfig(String path)
        {
            mLogger.Info(String.Format("Loading config from {0}", path));
            try
            {
                loadedConfig = FileManager.LoadObject<EmulatorManagerConfig>(path);
                string fileName = Path.GetFileName(path);
                loadedConfig.SetFileName(fileName);

                onLoadedConfigChanged();
                mLogger.Info("Successfully loaded configuration");
            }
            catch (Exception ex)
            {
                mLogger.Error(String.Format("Failed to load config from {0}", path), ex);
            }
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
