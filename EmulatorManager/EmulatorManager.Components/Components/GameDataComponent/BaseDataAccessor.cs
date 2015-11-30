using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public abstract class BaseDataAccessor : IRomDataAccessor
    {
        protected string mDataLocation;

        protected ILog mLogger;

        protected Dictionary<string, GameData> dataCache;

        public BaseDataAccessor(string dataLocation)
        {
            mDataLocation = dataLocation;
            mLogger = LogManager.GetLogger(GetType().Name);
            dataCache = new Dictionary<string, GameData>();

            mLogger.Debug(String.Format("Data Accessor created with data location {0}", dataLocation));
        }

        public void ClearCache()
        {
            mLogger.Info("Clearing data cache");
            dataCache.Clear();
        }

        public abstract Task<GameData> RetrieveGameData(string romType, string romId);

        public abstract void UpdateGamePlayedTime(string romId, GameData data);

        public abstract Task UpdateOrAddGameData(string romId, GameData data);
    }
}
