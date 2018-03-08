using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public static class JsonFromURL<T> where T : class
    {
        public static List<T> ConvertToListObjects(string urlPath)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept-Language: ru-RU");
            var json = webClient.DownloadString(urlPath);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            UTF8Encoding utf = new UTF8Encoding();
            Byte[] encodedBytes = win1251.GetBytes(json);
            json = utf.GetString(encodedBytes);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

            return list;
        }

        public static T ConvertToObject(string urlPath)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept-Language: ru-RU");
            var json = webClient.DownloadString(urlPath);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            UTF8Encoding utf = new UTF8Encoding();
            Byte[] encodedBytes = win1251.GetBytes(json);
            json = utf.GetString(encodedBytes);
            T obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public static string GetJson(string urlPath)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept-Language: ru-RU");
            var json = webClient.DownloadString(urlPath);
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            UTF8Encoding utf = new UTF8Encoding();
            Byte[] encodedBytes = win1251.GetBytes(json);
            json = utf.GetString(encodedBytes);

            return json;
        }
    }
}
