using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using WebAppShiba.DataBase;
using WebAppShiba.Models;

namespace WebAppShiba.Service
{
    public class DataFetcherShiba
    {
        private const string _URL = "http://shibe.online/api";

        public static List<string> CallApi(int numero)
        {
            var client = new RestClient(_URL);
            var request=new RestRequest("shibes?count="+numero, Method.GET);
            var risposta = client.Get(request);
            var myContent=JsonSerializer.Deserialize<List<string>>(risposta.Content);
            return myContent;
        }

        public static bool IsShibaInDb(string url)
        {
            using (var db = ShibaContext.CallShibaContext())
            {
                foreach(var item in db.Url)
                {
                    if (item.Url.Equals(url))
                        return false;
                }
                return true;
            }
        }

    }
}
