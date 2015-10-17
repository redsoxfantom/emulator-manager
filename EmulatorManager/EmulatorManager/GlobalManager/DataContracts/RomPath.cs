using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager.DataContracts
{
    [DataContract(Name ="RomPath")]
    public class RomPath
    {
        [DataMember(Name ="Path",Order =0)]
        public string FolderPath;

        [DataMember(Name ="AssociatedEmulator",Order =1)]
        public string AssociatedEmulator;
    }
}
