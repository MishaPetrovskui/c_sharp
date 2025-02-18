// PROGRAM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gofno;

namespace ConsoleApp10
{
    class Program
    {
        static void Main()
        {
            Game game = new Game(10,20);
            game.StartGame();
        }
    }
}
// CLASSES
using System.Drawing;

namespace Gofno
{
    public class Tetromino
    {
        public int[,] Shape { get; private set; }
        public Point pos;
        public ConsoleColor Color { get; private set; }

        public Tetromino(int[,] shape, int x, int y, ConsoleColor color)
        {
            Shape = (int[,])shape.Clone();
            pos = new Point(x, y);
            Color = color;
        }

        public void Move(int dx, int dy)
        {
            pos.X += dx;
            pos.Y += dy;
        }

        public bool Rotate(Game game)
        {
            int rows = Shape.GetLength(0);
            int cols = Shape.GetLength(1);
            int[,] newShape = new int[cols, rows];

            for (int y = 0; y < rows; y++)
                for (int x = 0; x < cols; x++)
                    newShape[x, rows - 1 - y] = Shape[y, x];

            Tetromino newTetromino = new Tetromino(newShape, pos.X, pos.Y, Color);
            if (!game.area.CanSpawn(newTetromino)) return false;

            Shape = newShape;
            return true;
        }
        public List<Point> GetCoordinates()
        {
            var coordinates = new List<Point>();
            for (int i = 0; i < Shape.GetLength(0); i++)
                for (int j = 0; j < Shape.GetLength(1); j++)
                    if (Shape[i, j] != 0)
                        coordinates.Add(new Point(pos.X + j, pos.Y + i));
            return coordinates;
        }
        public bool Contains(int x, int y)
        {
            foreach (var poi in GetCoordinates())
                if (poi.X == x && poi.Y == y)
                    return true;
            return false;
        }
    }
    public class Area
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private int[,] field;
        private ConsoleColor[,] colorField;

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
            field = new int[height, width];
            colorField = new ConsoleColor[height, width];
        }

        public void Clear(Game game)
        {
            foreach (Point p in game.currentTetromino.GetCoordinates())
            {
                if (p.Y >= 0 && p.Y < Width && p.X >= 0 && p.X < Height)
                {
                    field[p.Y, p.X] = 0;
                }
            }
            Console.SetCursorPosition(0, 0);
            Draw(game.currentTetromino, game.Score);
        }


        public void MergeTetromino(Tetromino tetromino)
        {
            foreach (var na in tetromino.GetCoordinates())
            {
                field[na.Y, na.X] = 1;
                colorField[na.Y, na.X] = tetromino.Color;
            }
        }

        public int ClearRows()
        {
            int cleared = 0;
            for (int y = 0; y < Height; y++)
            {
                bool fullRow = true;
                for (int x = 0; x < Width; x++)
                {
                    if (field[y, x] == 0) { fullRow = false; break; }
                }
                if (fullRow)
                {
                    cleared++;
                    for (int ny = y; ny > 0; ny--)
                        for (int nx = 0; nx < Width; nx++)
                            field[ny, nx] = field[ny - 1, nx];
                }
            }
            return cleared;
        }

        public void Draw(Tetromino tetromino, int score)
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (field[y, x] == 1 || tetromino.Contains(x, y))
                    {
                        if (tetromino.Contains(x, y))
                            Console.ForegroundColor = tetromino.Color;
                        else
                            Console.ForegroundColor = colorField[y, x];
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(Width + 2, 0);
            Console.WriteLine("Score: " + score);
        }

        public bool CanSpawn(Tetromino tetromino)
        {
            foreach (var net in tetromino.GetCoordinates())
                if (net.X < 0 || net.X >= Width || net.Y < 0 || net.Y >= Height || field[net.Y, net.X] != 0)
                    return false;
            return true;
        }
    }
    public class Game
    {
        public int Score { get; private set; }
        public Tetromino currentTetromino;
        public Area area;
        public Random random = new Random();
        private bool moveDownInstantly = false;
        public readonly List<(int[,], ConsoleColor)> tetrominoShapes = new List<(int[,], ConsoleColor)>
    {
        (new int[,] {{1, 1, 1, 1}}, ConsoleColor.Cyan),
        (new int[,] {{1, 1}, {1, 1}}, ConsoleColor.Yellow),
        (new int[,] {{0, 1, 1}, {1, 1, 0}}, ConsoleColor.Green),
        (new int[,] {{1, 1, 0}, {0, 1, 1}}, ConsoleColor.Red),
        (new int[,] {{1, 1, 1}, {0, 1, 0}}, ConsoleColor.DarkMagenta),
        (new int[,] {{1, 0, 0}, {1, 1, 1}}, ConsoleColor.Blue),
        (new int[,] {{0, 0, 1}, {1, 1, 1}}, ConsoleColor.DarkYellow)
    };

        public Game(int width, int height)
        {
            area = new Area(width, height);
        }

        public void StartGame()
        {
            SpawnTetromino();
            while (true)
            {
                InputHandler();
                if (moveDownInstantly)
                {
                    MoveDownInstantly();
                }
                else if (!area.CanSpawn(new Tetromino(currentTetromino.Shape, currentTetromino.pos.X, currentTetromino.pos.Y + 1, currentTetromino.Color)))
                {
                    moveDownInstantly = false;
                    area.MergeTetromino(currentTetromino);
                    Score += area.ClearRows() * 100;
                    SpawnTetromino();
                }
                else
                {
                    currentTetromino.Move(0, 1);
                }
                area.Draw(currentTetromino, Score);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void MoveDownInstantly()
        {
            while (area.CanSpawn(new Tetromino(currentTetromino.Shape, currentTetromino.pos.X, currentTetromino.pos.Y + 1, currentTetromino.Color)))
            {
                currentTetromino.Move(0, 1);
            }
            moveDownInstantly = false;
            area.MergeTetromino(currentTetromino);
            Score += area.ClearRows() * 100;
            SpawnTetromino();
        }

        private void SpawnTetromino()
        {
            var shapeColorPair = tetrominoShapes[random.Next(tetrominoShapes.Count)];
            currentTetromino = new Tetromino(shapeColorPair.Item1, area.Width / 2, 0, shapeColorPair.Item2);
            if (!area.CanSpawn(currentTetromino))
            {
                Console.Clear();
                Console.WriteLine("Game Over! Your Score: " + Score);
                Environment.Exit(0);
            }
        }

        private void UpdateGame()
        {
            currentTetromino.Move(0, 1);
            if (!area.CanSpawn(currentTetromino))
            {
                currentTetromino.Move(0, -1);
                area.MergeTetromino(currentTetromino);
                Score += area.ClearRows();
                SpawnTetromino();
            }
            area.Draw(currentTetromino, Score);
        }

        private void InputHandler()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                Tetromino testTetromino = new Tetromino(currentTetromino.Shape, currentTetromino.pos.X, currentTetromino.pos.Y, currentTetromino.Color);
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        testTetromino.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        testTetromino.Move(1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        moveDownInstantly = true;
                        return;
                    case ConsoleKey.Spacebar:
                        if (testTetromino.Rotate(this))
                            currentTetromino = testTetromino;
                        return;
                }
                if (area.CanSpawn(testTetromino))
                    currentTetromino = testTetromino;
            }
        }
    }
}
