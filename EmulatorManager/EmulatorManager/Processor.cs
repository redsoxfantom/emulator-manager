using EmulatorManager.Components.ConfigurationManager;
using EmulatorManager.Components.GameDataComponent;
using EmulatorManager.Views;
using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ConfigComponent.Instance.Initialize();
            }
            else
            {
                ConfigComponent.Instance.Initialize(configPath);
            }

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

        public bool Execute()
        {
            using(MainWindow mMainForm = new MainWindow())
            {
                mLogger.Info("Showing main display");
                mMainForm.Initialize();
                mMainForm.ShowDialog();
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
