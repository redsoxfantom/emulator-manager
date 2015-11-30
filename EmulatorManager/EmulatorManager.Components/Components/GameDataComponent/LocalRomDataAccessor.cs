using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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
            if (File.Exists(dataLocation))
            {
                dataCache = JsonConvert.DeserializeObject<Dictionary<string, GameData>>(File.ReadAllText(dataLocation));
            }
        }

        public override async Task<GameData> RetrieveGameData(string romType, string romId)
        {
            GameData result = new GameData();

            if(dataCache.ContainsKey(romType+romId))
            {
                result = dataCache[romType + romId];
            }

            return result;
        }

        public override async void UpdateGamePlayedTime(string romId, GameData data)
        {
            throw new NotImplementedException();
        }

        public override async Task UpdateOrAddGameData(string romId, GameData data)
        {
            throw new NotImplementedException();
        }
    }
}
