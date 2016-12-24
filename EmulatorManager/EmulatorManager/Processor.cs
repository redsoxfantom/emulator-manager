using EmulatorManager.Components.ConfigurationManager;
using EmulatorManager.Components.ConfigurationManager.DataContracts;
using EmulatorManager.Components.GameDataComponent;
using EmulatorManager.Utilities;
using EmulatorManager.Views;
using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager
{
    public class Processor
    {
        private ILog mLogger;

        private String configPath;

        private String serverUrl;

        public void Init(string[] args)
        {
            ParseArgs(args);
            mLogger = LogManager.GetLogger(GetType().Name);
            mLogger.Info(string.Format("Initializing Emulator Manager processor with args: [{0}]",string.Join(",",args)));

            if (configPath == null)
            {
                configPath = loadDefaultConfigPath();
            }
            ConfigComponent.Instance.Initialize(configPath);

            if (serverUrl == null)
            {
                RomDataComponent.Instance.Initialize();
            }
            else
            {
                RomDataComponent.Instance.Initialize(serverUrl);
            }

            mLogger.Info("Done Initializing Emulator Manager processor");
        }

        private string loadDefaultConfigPath()
        {
            String configPathRoot = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String fileName = System.IO.Path.Combine(configPathRoot, "emulators.mgr");
            if(!System.IO.File.Exists(fileName))
            {
                EmulatorManagerConfig cfg = new EmulatorManagerConfig();
                cfg.Initialize();
                FileManager.SaveObject(cfg, fileName);
            }

            return fileName;
        }

        public bool Execute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MainWindow mMainForm = new MainWindow())
            {
                mLogger.Info("Showing main display");
                mMainForm.Initialize();
                Application.Run(mMainForm);
                mLogger.Info("Bye");
            }
            return true;
        }

        private void ParseArgs(string[] args)
        {
            configPath = null;

            for(int i = 0; i < args.Length; i++)
            {
                if(args[i] == "-config")
                {
                    i++;
                    configPath = args[i];
                }
                if(args[i] == "-logLevel")
                {
                    i++;
                    ILoggerRepository logRepo = LogManager.GetRepository();
                    logRepo.Threshold = logRepo.LevelMap[args[i]];
                }
                if(args[i] == "-dataUrl")
                {
                    i++;
                    serverUrl = args[i];
                }
            }
        }
    }
}
