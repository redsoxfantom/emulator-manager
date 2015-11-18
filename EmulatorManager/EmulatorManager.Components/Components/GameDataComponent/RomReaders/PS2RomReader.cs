using DiscUtils.Iso9660;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent.RomReaders
{
    public class PS2RomReader : IRomReader
    {
        public bool TryReadRom(FileStream rom, out string RomId, out string RomType)
        {
            RomId = null;
            RomType = null;

            byte[] magicNumberArray = new byte[11];
            rom.Position = 65881;
            rom.Read(magicNumberArray, 0, 11);
            String magicNumberString = Encoding.ASCII.GetString(magicNumberArray);
            rom.Position = 0;

            if(magicNumberString == "PLAYSTATION")
            {
                // PS2 games use a standard .iso image. One of the filenames is the id (also known as the SLUS file if you're running a US game)
                // Use DiskUtils to find it
                CDReader reader = new CDReader(rom, true);
                var id = reader.Root.GetFiles()
                    .Select(file=>file.FullName) // first, get the full name of all files in the root directory
                    .Where(name => { return (name.Split('_', '.').Length == 3); }); // next, get the one filename which is made up of an underscore and a period
                                                                                    // this is because all S-id files take the form <4characters>_<number>.<number>

                RomId = id.First();
                RomType = "Playstation 2";
                return true;
            }

            return false;
        }
    }
}
