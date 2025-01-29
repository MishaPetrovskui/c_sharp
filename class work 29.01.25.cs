using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp1.Deck_of_Cards.charecter;

namespace ConsoleApp1.Deck_of_Cards.main
{
    class API
    {
        public static readonly string host = "https://date.nager.at/api/";
        public static readonly HttpClient httpClient = new HttpClient();

        public static string MakeRequest(string url)
        {
            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode && response != null)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else throw new HttpRequestException();
        }
    }
    enum Types
    {
        Public, Bank, School, Authorities, Optional, Observance
    }
    class PublicHolidays
    {        
        public string? date { get; set; }
        public string? localName { get; set; }
        public string? name { get; set; }
        public string? countryCode { get; set; }
        public bool? global { get; set; }
        public string? counties { get; set; }
        public int? launchYear { get; set; }
        public List<string>? types { get; set; }
    }
    class Nagger
    {
        public List<PublicHolidays> holidays { get; set; } = new List<PublicHolidays>();
    }
    class main
    {
        /*public static async Task<desk> GetDesk()
        {
            
            string url = "https://deckofcardsapi.com/api/deck/new/";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<desk>(jsonResponse);
            }
            return null;
        }*/
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            /*var facts = await GetDesk();
            facts.TheReshuffleTheCards();
            facts = await facts.DrawACard(5);
            if (facts == null) { Console.WriteLine("error"); }
            else { foreach (var fact in facts.cards) { fact.print(); } }*/ 
            List<PublicHolidays> holidays = new List<PublicHolidays>();
            holidays = JsonSerializer.Deserialize<List<PublicHolidays>> (API.MakeRequest("https://date.nager.at/api/v3/PublicHolidays/2025/UA"));
            if (holidays == null) { Console.WriteLine("error"); }
            else {
                int a = 1; foreach (var fact in holidays) 
                { 
                    string Date = "2025-01-29";
                    if (DateTime.ParseExact(fact.date, "yyyy-MM-dd", null) < DateTime.Now) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (a == 1)
                    {
                        Console.WriteLine("Today - " + Date);
                        if (DateTime.ParseExact(fact.date, "yyyy-MM-dd", null) >= DateTime.Now)
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        a++;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(fact.date + " - " + fact.localName + "(" + fact.name + ")");
                    Console.ResetColor();
                } 
            }

        }
    }
}



//drugoe


