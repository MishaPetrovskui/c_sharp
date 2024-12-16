// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Enter your name");
        //var name = Console.ReadLine();
        //Console.WriteLine("Hello, " + name + "!");
        //Console.WriteLine($"Hello, {name}!");
        //Console.WriteLine("How old are you?");
        //int age = int.Parse( Console.ReadLine());
        ///int age = Convert.ToInt32( Console.ReadLine());
        //if (age < 18)
        //{
            //Console.WriteLine("You are not adult");
        //}
        //else
        //{
            //Console.WriteLine("You are adult");
        //}
        /*
        Console.WriteLine("Enter first number");
        int num = int.Parse( Console.ReadLine());
        int sum = num,min = num,max = num,dobutok = num;
        for (int i = 2; i <= 5; i++)
        {
            Console.WriteLine($"Enter {i} number");
            num = int.Parse( Console.ReadLine());
            sum += num;
            dobutok *= num;
            if (num > max)
                max = num;
            if (num < min)
                min = num;
        }
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Dobutok: {dobutok}");
        */
        Console.WriteLine("Choice");
        Console.WriteLine("1) Ferengeyt => Jelsiy");
        Console.WriteLine("2) Ferengeyt <= Jelsiy");
        Console.WriteLine("Your choice");
        int choice = int.Parse( Console.ReadLine());
        Console.Write("Temp: ");
        double temp = double.Parse(Console.ReadLine());
        double convertedTemp;
        if (choice == 1)
        {
            convertedTemp = (temp - 32) * 5 / 9;
            if (convertedTemp < 0)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (convertedTemp < 10)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (convertedTemp < 20)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (convertedTemp < 30)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ferengeyt => Jelsiy = {convertedTemp}");
        }
        else if (choice == 2)
        {
            convertedTemp = (temp * 9 / 5) + 32;
            if (convertedTemp < 0)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (convertedTemp < 10)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (convertedTemp < 20)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (convertedTemp < 30)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ferengeyt <= Jelsiy = {convertedTemp}");
        }
        else
            Console.WriteLine("ERROR!");
        
    }
}
