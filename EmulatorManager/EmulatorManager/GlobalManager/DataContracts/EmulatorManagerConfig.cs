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
        /// <summary>
        /// The filename this config was loaded from. Marked "private" to keep it from being serialized / deserialized
        /// </summary>
        private string mFileName;
        
        public List<Emulator> Emulators { get; set; }
        
        public List<RomPath> Paths { get; set; }

        public string GetFileName()
        {
            return mFileName;
        }

        public void SetFileName(string value)
        {
            mFileName = value;
        }
    }
}
