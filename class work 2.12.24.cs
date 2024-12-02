using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Game;



class Proggram
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Character player1 = new Character("ANTON", 90, 15, 4);
        player1.print();
        Console.WriteLine("\n");
        Character player2 = new Character("DIMON", 90, 15, 4);
        player2.print();

        while (true)
        {
            if (player1.attack(player2) <= 0) break;
            if (player2.attack(player1) <= 0) break;


            Thread.Sleep(3000);
        }
    }
}








//drugoe

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

        public int takeDamage(int damage)
        {
            this.health = Math.Max(this.health - damage, 0);
            return this.health;
        }

        public int attack(Character target)
        {
            int dmg = target.takeDamage(this.damage);
            Console.WriteLine($"{this.name} атакував {target.name} і наніс {this.damage} одиниць шкоди.\nУ {target.name} залишилося {target.health} здоров`я.");
            if (dmg <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{this.name} переміг {target.name}");
                Console.ForegroundColor= ConsoleColor.Gray;
            }
            return dmg;
        }
    }
}
