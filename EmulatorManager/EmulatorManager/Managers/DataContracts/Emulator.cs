using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Managers.DataContracts
{
    public class Emulator
    {
        public string Path;
        
        public string Name;
        
        public string Arguments;

        public override string ToString()
        {
            return String.Format("Name: {0}; Executable: {1}; Arguments: {2}",Name,Path,Arguments);
        }
    }
}
