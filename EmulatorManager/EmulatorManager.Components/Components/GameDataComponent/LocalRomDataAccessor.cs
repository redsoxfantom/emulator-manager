using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    /// <summary>
    /// Reads ROM data from a local file
    /// </summary>
    class LocalRomDataAccessor : IRomDataAccessor
    {
        public void ClearCache()
        {
            throw new NotImplementedException();
        }

        public Task<GameData> RetrieveGameData(string romType, string romId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGamePlayedTime(string romId, GameData data)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrAddGameData(string romId, GameData data)
        {
            throw new NotImplementedException();
        }
    }
}
