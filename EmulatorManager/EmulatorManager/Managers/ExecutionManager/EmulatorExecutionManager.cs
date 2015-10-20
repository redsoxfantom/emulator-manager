using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Managers.ExecutionManager
{
    public class EmulatorExecutionManager
    {
        private ILog mLogger;

        public EmulatorExecutionManager()
        {
            mLogger = LogManager.GetLogger(GetType().Name);

        }

        public void ExecuteProcess(String Path, String Args, String Replacements)
        {
            String finalArgs = "";
            if(!String.IsNullOrEmpty(Args))
            {
                finalArgs = String.Format(Args, Replacements);
            }

            mLogger.Info(String.Format("Executing emulator {0} with arguments {1}",Path,finalArgs));
            using (Process emulator = new Process())
            {
                try
                {
                    emulator.StartInfo.FileName = Path;
                    emulator.StartInfo.Arguments = finalArgs;
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
    }
}
