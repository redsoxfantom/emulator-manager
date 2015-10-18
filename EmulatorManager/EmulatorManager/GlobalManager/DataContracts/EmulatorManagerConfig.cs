using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager.DataContracts
{
    public class EmulatorManagerConfig
    {
        public string FileName;
        
        public List<Emulator> Emulators;
        
        public List<RomPath> Paths;
    }
}
