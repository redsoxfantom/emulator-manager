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

        private Process mProc;

        public EmulatorExecutionComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            mProc = new Process();
        }

        public void ExecuteCommand(Command cmd)
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

        public bool TerminateCurrentProcess()
        {
            if(mProc.HasExited)
            {
                mLogger.Error("Cannot exit a process that has already ended");
                return false;
            }

            return true;
        }
    }
}
