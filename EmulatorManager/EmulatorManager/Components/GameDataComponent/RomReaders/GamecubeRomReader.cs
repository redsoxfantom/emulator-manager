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
            throw new NotImplementedException();
        }
    }
}
