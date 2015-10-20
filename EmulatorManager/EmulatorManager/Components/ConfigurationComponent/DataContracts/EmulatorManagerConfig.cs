using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ConfigurationManager.DataContracts
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

        public EmulatorManagerConfig()
        {
            mFileName = "<No Manager Config Loaded>";
            Emulators = new List<Emulator>();
            Paths = new List<RomPath>();
        }

        public override string ToString()
        {
            StringBuilder bldr = new StringBuilder("Emulator Manager Config\n");
            bldr.Append("Emulators:\n");
            foreach(Emulator em in Emulators)
            {
                bldr.Append(String.Format("\t{0}\n", em.ToString()));
            }
            bldr.Append("Rom Paths:\n");
            foreach (RomPath path in Paths)
            {
                bldr.Append(String.Format("\t{0}\n", path.ToString()));
            }

            return bldr.ToString();
        }
    }
}
