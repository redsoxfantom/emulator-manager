using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        HttpClient mClient;

        private ILog mLogger;

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
            mClient = new HttpClient();
            mLogger = LogManager.GetLogger(GetType().Name);

            mLogger.Debug(String.Format("Data Accessor created with url {0}", mUrl));
        }

        public async Task<GameData> RetrieveGameData(string romType, string romId)
        {
            string dataId = romId + romType;
            string finalUrl = String.Format("{0}/gamedata/GetGameDataByNameSystem/{1}",mUrl,dataId);
            mLogger.Info(String.Format("Attempting to request game data from {0}", finalUrl));
            GameData data = null;
            HttpResponseMessage resp = null;

            try
            {
                resp = await mClient.GetAsync(finalUrl);
                if (resp.IsSuccessStatusCode)
                {
                    string responseDataString = await resp.Content.ReadAsStringAsync();
                    mLogger.Debug(String.Format("Successfully got data from server: {0}", responseDataString));
                    try
                    {
                        dynamic responseDataObject = JsonConvert.DeserializeObject(responseDataString);

                        string gameName = responseDataObject.userData.Name;
                        string gamePublisher = responseDataObject.userData.Publisher;
                        string gameSystem = responseDataObject.userData.System;
                        byte[] gameImageArry = Convert.FromBase64String(responseDataObject.userData.Image);
                        Image gameImage = Bitmap.FromStream(new MemoryStream(gameImageArry));

                        data = new GameData(gameName, gamePublisher, gameSystem, gameImage);
                    }
                    catch(Exception ex)
                    {
                        mLogger.Error("Failed to handle response from server", ex);
                        data = new GameData();
                    }
                }
                else
                {
                    mLogger.Error(String.Format("Request for game data (url: {0}) returned ({1})",mUrl,resp.StatusCode));
                    data = new GameData();
                }
            }
            catch(Exception ex)
            {
                mLogger.Error("Failed to request game data from server", ex);
            }
            finally
            {
                if(resp != null)
                {
                    resp.Dispose();
                }
            }

            if(data == null)
            {
                data = new GameData();
            }

            return data;
        }

        private string Cleanup(String str)
        {
            IdnMapping mapping = new IdnMapping();
            str = mapping.GetAscii(str);

            //  Remove all invalid characters.  
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            //  Convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            //  Replace spaces by underscores.
            str = Regex.Replace(str, @"\s", "_");

            return str;
        }
    }
}
