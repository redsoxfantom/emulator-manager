using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.GlobalManager.DataContracts
{
    [DataContract(Name ="Emulator")]
    public class Emulator
    {
        [DataMember(Name ="Path",Order =0)]
        public string Path;

        [DataMember(Name ="Executable",Order =1)]
        public string Executable;

        [DataMember(Name ="Arguments",Order =2)]
        public string Arguments;
    }
}
