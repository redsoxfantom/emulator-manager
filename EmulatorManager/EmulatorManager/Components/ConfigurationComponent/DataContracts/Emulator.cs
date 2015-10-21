using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ConfigurationManager.DataContracts
{
    public class Emulator
    {
        public int Id;

        public string Path;
        
        public string Name;
        
        public string Arguments;

        public override string ToString()
        {
            return String.Format("Id: {0}; Name: {1}; Executable: {2}; Arguments: {3}",Id,Name,Path,Arguments);
        }
    }
}
