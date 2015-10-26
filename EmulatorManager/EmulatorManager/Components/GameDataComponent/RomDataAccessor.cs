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

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
            mCLient = new HttpClient();
        }

        public async Task<GameData> LoadGameData(string romType, string romId)
        {
            string finalUrl = String.Format("{0}/api/{1}/{2}",mUrl,romType,romId);

            using (HttpResponseMessage resp = await mCLient.GetAsync(finalUrl))
            {
                if (resp.IsSuccessStatusCode)
                {
                    string responseDataString = await resp.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }
}
