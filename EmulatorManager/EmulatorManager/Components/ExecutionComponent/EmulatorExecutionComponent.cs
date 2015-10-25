using EmulatorManager.Events;
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

        public event ExecutionStateChanged ExecutionStateChangeHandler;

        public EmulatorExecutionComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
            mProc = new Process();
        }

        public void BeginEmulator(Command cmd)
        {
            if (!cmd.IsValidCommand)
            {
                mLogger.Error(String.Format("Command {0} is not valid", cmd.ToString()));
            }

            mLogger.Info(String.Format("Executing emulator {0} with arguments {1}",cmd.ExecutionPath,cmd.ExecutionArguments));
            
            mProc.StartInfo.FileName = cmd.ExecutionPath;
            mProc.StartInfo.Arguments = cmd.ExecutionArguments;
            mProc.StartInfo.UseShellExecute = false;
            mProc.StartInfo.RedirectStandardOutput = true;
            mProc.StartInfo.RedirectStandardError = true;

            Task.Factory.StartNew(()=> {

                try
                {
                    mProc.Start();
                    onExecutionStateChanged(ExecutionState.RUNNING);

                    mProc.WaitForExit();

                    mProc.Close();
                    String stdOut = mProc.StandardOutput.ReadToEnd();
                    String stdErr = mProc.StandardError.ReadToEnd();
                    mLogger.Info(String.Format("mProc exited. StdOut:\n{0}", stdOut));
                    if (!String.IsNullOrEmpty(stdErr))
                    {
                        mLogger.Error(String.Format("mProc exited with errors. StdErr:\n{0}", stdErr));
                    }
                    onExecutionStateChanged(ExecutionState.TERMINATED);
                }
                catch(Exception ex)
                {
                    mLogger.Error("Failed to start emulator", ex);
                }
                finally
                {
                    mProc.Close();
                }
            });
            
        }

        public bool EmulatorIsRunning()
        {
            try
            {
                return !mProc.HasExited;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void TerminateEmulator()
        {
            try
            {
                mProc.Kill();
                onExecutionStateChanged(ExecutionState.TERMINATED);
            }
            catch(Exception ex)
            {
                mLogger.Error("Cannot kill the emulator process: it's either already dead or never been started");
            }
        }

        private void onExecutionStateChanged(ExecutionState newState)
        {
            if(ExecutionStateChangeHandler != null)
            {
                ExecutionStateChangedEventArgs args = new ExecutionStateChangedEventArgs(newState);
                ExecutionStateChangeHandler(args);
            }
        }
    }
}
