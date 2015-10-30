using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent.RomReaders
{
    public interface IRomReader
    {
        bool AttemptToReadRom(FileStream rom, out string RomId, out string RomType);
    }
}
