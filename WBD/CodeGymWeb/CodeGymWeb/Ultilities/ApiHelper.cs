using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeGymWeb.Ultilities
{
    public static class ApiHelper <T> where T:class
    {
        public static T HttpGetAsync(string apiName)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@$"{Common.apiUrl}/{apiName}");
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        responseData = sr.ReadToEnd();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                return JsonConvert.DeserializeObject<T>(responseData);
                
            }
        }
    }
}
