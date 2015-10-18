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
        }

        public bool Execute()
        {
            mLogger.Info("Executing...");

            Console.ReadLine();

            return true;
        }
    }
}
