using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;
using System.Net.Http;
using System.Text.Json;

namespace CSH_P35
{
    class MeowFactData
    {
        public List<string> data { get; set; }
    }

    class Alert
    {
        public int id { get; set; }
        public string location_title { get; set; }
        public string location_type { get; set; }
        public string started_at { get; set; }
        public string finished_at { get; set; }
        public string updated_at { get; set; }
        public string alert_type { get; set; }
        public string location_uid { get; set; }
        public string location_oblast { get; set; }
        public string location_raion { get; set; }
        public string notes { get; set; }
        public bool calculated;
        public int location_oblast_uid { get; set; }
    }

    class Alerts
    {
        public List<Alert> alerts { get; set; }
    }

    class Program
    {
        public static async Task<MeowFactData> GetMeowFacts(int count = 1,string lang= "rus-ru")
        {
            var client = new HttpClient();
            string url = "https://meowfacts.herokuapp.com/";
            string parameters = $"?count={count}&lang={lang}";
            var response = await client.GetAsync(url+parameters);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MeowFactData>(jsonResponse);
            }
            return null;
        }

        public static async Task<Alerts> GetAlert()
        {
            var client = new HttpClient();
            string url = "https://43e2-85-198-148-246.ngrok-free.app/";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Alerts>(jsonResponse);
            }
            return null;
        }

        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            /*var facts = await GetMeowFacts(1, "rus-ru");
            if (facts == null) { Console.WriteLine("error"); }
            else { foreach (var fact in facts.data) { Console.WriteLine(fact+"\n"); } }*/
            var facts = await GetAlert();
            if (facts == null) { Console.WriteLine("error"); }
            else { foreach (var fact in facts.alerts) { Console.WriteLine(fact.location_oblast_uid + ". " + fact.location_oblast + "(" + fact.location_raion+")" + " - " + fact.alert_type + "  " + fact.started_at + "\b  " + fact.notes + "\n"); } }
        }
    }
}




Public API: 
https://github.com/public-apis/public-apis

MeowFacts: 
https://github.com/wh-iterabb-it/meowfacts
https://meowfacts.herokuapp.com/

Alerts Test Server:
https://43e2-85-198-148-246.ngrok-free.app/
