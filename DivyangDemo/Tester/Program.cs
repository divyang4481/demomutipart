using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {

                using (var multipartFormDataContent = new MultipartFormDataContent())
                {


                    var values = new[]
                    {
                        new KeyValuePair<string, string>("model", Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            ClientId = 5,
                            ClientName = "Somename"
                        }))
                    };

                    //other values


                    foreach (var keyValuePair in values)
                    {
                        multipartFormDataContent.Add(new StringContent(keyValuePair.Value),
                            String.Format("\"{0}\"", keyValuePair.Key));
                    }

                    multipartFormDataContent.Add(
                        new ByteArrayContent(File.ReadAllBytes(@"D:\1781964_10152480047443243_314448990_n.jpg")),
                        '"' + "File" + '"',
                        '"' + "1781964_10152480047443243_314448990_n.jpg" + '"');

                    var requestUri = "http://localhost:46264/api/Demo";
                    var result = client.PostAsync(requestUri, multipartFormDataContent).Result;
                    Console.ReadKey();

                }

            }


        }



        
    }
}

