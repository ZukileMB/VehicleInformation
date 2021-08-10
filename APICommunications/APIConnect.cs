using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace APICommunications
{
    public class APIConnect
    {
        public string URL; 
        public APIConnect()
        {

        }

       public APIConnect(string url)
        {
            URL = url;
           
        }
        public HttpRequestMessage PostAsync (object request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
        }
    }
}
