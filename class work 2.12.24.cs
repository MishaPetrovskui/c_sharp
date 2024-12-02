using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading
using Game;



class Proggram
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Character player1 = new Character("ANTON", 1, 100, 10);
        player1.print();
        Console.WriteLine("\n");
        Character player2 = new Character("DIMON", 1, 10, 100);
        player2.print();

        while (true)
        {

        }

        player1.attack(player2);
        Console.WriteLine("\n");
        player1.print();
        Console.WriteLine("\n");
        player2.print();
    }
}

// DRUGOE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
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

        public int takeDamage(int damage )
        {
            this.health = Math.Max(this.health - damage, 0);
            return this.health;
        }

        public void attack(Character target)
        {
            target.takeDamage(this.damage);
        }
    }
}
