using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ConfigurationManager.DataContracts
{
    public class RomPath
    {
        public int Id;

        public string FolderPath;
        
        public string AssociatedEmulator;

        public string RomExtension;

        public override string ToString()
        {
            return String.Format("Id: {0}; Path: {1}; Associated Emulator: {2}; Extension: {3}", Id, FolderPath, AssociatedEmulator,RomExtension);
        }
    }
}
