using Newtonsoft.Json;
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

        private bool isDirty;

        private int currEmuId;

        private int currPathId;
        
        [JsonProperty]
        private List<Emulator> Emulators { get; set; }
        
        [JsonProperty]
        private List<RomPath> Paths { get; set; }

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

            currEmuId = 0;
            currPathId = 0;
        }

        public void Initialize()
        {
            // determine the current (highest + 1) emulator and path id
            // This is the next available id
            if (Emulators.Count > 0)
            {
                currEmuId = Emulators.Max(f => f.Id) + 1;
            }
            else
            {
                currEmuId = 0;
            }

            if (Paths.Count > 0)
            {
                currPathId = Paths.Max(f => f.Id) + 1;
            }
            else
            {
                currPathId = 0;
            }

            isDirty = false;
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

        public Emulator GetEmulatorById(int id)
        {
            int indexOfId = Emulators.FindIndex(f => f.Id == id);
            if(indexOfId != -1)
            {
                return Emulators[indexOfId];
            }
            return null;
        }

        public RomPath GetPathById(int id)
        {
            int indexOfId = Paths.FindIndex(f => f.Id == id);
            if(indexOfId != -1)
            {
                return Paths[indexOfId];
            }
            return null;
        }

        public void AddOrUpdateEmulator(Emulator emu, int idx = -1)
        {
            if (idx != -1)
            {
                Emulator emuToReplace = GetEmulatorById(idx);
                int deadEmulatorIndex = Emulators.IndexOf(emuToReplace);
                Emulators[deadEmulatorIndex] = emu;
            }
            else
            {
                emu.Id = currEmuId;
                currEmuId++;
                Emulators.Add(emu);
            }
        }

        public void AddPath(RomPath path)
        {
            path.Id = currPathId;
            currPathId++;
            Paths.Add(path);
        }

        public void RemovePath(int id)
        {
            RomPath pathToRemove = GetPathById(id);
            Paths.Remove(pathToRemove);
        }

        public void RemoveEmulator(int id)
        {
            Emulator emuToRemove = GetEmulatorById(id);
            Emulators.Remove(emuToRemove);

            var PathsToRemove = Paths.Where(f => f.AssociatedEmulator == emuToRemove.Name).ToList();
            foreach(RomPath path in PathsToRemove)
            {
                RemovePath(path.Id);
            }

        }

        public bool GetIsDirty()
        {
            return isDirty;
        }

        public IReadOnlyList<Emulator> GetLoadedEmulators()
        {
            return Emulators.ToList().AsReadOnly();
        }

        public IReadOnlyList<RomPath> GetLoadedRomPaths()
        {
            return Paths.ToList().AsReadOnly();
        }
    }
}
