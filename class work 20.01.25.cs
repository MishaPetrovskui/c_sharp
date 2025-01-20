using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;
using System.Net.Http;

namespace CSH_P35
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            var client = new HttpClient();
            string url = "https://meowfacts.herokuapp.com/";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}




Public API: 
https://github.com/public-apis/public-apis

MeowFacts: 
https://github.com/wh-iterabb-it/meowfacts
https://meowfacts.herokuapp.com/
