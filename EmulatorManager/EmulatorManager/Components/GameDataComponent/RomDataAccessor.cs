using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            romType = HttpUtility.UrlEncode(romType);
            romId = HttpUtility.UrlEncode(romId);
            string finalUrl = String.Format("{0}/api/{1}/{2}",mUrl,romType,romId);
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

                        string gameName = responseDataObject.Name;
                        string gamePublisher = responseDataObject.Publisher;
                        string gameSystem = responseDataObject.System;
                        byte[] gameImageArry = Convert.FromBase64String(responseDataObject.Image);
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
    }
}
