using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Game;
using System.Drawing;

namespace ConsoleApp1.Game
{
    class main
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.InputEncoding = UTF8Encoding.UTF8;

            Game game = new Game(new Point(10,10));

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) { game.ChangeSnakeDirection(napramok.up); }
                if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) { game.ChangeSnakeDirection(napramok.down); }
                if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) { game.ChangeSnakeDirection(napramok.right); }
                if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) { game.ChangeSnakeDirection(napramok.left); }

                game.Update();
                game.Draw();

                if (game.IsGameOver) { break; }
                Thread.Sleep(100);
            }
        }
    }
}




using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Game
{
    enum napramok
    {
        up, down, right, left, nothing
    }
    class Snake
    {
        public List<Point> pos = new List<Point>();
        public ConsoleColor color = ConsoleColor.White;
        public ConsoleColor HeadColor = ConsoleColor.White;
        public string HeadSymbol = "╧";
        public string SegmentSymbol = "•";
        public napramok napramok;

        public void DrawHead()
        {
            Console.ForegroundColor = this.HeadColor;
            Console.Write(HeadSymbol);
            Console.ResetColor();
        }
        public void DrawSegment()
        {
            Console.ForegroundColor = this.color;
            Console.Write(SegmentSymbol);
            Console.ResetColor();
        }
        public Point GetHead()
        { return pos[0]; }
        public Point GetTail() { return pos[pos.Count() - 1]; }

        public bool IsColide(Point newPos)
        {
            for (int i = 0; i < pos.Count(); i++)
            {
                if (pos[i] == newPos)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Update(napramok napramok)
        {
            Point NewPos;

            if (napramok == napramok.up)
            {
                NewPos = GetHead();
                NewPos.Y++;
                return true;
            }
            else if (napramok == napramok.down)
            {
                NewPos = GetHead();
                NewPos.Y--;
                return true;
            }
            else if (napramok == napramok.right)
            {
                NewPos = GetHead();
                NewPos.X++;
                return true;
            }
            else if (napramok == napramok.left)
            {
                NewPos = GetHead();
                NewPos.X--;
                return true;
            }
            return false;
        }
    }
    class Game
    {
        Snake snake;
        public List<Point> fruit = new List<Point>();
        public Point Size;
        public bool IsGameOver = false;
        Random rng = new Random(DateTime.Now.Second);
        public Game(Point Size)
        {
            this.Size = Size;
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            fruit.Add(new Point(rng.Next(0, Size.X), rng.Next(0, Size.Y)));
            for (int row = 0;row < Size.X;row++)
            {
                for (int col = 0;col < Size.Y; col++)
                {
                    if (new Point(row,col)==snake.GetHead())
                    { snake.DrawHead(); }
                    else if (snake.IsColide(new Point(row, col))) { snake.DrawSegment(); }
                    else if (fruit.Contains(new Point(row, col))) { Console.WriteLine("f"); fruit.Add(new Point(rng.Next(0, Size.X), rng.Next(0, Size.Y))); }
                    else { Console.WriteLine(" "); }
                }
            }
        }
        public void Update()
        {
            snake.Update(napramok.nothing);

        }
        public void ChangeSnakeDirection(napramok napramok)
        {
            Point NewPos;
            if (napramok == napramok.up)
            {
                snake.Update(napramok.up);
            }
            else if (napramok == napramok.down)
            {
                snake.Update(napramok.down);
            }
            else if (napramok == napramok.right)
            {
                snake.Update(napramok.right);
            }
            else if (napramok == napramok.left)
            {
                snake.Update(napramok.left);
            }
        }
    }
}
