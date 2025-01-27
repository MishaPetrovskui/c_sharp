using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleApp1.Deck_of_Cards.charecter;

namespace ConsoleApp1.Deck_of_Cards.main
{
    class main
    {
        public static async Task<desk> GetDesk()
        {
            var client = new HttpClient();
            string url = "https://deckofcardsapi.com/api/deck/new/";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<desk>(jsonResponse);
            }
            return null;
        }
        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            var facts = await GetDesk();
            facts.TheReshuffleTheCards();
            facts = await facts.DrawACard(5);
            if (facts == null) { Console.WriteLine("error"); }
            else { foreach (var fact in facts.cards) { fact.print(); } }

        }
    }
}



//drugoe


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp1.Deck_of_Cards.charecter
{
    /*enum suit
    {
        Ace, Jack, Queen, King, Spades, Diamonds, Clubs, Hearts
    }*/
    class Cardes
    {
        public List<card> cards { get; set; }
    }
    class desk
        {
            public bool success { get; set; }
            public string deck_id { get; set; }
            public bool shuffled { get; set; }
            public int remaining { get; set; }
            public List<card> cards { get; set; }
            public async Task<desk> ReshuffleTheCards()
            {
                var client = new HttpClient();
                string url = $"https://deckofcardsapi.com/api/deck/{this.deck_id}/shuffle/?remaining=true";
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<desk>(jsonResponse);
                }
                return null;
            }
            public async Task<desk> DrawACard(int count)
            {
                var client = new HttpClient();
                string url = $"https://deckofcardsapi.com/api/deck/{deck_id}/draw/?count={count}";
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<desk>(jsonResponse);
                }
                return null;
            }
            public async Task<desk> TheReshuffleTheCards()
            {
                var client = new HttpClient();
                string url = $"https://deckofcardsapi.com/api/deck/{this.deck_id}/shuffle/";
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<desk>(jsonResponse);
                }
                return null;
            }
        }
        class card
        {
            public string code { get; set; }
            public string value { get; set; }
            public string suit { get; set; }

            public override string ToString()
            {
                string a = "", b = "";
                if (suit == "HEARTS")
                    a = "♥";
                else if (suit == "SPADES")
                    a = "♠";
                else if (suit == "DIAMONDS")
                    a = "♦";
                else if (suit == "CLUBS")
                    a = "♣";
                else
                    a = "";
                if (value == "0" || value == "10")
                    b = "1";
                return $"{b}{code}\b{a}";
            }
            public void print()
            {
                string a = "", b = "";
                if (suit == "HEARTS")
                    a = "♥";
                else if (suit == "SPADES")
                    a = "♠";
                else if (suit == "DIAMONDS")
                    a = "♦";
                else if (suit == "CLUBS")
                    a = "♣";
                else
                    a = "";
                if (value == "0" || value == "10")
                    b = "1";
                if (suit == "HEARTS" || suit == "DIAMONDS")
                    Console.ForegroundColor = ConsoleColor.Red;
                else { Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.White; }
                Console.WriteLine($"{b}{code}\b{a}");
                Console.ResetColor();
            }
        }

}
