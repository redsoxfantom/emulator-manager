using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmulatorManager.Components.GameDataComponent
{
    /// <summary>
    /// Reads ROM data from a local file
    /// </summary>
    public class LocalRomDataAccessor : BaseDataAccessor
    {
        private FileStream dataFile;

        public LocalRomDataAccessor(string dataLocation) : base(dataLocation)
        {
            dataFile = File.Open(dataLocation, FileMode.OpenOrCreate);
        }

        public override Task<GameData> RetrieveGameData(string romType, string romId)
        {
            throw new NotImplementedException();
        }

        public override void UpdateGamePlayedTime(string romId, GameData data)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateOrAddGameData(string romId, GameData data)
        {
            throw new NotImplementedException();
        }
    }
}
