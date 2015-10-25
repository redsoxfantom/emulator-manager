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
        private EmulatorManagerConfig mLoadedConfig;

        /// <summary>
        /// Fired when the loaded configuration changes in some way
        /// </summary>
        public event LoadedConfigChanged ConfigutationChanged;

        private ILog mLogger;

        public static ConfigComponent Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new ConfigComponent();
                }
                return mInstance;
            }
        }
        private static ConfigComponent mInstance = null;

        private ConfigComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public void Initialize()
        {
            mLogger.Info("Initializing Manager with no parameters");
            mLoadedConfig = new EmulatorManagerConfig();
            mLoadedConfig.Initialize();

            onLoadedConfigChanged();
        }

        public void Initialize(String configPath)
        {
            mLogger.Info(String.Format("Initializing config manager with path {0}", configPath));
            mLoadedConfig = new EmulatorManagerConfig();
            LoadConfig(configPath);
            onLoadedConfigChanged();
        }

        public void AddOrUpdateEmulator(string Name, string Path, string Args, int idx = -1)
        {
            Emulator newEmu = new Emulator();
            newEmu.Name = Name;
            newEmu.Path = Path;
            newEmu.Arguments = Args;
            mLogger.Info(String.Format("Adding new emulator {0}", newEmu.ToString()));

            mLoadedConfig.AddOrUpdateEmulator(newEmu, idx);

            onLoadedConfigChanged();
        }

        public void RemoveRomPath(int idx)
        {
            mLogger.Debug(String.Format("Deleting rompath {0}", idx));
            mLoadedConfig.RemovePath(idx);

            onLoadedConfigChanged();
        }

        public void RemoveEmulator(int idx)
        {
            mLogger.Debug(String.Format("Deleting emulator {0}", idx));
            mLoadedConfig.RemoveEmulator(idx);

            onLoadedConfigChanged();
        }

        public void AddRomPath(string Path, string AssociatedEmulator, string Extension)
        {
            RomPath newPath = new RomPath();
            newPath.FolderPath = Path;
            newPath.AssociatedEmulator = AssociatedEmulator;
            newPath.RomExtension = Extension;
            mLogger.Info(String.Format("Adding new rom path {0}", newPath.ToString()));

            mLoadedConfig.AddPath(newPath);

            onLoadedConfigChanged();
        }

        public void SaveConfig(String path)
        {
            mLogger.Info(String.Format("Saving loaded config to {0}", path));

            try
            {
                FileManager.SaveObject(mLoadedConfig, path);
                String fileName = Path.GetFileName(path);
                mLoadedConfig.SetFilePath(fileName);
                mLoadedConfig.ResetDirtyFlag();

                onLoadedConfigChanged();
                mLogger.Info("Successfully saved configuration");
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
                mLoadedConfig = FileManager.LoadObject<EmulatorManagerConfig>(path);
                mLoadedConfig.Initialize();
                string fileName = Path.GetFileName(path);
                mLoadedConfig.SetFilePath(fileName);

                onLoadedConfigChanged();
                mLogger.Info("Successfully loaded configuration");
            }
            catch (Exception ex)
            {
                mLogger.Error(String.Format("Failed to load config from {0}", path), ex);
            }
        }

        public void GetCurrentConfig(out String FileName, out IReadOnlyList<Emulator> LoadedEmulators, out IReadOnlyList<RomPath> LoadedPaths)
        {
            FileName = mLoadedConfig.GetFileName();
            LoadedEmulators = mLoadedConfig.GetLoadedEmulators();
            LoadedPaths = mLoadedConfig.GetLoadedRomPaths();
        }

        private void onLoadedConfigChanged()
        {
            LoadedConfigChangedArgs args = new LoadedConfigChangedArgs(mLoadedConfig);

            if(ConfigutationChanged != null)
            {
                ConfigutationChanged(args);
            }
        }
    }
}
