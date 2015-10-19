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

        private MainWindow mMainForm;

        public void Init(string[] args)
        {
            mLogger = LogManager.GetLogger(GetType().Name);

            mLogger.Info("Initializing Emulator Manager processor...");
            mMainForm = new MainWindow();
            mLogger.Info("Done Initializing Emulator Manager processor");
        }

        public bool Execute()
        {
            mLogger.Info("Showing main display");
            mMainForm.ShowDialog();

            mLogger.Info("Bye");
            return true;
        }
    }
}
