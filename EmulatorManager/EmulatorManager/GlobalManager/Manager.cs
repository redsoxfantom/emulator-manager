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

        public Manager()
        {
            loadedConfig = new EmulatorManagerConfig();
        }
    }
}
