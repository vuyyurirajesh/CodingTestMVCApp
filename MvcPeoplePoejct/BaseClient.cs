#region Using Directives

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

#endregion

namespace MvcPeoplePoejct.Client
{
    public class BaseClient
    {

        public async Task<TResult> PostJsonAsync<TResult>(string postUrl, object objData)
        {
            var url = postUrl;
            try
            {
                var httpClient = new HttpClient();
                var asdf = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(objData));
                var clientResponse = await
                        httpClient.PostAsync(url,
                            new StringContent(JsonConvert.SerializeObject(objData), Encoding.UTF8,
                                "application/json"));

                var contentResult = await clientResponse.Content.ReadAsStringAsync();
                return
                    JsonConvert.DeserializeObject<TResult>(contentResult);
            }
            catch (Exception ex)
            {
                return default(TResult);
            }
        }

        public TResult PostJson<TResult>(string postUrl, object objData)
        {
            var url = postUrl;
            try
            {
                var httpClient = new HttpClient();
                var clientResponse =
                        httpClient.PostAsync(url,
                            new StringContent(JsonConvert.SerializeObject(objData), Encoding.UTF8,
                                "application/json")).Result;

                var contentResult = clientResponse.Content.ReadAsStringAsync().Result;
                //httpClient.Dispose();

                return
                    JsonConvert.DeserializeObject<TResult>(contentResult);
            }
            catch (Exception ex)
            {
                return default(TResult);
            }
        }


        public TResult GetJson<TResult>(string getUrl)
        {
            var url = getUrl;
            try
            {
                var httpClient = new HttpClient();
                var clientResponse =
                        httpClient.GetAsync (url).Result;

                var contentResult = clientResponse.Content.ReadAsStringAsync().Result;
                //httpClient.Dispose();

                return
                    JsonConvert.DeserializeObject<TResult>(contentResult);
            }
            catch (Exception ex)
            {
                return default(TResult);
            }
        }
    }
}
