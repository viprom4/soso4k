using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace api
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://api.icndb.com/jokes/random";
            string response;

            HttpWebRequest HttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse HttpWebResponse = (HttpWebResponse)HttpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(HttpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            ValueJSON ValueJSON = JsonConvert.DeserializeObject<ValueJSON>(response);
            Console.WriteLine("Шутка: {0}", ValueJSON.Value.Joke);

            Console.ReadLine();
        }
    }
}
