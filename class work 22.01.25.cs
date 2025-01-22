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
        public DateTimeOffset started_at { get; set; }
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

    class Oblast
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAlert { get; set; }

        public Oblast(int id, string name, bool isAlert = false)
        {
            Id = id;
            Name = name;
            IsAlert = isAlert;
        }

        public Oblast() : this(0, "") { }
    }


    class Program
    {
        public static string ShortenName(string name, int length)
        {
            return name.Length > length ? name.Substring(0, length - 1) + "…" : name;
        }

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
            string url = "https://105e-85-198-148-246.ngrok-free.app";
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
            List<Oblast> regions = new List<Oblast>()
            {
                new Oblast(0, ""),
                new Oblast(1, ""),
                new Oblast(2, ""),
                new Oblast(3, "Хмельницька область"),
                new Oblast(4, "Вінницька область"),
                new Oblast(5, "Рівненська область"),
                new Oblast(6, ""),
                new Oblast(7, ""),
                new Oblast(8, "Волинська область"),
                new Oblast(9, "Дніпропетровська область"),
                new Oblast(10, "Житомирська область"),
                new Oblast(11, "Закарпатська область"),
                new Oblast(12, "Запорізька область"),
                new Oblast(13, "Івано-Франківська область"),
                new Oblast(14, "Київська область"),
                new Oblast(15, "Кіровоградська область"),
                new Oblast(16, "Луганська область"),
                new Oblast(17, "Миколаївська область"),
                new Oblast(18, "Одеська область"),
                new Oblast(19, "Полтавська область"),
                new Oblast(20, "Сумська область"),
                new Oblast(21, "Тернопільська область"),
                new Oblast(22, "Харківська область"),
                new Oblast(23, "Херсонська область"),
                new Oblast(24, "Черкаська область"),
                new Oblast(25, "Чернігівська область"),
                new Oblast(26, "Чернівецька область"),
                new Oblast(27, "Львівська область"),
                new Oblast(28, "Донецька область"),
                new Oblast(29, "Автономна Республіка Крим"),
                new Oblast(30, "м. Севастополь"),
                new Oblast(31, "м. Київ")
            };
            const int mapWidth = 8, mapHeight = 6, cellWidth = 13;
            int[,] map = new int[mapHeight, mapWidth]
            {
                {0, 0, 0, 0, 31, 0, 0, 0 },
                {8, 0, 5, 10, 14, 25, 20, 0 },
                {27, 21, 3, 4, 24, 19, 22, 16 },
                {11, 13, 26, 0, 15, 9, 28, 0 },
                {0, 0, 0, 0, 17, 23, 12, 0 },
                {0, 0, 0, 18, 0, 29, 0, 0 },
            };
            while (true)
            {
                List<int> right = new List<int>();
                var facts = await GetAlert();
                int u = 0;
                if (facts == null) { Console.WriteLine("error"); }
                else
                {
                    foreach (var fact in facts.alerts)
                    {
                        if (fact.alert_type == "air_raid")
                        {
                            right.Add(Convert.ToInt32(fact.location_uid));
                            u++;
                        }
                    }
                }
                for (int row = 0; row < mapHeight; row++)
                {
                    for (int column = 0; column < mapWidth; column++)
                    {

                        if (map[row, column] == 0) { Console.BackgroundColor = ConsoleColor.Black; }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            for (int i = 0; i < u; i++)
                            {
                                if (right[i] == regions[map[row, column]].Id)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                            }
                        }
                        Console.Write($" {"",cellWidth} ");

                    }
                    Console.WriteLine();
                    for (int column = 0; column < mapWidth; column++)
                    {
                        if (map[row, column] == 0) { Console.BackgroundColor = ConsoleColor.Black; Console.Write($" {ShortenName("", cellWidth),cellWidth} "); }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            for (int i = 0; i < u; i++)
                            {
                                if (right[i] == regions[map[row, column]].Id)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                            }
                            Console.Write($" {ShortenName(regions[map[row, column]].Name, cellWidth),cellWidth} ");
                        }


                    }
                    Console.WriteLine();
                    for (int column = 0; column < mapWidth; column++)
                    {

                        if (map[row, column] == 0) { Console.BackgroundColor = ConsoleColor.Black; }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            for (int i = 0; i < u; i++)
                            {
                                if (right[i] == regions[map[row, column]].Id)
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                            }
                        }
                        Console.Write($" {"",cellWidth} ");

                    }
                    Console.WriteLine();
                }

                Thread.Sleep(3000);
                Console.SetCursorPosition(0,0);
            }
        }
    }
}
