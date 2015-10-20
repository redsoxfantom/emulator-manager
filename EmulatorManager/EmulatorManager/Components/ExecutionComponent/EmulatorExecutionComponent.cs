using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ExecutionComponent
{
    public class EmulatorExecutionComponent
    {
        private ILog mLogger;

        public EmulatorExecutionComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);

        }

        public void ExecuteProcess(Command cmd)
        {
            if (!cmd.IsValidCommand)
            {
                mLogger.Error(String.Format("Command {0} is not valid", cmd.ToString()));
            }

            mLogger.Info(String.Format("Executing emulator {0} with arguments {1}",cmd.ExecutionPath,cmd.ExecutionArguments));
            using (Process emulator = new Process())
            {
                try
                {
                    emulator.StartInfo.FileName = cmd.ExecutionPath;
                    emulator.StartInfo.Arguments = cmd.ExecutionArguments;
                    emulator.StartInfo.UseShellExecute = false;
                    emulator.StartInfo.RedirectStandardOutput = true;
                    emulator.StartInfo.RedirectStandardError = true;
                    emulator.Start();

                    emulator.WaitForExit();

                    String stdOut = emulator.StandardOutput.ReadToEnd();
                    String stdErr = emulator.StandardError.ReadToEnd();
                    mLogger.Info(String.Format("Emulator exited. StdOut:\n{0}", stdOut));
                    if(!String.IsNullOrEmpty(stdErr))
                    {
                        mLogger.Error(String.Format("Emulator exited with errors. StdErr:\n{0}",stdErr));
                    }
                }
                catch(Exception ex)
                {
                    mLogger.Error("Failed to execute emulator process", ex);
                }
            }
        }

        public string CreateExecutionPath(String Path, String Args, String Replacements)
        {
            String retStringArgs = "";
            if(!String.IsNullOrEmpty(Args))
            {
                retStringArgs = String.Format(Args, Replacements);
            }

            return String.Format("{0} {1}", Path, retStringArgs);
        }
    }
}
