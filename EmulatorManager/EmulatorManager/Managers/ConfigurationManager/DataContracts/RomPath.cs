using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Managers.ConfigurationManager.DataContracts
{
    public class RomPath
    {
        public string FolderPath;
        
        public string AssociatedEmulator;

        public override string ToString()
        {
            return String.Format("Path: {0}; Associated Emulator: {1}", FolderPath, AssociatedEmulator);
        }
    }
}
