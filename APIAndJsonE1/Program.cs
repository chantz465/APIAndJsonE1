using System;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIAndJsonE1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            string kanyeResponse;
            string ronResponse;
            string kanyeQuote;
            string ronQuote;

            for (int i = 0; i < 5; i++)
            {
                kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
                ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($" Kanye West - {kanyeQuote}");
                Console.WriteLine($" Ron Swanson - {ronQuote}");
                Console.WriteLine();
                Console.WriteLine("---------");
                Console.WriteLine();
            }

            
        }
    }
}
