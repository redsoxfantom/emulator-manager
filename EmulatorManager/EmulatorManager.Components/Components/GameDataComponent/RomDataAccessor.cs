using EmulatorManager.Utilities.RestUtilities;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataAccessor
    {
        string mUrl;

        private ILog mLogger;

        private Dictionary<string, GameData> dataCache;

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
            mLogger = LogManager.GetLogger(GetType().Name);
            dataCache = new Dictionary<string, GameData>();

            mLogger.Debug(String.Format("Data Accessor created with url {0}", mUrl));
        }

        public void ClearCache()
        {
            mLogger.Info("Clearing data cache");
            dataCache.Clear();
        }

        public async Task<GameData> RetrieveGameData(string romType, string romId)
        {
            string dataId = romId + romType;
            dataId = Cleanup(dataId);
            if(dataCache.ContainsKey(dataId))
            {
                mLogger.Info("Returning data from cache");
                return dataCache[dataId];
            }

            string finalUrl = String.Format("{0}/gamedata/GetGameDataByNameSystem/{1}",mUrl,dataId);
            mLogger.Info(String.Format("Attempting to request game data from {0}", finalUrl));
            GameData data = new GameData();

            try
            {
                dynamic serverGameData = await RestServerManager.Get(finalUrl);

                string gameName = serverGameData.userData.Name;
                string gamePublisher = serverGameData.userData.Publisher;
                string gameSystem = serverGameData.userData.System;
                string gameImageBase64String = serverGameData.userData.Image;
                string id = serverGameData.userData.id;
                TimeSpan timePlayed = TimeSpan.FromSeconds(serverGameData.userData.TimePlayedInSecs);
                byte[] gameImageArry = Convert.FromBase64String(gameImageBase64String);
                Image gameImage = Bitmap.FromStream(new MemoryStream(gameImageArry));

                data = new GameData(gameName, gamePublisher, gameSystem, gameImage,id,timePlayed,true);
                dataCache.Add(dataId, data);
            }
            catch(ResponseStatusCodeException ex)
            {
                mLogger.Error("Server returned failing status code", ex);
            }
            catch(Exception ex)
            {
                mLogger.Error("Game Data request failed", ex);
            }

            return data;
        }

        public async Task UpdateOrAddGameData(string romId, GameData data)
        {
            String base64Image = null;
            using (MemoryStream mem = new MemoryStream())
            {
                data.GameImage.Save(mem, data.GameImage.RawFormat);
                byte[] imgBytes = mem.ToArray();
                base64Image = Convert.ToBase64String(imgBytes);
            }

            string dataId = romId + data.GameSystem;
            dataId = Cleanup(dataId);

            string baseUrl = String.Format("{0}/gamedata", mUrl);
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Name", data.GameName);
            header.Add("Publisher", data.GamePublisher);
            header.Add("System", data.GameSystem);
            header.Add("Image", base64Image);

            if (data.ExistsOnServer)
            {
                string finalUrl = String.Format("{0}/{1}", baseUrl, data.Id);
                try
                {
                    mLogger.Info(String.Format("Attempting to update game data object at {0}", finalUrl));
                    await RestServerManager.Put(finalUrl, header);
                }
                catch (Exception ex)
                {
                    mLogger.Error("Error updating game data", ex);
                }
            }
            else
            {
                string finalUrl = String.Format("{0}/create?NameSystem={1}",baseUrl,dataId);
                try
                {
                    mLogger.Info(String.Format("Attempting to create new game data object at {0}", finalUrl));
                    await RestServerManager.Post(finalUrl, header);
                }
                catch (Exception ex)
                {
                    mLogger.Error("Error creating game data", ex);
                }
            }
        }

        private string Cleanup(String str)
        {
            IdnMapping mapping = new IdnMapping();
            str = mapping.GetAscii(str);

            //  Remove all invalid characters.  
            str = Regex.Replace(str, @"[^A-Za-z0-9\s-]", "");

            //  Convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            //  Replace spaces by underscores.
            str = Regex.Replace(str, @"\s", "_");

            return str;
        }
    }
}
