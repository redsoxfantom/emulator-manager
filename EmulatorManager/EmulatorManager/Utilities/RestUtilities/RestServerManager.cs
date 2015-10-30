using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Utilities.RestUtilities
{
    public class RestServerManager
    {
        public async static Task<dynamic> Get(string url)
        {
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    if(resp.IsSuccessStatusCode)
                    {

                    }
                    else
                    {
                        throw new ResponseStatusCodeException(String.Format("Status Code: {0}",resp.StatusCode));
                    }
                }
            }
        } 
    }
}
