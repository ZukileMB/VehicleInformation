using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APICommunication
{
    public class APIConnect
    {
        public string APIBaseUrl;
        public APIConnect()
        {

        }

        public APIConnect(string url)
        {
            APIBaseUrl = url;

        }
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T request)
        {
            HttpResponseMessage result = null;
            Task task;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIBaseUrl);


                //HTTP POST
                 task = await client.PostAsJsonAsync(url,request).ContinueWith(async response => { result = await response; });
                task.Wait();
                return result;
            }
           
        }
    }
}
