using CG.Domain.Response.Course;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CG.Web.Ultilities
{
    public class ApiHelper
    {
        public static T HttpGetAsync(string apiUrl, string method = "GET")
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.Method = method;
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

        internal CourseView HttpGetAsync(string v)
        {
            throw new NotImplementedException();
        }
    }
}
