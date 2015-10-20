using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Managers.ExecutionManager
{
    public class EmulatorExecutionManager
    {
        public EmulatorExecutionManager()
        {

        }

        public void ExecuteProcess(String Path, String Args)
        {
            System.Diagnostics.Process.Start(Path, Args);
        }
    }
}
