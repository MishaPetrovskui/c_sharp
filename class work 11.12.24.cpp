using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;

class Fraction
{
    public int verh;
    public int niz;

    public Fraction(int x, int y)
    {
        this.verh = x;
        this.niz = y;
    }
    Fraction() : this(0, 0) { }
    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction((a.verh * b.niz) + (b.verh * a.niz), a.niz * b.niz);
    }
    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction((a.verh * b.niz) - (b.verh * a.niz), a.niz * b.niz);
    }
    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.verh * b.verh, a.niz * b.niz);
    }
    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.verh * b.niz, a.niz * b.verh);
    }
    public static bool operator ==(Fraction a, Fraction b) { return (a.verh == b.verh && a.niz == b.niz); }
    public static bool operator !=(Fraction a, Fraction b) { return !(a == b); }
    public static bool operator true(Fraction a) { return a.verh < a.niz; }
    public static bool operator false(Fraction a) { return a.verh > a.niz; }
    public static bool operator <(Fraction a, Fraction b)
    {
        return (a.verh / a.niz) < (b.verh / b.niz);
    }
    public static bool operator >(Fraction a, Fraction b)
    {
        return (a.verh / a.niz) > (b.verh / b.niz);
    }


    public static Fraction operator +(Fraction a, int value)
    {
        return new Fraction(a.verh + (value * a.niz), a.niz);
    }
    public static Fraction operator -(Fraction a, int value)
    {
        return new Fraction(a.verh - (value * a.niz), a.niz);
    }
    public static Fraction operator *(Fraction a, int value)
    {
        return new Fraction(a.verh * value, a.niz);
    }
    public static Fraction operator /(Fraction a, int value)
    {
        return new Fraction(a.verh, a.niz * value);
    }
    public static bool operator ==(Fraction a, int value) { return (a.verh == value && a.niz == 1); }
    public static bool operator !=(Fraction a, int value) { return (a.verh != value || a.niz != 1); }
    public static bool operator <(Fraction a, int value)
    {
        return (a.verh / a.niz) < (value / 1);
    }
    public static bool operator >(Fraction a, int value)
    {
        return (a.verh / a.niz) > (value / 1);
    }
}
class Point
{
    public int x;
    public int y;

    public Point (int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    Point():this(0,0) { }

    public static Point operator +(Point a, Point b) { return new Point(a.x + b.x, a.y + b.y); }
    public static Point operator +(Point a, int value) { return new Point(a.x + value, a.y + value); }
    public static Point operator +(Point a, double value) { return a + (int)value; }
    public static bool operator ==(Point a, Point b) { return (a.x == b.x && a.y == b.y);  }
    public static bool operator !=(Point a, Point b) { return !(a == b); }
    public static bool operator true(Point a) { return a.x != 0 || a.y != 0; }
    public static bool operator false(Point a) { return a.x == 0 && a.y == 0; }
}
class Program
{
    static void Main(string[] args)
    {
        /*
        Point point1 = new Point(1, 3); Console.WriteLine($"point 1 ({point1.x},{point1.y})");
        Point point2 = new Point(1, 4); Console.WriteLine($"point 2 ({point2.x},{point2.y})");
        Point point3 = point1 + point2; Console.WriteLine($"point 3 ({point3.x},{point3.y})");
        Point point4 = point2 + 4; Console.WriteLine($"point 4 ({point4.x},{point4.y})");
        if (point1 != point2) Console.WriteLine("false");
        else Console.WriteLine("true");
        */
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Fraction a = new Fraction(1, 3);
        Fraction b = new Fraction(1, 3);
        Fraction c = a + b;
        Console.WriteLine($"{c.verh}/{c.niz}");
        Fraction d = a - b;
        Console.WriteLine($"{d.verh}/{d.niz}");
        Fraction e = a * b;
        Console.WriteLine($"{e.verh}/{e.niz}");
        Fraction f = a / b;
        Console.WriteLine($"{f.verh}/{f.niz}");
        if (a == b) { Console.WriteLine("DROBI ОДНАКОВІ"); }
        else if (a != b) { Console.WriteLine("DROBI НЕ ОДНАКОВІ"); }
        if (a < b) { Console.WriteLine($"{a.verh}/{a.niz} < {b.verh}/{b.niz}"); }
        else { Console.WriteLine($"{a.verh}/{a.niz} > {b.verh}/{b.niz}"); }
        c = a + 3;
        Console.WriteLine($"{c.verh}/{c.niz}");
        d = a - 3;
        Console.WriteLine($"{d.verh}/{d.niz}");
        e = a * 3;
        Console.WriteLine($"{e.verh}/{e.niz}");
        f = a / 1;
        Console.WriteLine($"{f.verh}/{f.niz}");
    }
}
