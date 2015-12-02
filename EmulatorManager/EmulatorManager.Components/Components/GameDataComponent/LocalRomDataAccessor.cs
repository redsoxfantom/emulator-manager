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
        private ImageConverter gameDataImageConverter;

        public LocalRomDataAccessor(string dataLocation) : base(dataLocation)
        {
            gameDataImageConverter = new ImageConverter();
            readFileIntoCache();
        }

        public override void ClearCache()
        {
            base.ClearCache();

            readFileIntoCache();
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
            await UpdateOrAddGameData(romId, data);
        }

        public override async Task UpdateOrAddGameData(string romId, GameData data)
        {
            string uniqueId = romId + data.GameSystem;

            if(dataCache.ContainsKey(uniqueId))
            {
                dataCache[uniqueId] = data;
            }
            else
            {
                dataCache.Add(uniqueId, data);
            }

            writeCacheToFile();
        }

        private void readFileIntoCache()
        {
            // Read the data location into the cache, if it exists
            if (File.Exists(mDataLocation))
            {
                dataCache = JsonConvert.DeserializeObject<Dictionary<string, GameData>>(File.ReadAllText(mDataLocation),gameDataImageConverter);
            }
            else
            {
                dataCache = new Dictionary<string, GameData>();
            }
        }

        private void writeCacheToFile()
        {
            string output = JsonConvert.SerializeObject(dataCache, Formatting.Indented,gameDataImageConverter);
            File.WriteAllText(mDataLocation, output);
        }
    }
}
