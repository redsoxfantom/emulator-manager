using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataAccessor
    {
        string mUrl;

        HttpClient mCLient;

        private ILog mLogger;

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
            mCLient = new HttpClient();
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public async Task<GameData> LoadGameData(string romType, string romId)
        {
            string finalUrl = String.Format("{0}/api/{1}/{2}",mUrl,romType,romId);

            using (HttpResponseMessage resp = await mCLient.GetAsync(finalUrl))
            {
                if (resp.IsSuccessStatusCode)
                {
                    string responseDataString = await resp.Content.ReadAsStringAsync();
                    dynamic responseDataObject = JsonConvert.DeserializeObject(responseDataString);
                }
                else
                {
                    mLogger.Error(String.Format("Request for game data (url: {0}) returned ({1})",mUrl,resp.StatusCode));
                }
            }

            return null;
        }
    }
}
