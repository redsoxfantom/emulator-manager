﻿using System;
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
            rom.Read(magicNumberArry, 28, 4);
            uint magicNumber = BitConverter.ToUInt32(magicNumberArry, 0);

            if(magicNumber != 0xC2339F3D)
            {
                return null;
            }

            byte[] romIdArry = new byte[991];
            rom.Read(romIdArry, 32, romIdArry.Length);
            String romId = Encoding.ASCII.GetString(romIdArry);

            return romId;
        }
    }
}
