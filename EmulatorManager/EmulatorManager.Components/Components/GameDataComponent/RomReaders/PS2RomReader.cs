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

                RomType = "Playstation 2";
                return true;
            }

            return false;
        }
    }
}
