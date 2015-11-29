using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Events
{
    public delegate void ExecutionStateChanged(ExecutionStateChangedEventArgs args);

    public class ExecutionStateChangedEventArgs : EventArgs
    {
        public ExecutionState State { get; private set; }

        public TimeSpan PlayTime { get; private set; }

        public ExecutionStateChangedEventArgs(ExecutionState newState, TimeSpan playTime)
        {
            State = newState;
            PlayTime = playTime;
        }
    }

    public enum ExecutionState
    {
        RUNNING,
        TERMINATED
    }
}
