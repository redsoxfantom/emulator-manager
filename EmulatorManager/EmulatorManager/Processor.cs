using EmulatorManager.Components.ConfigurationManager;
using EmulatorManager.Views;
using log4net;
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

        public void Init(string[] args)
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            mLogger.Info(string.Format("Initializing Emulator Manager processor with args: [{0}]",string.Join(",",args)));
            ParseArgs(args);

            if (configPath == null)
            {
                ConfigComponent.Instance.Initialize();
            }
            else
            {
                ConfigComponent.Instance.Initialize(configPath);
            }

            mLogger.Info("Done Initializing Emulator Manager processor");
        }

        public bool Execute()
        {
            using(MainWindow mMainForm = new MainWindow())
            {
                mLogger.Info("Showing main display");
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
            }
        }
    }
}
