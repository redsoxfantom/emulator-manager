using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent.RomReaders
{
    public class N64RomReader : IRomReader
    {
        public bool TryReadRom(FileStream rom, out string RomId, out string RomType)
        {
            // .N64 file header
            // 0x20-0x33 - Game Name
            // 0x34-0x38 - Null

            RomId = null;
            RomType = null;

            byte[] magicNumberArry = new byte[8];
            rom.Position = 0x34;
            rom.Read(magicNumberArry, 0, 5);
            long magicNumber = BitConverter.ToInt64(magicNumberArry, 0);
            if(magicNumber != 0)
            {
                return false;
            }

            RomType = "Nintendo 64";
            byte[] romIdArray = new byte[20];
            rom.Position = 0x20;
            rom.Read(romIdArray, 0, 20);
            RomId = Encoding.ASCII.GetString(romIdArray).TrimEnd('\0');

            return true;
        }
    }
}
