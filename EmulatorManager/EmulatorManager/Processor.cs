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

        public void Init(string[] args)
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            mLogger.Info(string.Format("Initializing Emulator Manager processor with args: [{0}]",string.Join(",",args)));
            ConfigComponent.Instance.Initialize();
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
    }
}
