using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ExecutionComponent
{
    public class Command
    {
        public String ExecutionPath { get; private set; }

        public String ExecutionArguments { get; private set; }

        public Command(String executionPath, String executionArgs = "", String argReplacements = null)
        {
            if (!String.IsNullOrEmpty(executionArgs))
            {

            }
        }
    }
}
