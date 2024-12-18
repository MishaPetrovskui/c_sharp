using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GAME;

class Shape
{
    public virtual double GetArea() { return 0; }
}

class Square : Shape
{
    double side;
    public Square(double side) { this.side = side; }
    public override double GetArea() { return Math.Pow(side,2); }
    public override string ToString()
    {
        return $"Square(side={this.side})";
    }
}

class Rectangle : Shape
{
    double a, b;
    public Rectangle(double a, double b) { this.a = a; this.b = b; }
    public override double GetArea() { return this.a * this.b; }
    public override string ToString()
    {
        return $"Rectangle(a={this.a}, b={this.b})";
    }
}

class Сircle : Shape
{
    double r;
    public Сircle(double r) { this.r = r; }
    public override double GetArea() { return (3.14)*(Math.Pow(r,2)); }
    public override string ToString()
    {
        return $"Сircle(radius={this.r})";
    }
}

class right_triangle: Shape
{
    double a, b;
    public right_triangle(double a, double b) { this.a = a; this.b = b; }
    public override double GetArea() { return (0.5) * (a * b); }
    public override string ToString()
    {
        return $"Right triangle(katet1={this.a}, katet2={this.b})";
    }
}

class trapezoid : Shape
{
    double a, b, h;
    public trapezoid(double a, double b, double h) { this.a = a; this.b = b; this.h = h; }
    public override double GetArea() { return ((a + b) / 2) * h; }
    public override string ToString()
    {
        return $"Trapezoid(up={this.a}, down={this.b}, height={this.h})";
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Shape[] shapes = { new Square(4), new Rectangle(3, 10), new Сircle(10), new right_triangle(10,6), new trapezoid(6,8,10) };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Area of {shape} is {shape.GetArea()}");
        }
    }
}
