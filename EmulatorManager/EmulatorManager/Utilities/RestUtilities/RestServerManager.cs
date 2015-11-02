using log4net;
using Newtonsoft.Json;
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
        private static ILog mLogger = LogManager.GetLogger("RestServerManager");

        public async static Task<dynamic> Get(string url)
        {
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    if(resp.IsSuccessStatusCode)
                    {
                        string responseData = await resp.Content.ReadAsStringAsync();
                        mLogger.Debug(String.Format("Server returned the following string:\n{0}", responseData));
                        dynamic responseDataObject = JsonConvert.DeserializeObject(responseData);

                        return responseDataObject;
                    }
                    else
                    {
                        throw new ResponseStatusCodeException(String.Format("Status Code: {0}",resp.StatusCode));
                    }
                }
            }
        }

        public async static void Put(string url, Dictionary<string,string> data)
        {
            using (var client = new HttpClient())
            {
                HttpContent content = createHeader(data);
                try
                {
                    await client.PutAsync(url, content);
                }
                catch(Exception ex)
                {
                    throw new RestServerManagerException("Error occurred in PUT", ex);
                }
                finally
                {
                    content.Dispose();
                }
            }
        }

        public async static void Post(string url, Dictionary<string,string> data)
        {
            using (var client = new HttpClient())
            {
                HttpContent content = createHeader(data);
                try
                {
                    await client.PostAsync(url, content);
                }
                catch(Exception ex)
                {
                    throw new RestServerManagerException("Error occurred in POST", ex);
                }
                finally
                {
                    content.Dispose();
                }
            }
        }

        private static HttpContent createHeader(Dictionary<string,string> headerData)
        {
            var content = new MultipartContent();
            foreach(var headerName in headerData.Keys)
            {
                var headerValue = headerData[headerName];
                content.Headers.Add(headerName, headerValue);
            }
            return content;
        }
    }
}
