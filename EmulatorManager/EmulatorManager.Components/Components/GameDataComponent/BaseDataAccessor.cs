using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    class BaseDataAccessor : IRomDataAccessor
    {
        public BaseDataAccessor(string dataLocation)
        {

        }

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
