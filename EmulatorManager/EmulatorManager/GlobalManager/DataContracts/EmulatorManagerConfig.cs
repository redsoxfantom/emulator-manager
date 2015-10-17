using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager.DataContracts
{
    [DataContract(Name ="Config")]
    public class EmulatorManagerConfig
    {
        public string FileName;

        [DataMember(Name = "Emulators", Order = 0)]
        public List<Emulator> Emulators;

        [DataMember(Name ="Paths",Order =1)]
        public List<RomPath> Paths;
    }
}
