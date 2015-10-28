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
        public string RomType
        {
            get
            {
                return "GameCube";
            }
        }

        public string GetRomId(FileStream rom)
        {
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
                return null;
            }

            byte[] romIdArry = new byte[991];
            rom.Position = 32;
            rom.Read(romIdArry, 0, romIdArry.Length);
            String romId = Encoding.ASCII.GetString(romIdArry).TrimEnd('\0');

            return romId;
        }
    }
}
