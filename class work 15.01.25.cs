using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSH_P35.ConsoleGame.Game;
/*using GAME;*/

namespace CSH_P35.ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;
            Random rng = new Random(DateTime.Now.Second);
            Player player = new Player();
            player.pos = new Point(3, 3);
            Console.CursorVisible = false;

            List<Coin> coinList = new List<Coin>();
            for (int i = 0; i < 5; i++)
            {
                coinList.Add(new Coin(rng.Next(0,60), rng.Next(0,25)));
            }

            ScoreBar scoreBar = new ScoreBar();
            scoreBar.pos = new Point(0, 0);
            while (true)
            {
                Console.Clear();
                scoreBar.Draw();
                foreach (var coin in coinList.ToList()) {
                    if (player.Distanse(coin.Pos) <= 1)
                    {
                        coinList.Remove(coin);
                        scoreBar.score++;
                        coinList.Add(new Coin(rng.Next(1, 60), rng.Next(1, 25)));
                    }
                    else
                    {
                        coin.Draw();
                    }
                }
                player.Draw();

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D)
                {
                    player.Move(1,0);
                }
                else if (key == ConsoleKey.A)
                {
                    player.Move(-1, 0);
                }
                else if (key == ConsoleKey.W)
                {
                    player.Move(0, -1);
                }
                else if (key == ConsoleKey.S)
                {
                    player.Move(0, 1);
                }
                else if (key == ConsoleKey.Delete)
                {
                    break;
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    scoreBar.score++;
                }
            }
        }
    }
}





//drugoe




using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSH_P35.ConsoleGame.Game
{
    class Player
    {
        public Point pos;
        public ConsoleColor color= ConsoleColor.White;
        public Point Pos { get { return pos; } set { pos.X = Math.Max(value.X, 0); pos.Y = Math.Max(value.Y, 0); } }

        public void Move(Point pos)
        {
            this.pos.X = Math.Max(this.pos.X + pos.X, 0); 
            this.pos.Y = Math.Max(this.pos.Y + pos.Y, 0);
        }
        
        public void Move(int x, int y)
        {
            this.Move(new Point(x, y));
        }

        public void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);

            Console.ForegroundColor = color;
            Console.Write("😮");
            Console.ResetColor();
        }
        public int Distanse(Point point)
        {
            return (int)Math.Sqrt(Math.Pow(this.pos.X - point.X, 2) + Math.Pow(this.pos.Y - point.Y, 2));
        }
    }
    class Coin
    {
        public Point pos;
        public ConsoleColor color = ConsoleColor.Yellow;
        public Point Pos { get { return pos; } set { pos.X = Math.Max(value.X, 0); pos.Y = Math.Max(value.Y, 0); } }

        public void Move(Point pos)
        {
            this.pos.X = Math.Max(this.pos.X + pos.X, 0);
            this.pos.Y = Math.Max(this.pos.Y + pos.Y, 0);
        }

        public void Move(int x, int y)
        {
            this.Move(new Point(x, y));
        }

        public Coin(int x, int y) : this(new Point(x,y)) { }
        public Coin(Point pos) { this.pos = pos; }

        public void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);

            Console.ForegroundColor = this.color;
            Console.Write("💸");
            Console.ResetColor();
        }
    }

    class ScoreBar
    {
        public int score;
        public Point pos;
        public int width = 8;
        public int height = 3;

        public void Draw()
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            for (int i = 0; i < height; i++)
            {    Console.SetCursorPosition(pos.X, pos.Y + i);
                 Console.Write("|");
            }
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(pos.X + width, pos.Y + i);
                Console.Write("|");
            }
            Console.SetCursorPosition(pos.X + (width/2), pos.Y);
            Console.Write(score);
        }
    }
}
