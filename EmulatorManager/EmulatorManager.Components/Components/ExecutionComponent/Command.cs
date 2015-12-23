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

        public Boolean IsValidCommand { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="executionPath">Path to the emulator</param>
        /// <param name="executionArgs">Arguments to the emulator with replacement variables</param>
        /// <param name="argReplacements">String of the form "$VAR=val;$VAR2=val", will be inserted into execution args</param>
        public Command(String executionPath, String executionArgs = "", String argReplacements = null)
        {
            if (!String.IsNullOrEmpty(argReplacements))
            {
                ExecutionArguments = String.Format(executionArgs, argReplacements);
            }
            else
            {
                ExecutionArguments = executionArgs;
            }

            ExecutionPath = executionPath;
            IsValidCommand = true;
        }

        public Command()
        {
            ExecutionPath = "";
            ExecutionArguments = "";
            IsValidCommand = false;
        }

        public override String ToString()
        {
            return String.Format("{0} {1}",ExecutionPath,ExecutionArguments);
        }
    }
}
