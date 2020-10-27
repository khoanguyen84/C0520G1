using CodeGymWeb.Models.Course;
using Microsoft.AspNetCore.Mvc;
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
        public static T HttpPostAsync(string apiName, T model)
        {
            string result;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@$"{Common.apiUrl}/{apiName}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using(var streamReader = new StreamReader(httpReponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
        public static string result(string apiName, object model)
        {
            string result;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@$"{Common.apiUrl}/{apiName}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpReponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        public static T HttpPutAsync(string apiName, T model)
        {
            string result;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(@$"{Common.apiUrl}/{apiName}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpReponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
