using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Character
{
    string? name;
    int health;
    int damage;
    int defence;

    public Character(string? _name, int _health, int _damage, int _defence)
    {
        this.name = _name;
        this.health = _health;
        this.damage = _damage;
        this.defence = _defence;
    }

    public void print()
    {
        Console.WriteLine($"-< {name} >-");
        Console.WriteLine($"Health: {health}");
        Console.WriteLine($"Damage: {damage}");
        Console.WriteLine($"Defence: {defence}");
    }
}

class Proggram
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Character player1 = new Character("FAKOOR", 100, -100, -1000);
        player1.print();
        Console.WriteLine($"POPADANIE");
    }
}
