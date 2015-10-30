using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent.RomReaders
{
    public class GamecubeRomReader : IRomReader
    {
        public bool AttemptToReadRom(FileStream rom, out string RomId, out string RomType)
        {
            RomId = null;
            RomType = null;

            byte[] magicNumberArry = new byte[4];
            rom.Position = 28;
            rom.Read(magicNumberArry, 0, 4);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(magicNumberArry);
            }
            uint magicNumber = BitConverter.ToUInt32(magicNumberArry, 0);

            if(magicNumber != 0xC2339F3D)
            {
                return false;
            }

            byte[] romIdArry = new byte[991];
            rom.Position = 32;
            rom.Read(romIdArry, 0, romIdArry.Length);
            RomId = Encoding.ASCII.GetString(romIdArry).TrimEnd('\0');
            RomType = "GameCube";

            return true;
        }
    }
}
