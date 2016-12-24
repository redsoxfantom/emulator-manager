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

            byte[] expectedNumberArray = new byte[48] 
            {
                0xCE, 0xED, 0x66, 0x66, 0xCC, 0x0D, 0x00, 0x0B, 0x03, 0x73, 0x00, 0x83, 0x00, 0x0C, 0x00, 0x0D,
                0x00, 0x08, 0x11, 0x1F, 0x88, 0x89, 0x00, 0x0E, 0xDC, 0xCC, 0x6E, 0xE6, 0xDD, 0xDD, 0xD9, 0x99,
                0xBB, 0xBB, 0x67, 0x63, 0x6E, 0x0E, 0xEC, 0xCC, 0xDD, 0xDC, 0x99, 0x9F, 0xBB, 0xB9, 0x33, 0x3E
            };
            byte[] magicNumberArray = new byte[expectedNumberArray.Length];
            rom.Position = 260;
            rom.Read(magicNumberArray, 0, expectedNumberArray.Length);
            if (!BitConverter.IsLittleEndian)
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
            return true;
        }
    }
}
