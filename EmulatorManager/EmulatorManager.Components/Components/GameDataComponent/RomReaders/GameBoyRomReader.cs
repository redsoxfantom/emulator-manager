using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent.RomReaders
{
    public class GameBoyRomReader : IRomReader
    {
        public bool TryReadRom(FileStream rom, out string RomId, out string RomType)
        {
            RomId = null;
            RomType = null;

            byte[] expectedNumberArray = new byte[64] 
            {
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                0xff,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };
            byte[] magicNumberArray = new byte[64];
            rom.Position = 0;
            rom.Read(magicNumberArray, 0, 64);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(magicNumberArray);
            }

            for(int i = 0; i < magicNumberArray.Length; i++)
            {
                if(magicNumberArray[i] != expectedNumberArray[i])
                {
                    return false;
                }
            }

            byte[] romIdArray = new byte[16];
            rom.Position = 307;
            rom.Read(romIdArray, 0, 16);
            RomId = Encoding.ASCII.GetString(romIdArray).TrimEnd('\0');
            RomType = "GameBoy";
        }
    }
}
