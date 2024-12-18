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

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    Point() : this(0, 0) { }

    public static Point operator +(Point a, Point b) { return new Point(a.x + b.x, a.y + b.y); }
    public static Point operator +(Point a, int value) { return new Point(a.x + value, a.y + value); }
    public static Point operator +(Point a, double value) { return a + (int)value; }
    public static bool operator ==(Point a, Point b) { return (a.x == b.x && a.y == b.y); }
    public static bool operator !=(Point a, Point b) { return !(a == b); }
    public static bool operator true(Point a) { return a.x != 0 || a.y != 0; }
    public static bool operator false(Point a) { return a.x == 0 && a.y == 0; }
}
class Program
{
    static void ShowAttackMessage(Character attacker, Character target, int damage)
    {
        bool odin = true, dwa = true;
        Console.WriteLine($"{attacker.Name} attacked {target.Name} and damage {damage}");
        if (odin)
            if (attacker.Health == 1)
            {
                Console.WriteLine($"{attacker.Name} used last chanse");
                odin = false;
            }
        if (dwa)
            if (target.Health == 1)
            {
                Console.WriteLine($"{target.Name} used last chanse");
                dwa = false;
            }
        Console.WriteLine($"At {target.Name} lishilos {target.Health} health");
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Berserk player1 = new Berserk("ANTON", 40, 15, 4, Race.Ork);
        player1.print();
        Console.WriteLine("\n");
        Character player2 = new Character("DIMON", 150, 15, 4, Race.Human);
        player2.print();
        bool odin = true;
        bool dva = true;
        while (player1.isAlive() && player2.isAlive())
        {
            Console.WriteLine();
            int pl1Damage = player1.attack(player2);
            ShowAttackMessage(player1, player2, pl1Damage);
            int pl2Damage = player2.attack(player1);
            ShowAttackMessage(player2, player1, pl2Damage);
            
            
            
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GAME
{
    class character_for_lesson4
    {
        string name;
        string way_for_site;
        string opis;
        string ip_adres;
        public string getName()
        {
            return name;
        }
        public string getWayForSite()
        {
            return way_for_site;
        }
        public string getOpis()
        {
            return opis;
        }
        public string getIP()
        { return ip_adres; }
        public void setIP(string ip)
        {
            this.ip_adres = ip;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setWayForSite(string way_for_site)
        {
            this.way_for_site = way_for_site;
        }
        public void setOpis(string opis)
        { this.opis = opis;}
        public character_for_lesson4(string? _name, string? _way_for_site, string? _opis, string? _ip_adres)
        {
            this.name = _name;
            this.way_for_site = _way_for_site;
            this.opis = _opis;
            this.ip_adres = _ip_adres;
        }
        public void print()
        {
            Console.WriteLine($"-< {name} >-");
            Console.WriteLine($"way_for_site: {way_for_site}");
            Console.WriteLine($"opis: {opis}");
            Console.WriteLine($"ip_adres: {ip_adres}");
        }

    }

    class bank
    {
        public string AccountHolder;
        public string AccountNumber;
        public double Balance;
        public double InterestRate;
        public bank(string? AccountHolder, string? AccountNumber, double Balance, double InterestRate)
        {
            this.AccountHolder = AccountHolder;
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
            this.InterestRate = InterestRate;
        }
        public bank(): this("USER", "123456789", 50000, 5) { }
        public string getAccountHolder() => this.AccountHolder;
        public string getAccountNumber() => this.AccountNumber;
        public double getBalance() => this.Balance;
        public double getInterestRate() => this.InterestRate;

        public string setAccountHolder(string str) => this.AccountHolder = str;
        public string setAccountNumber(string str) => this.AccountNumber = str;
        public double setBalance(double num) => this.Balance = num;
        public double setInterestRate(double num) => this.InterestRate = num;

        public void Deposit(double amount)
        { this.Balance += amount; }
        public bool Withdraw(double amount)
        {
            if (this.Balance > amount)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
        public double CalculateYearlyInterest()
        { 
            return this.Balance * (InterestRate / 100); 
        }
        public void print()
        {
            Console.WriteLine($"-< {AccountHolder} >-");
            Console.WriteLine($"AccountNumber: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"InterestRate: {InterestRate}");
        }
    }
    enum Race
    {
        Human,
        Ork,
        Elf,
        Dwarf
    }

    class Character
    {
        protected string? name;
        protected int health;
        protected int damage;
        protected int defence;
        protected Race race;

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = Math.Max(value, 0); }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }
        public Race Race
        {
            get { return race; }
            set { race = value; }
        }
        private double GetDamageRace(Race attacker, Race defender)
        {
            if (attacker == Race.Human && defender == Race.Elf) return 1.2;
            if (attacker == Race.Elf && defender == Race.Human) return 0.8;
            if (attacker == Race.Elf && defender == Race.Ork) return 1.5;
            if (attacker == Race.Ork && defender == Race.Elf) return 0.7;
            if (attacker == Race.Ork && defender == Race.Dwarf) return 1.3;
            if (attacker == Race.Dwarf && defender == Race.Ork) return 0.9;
            if (attacker == Race.Dwarf && defender == Race.Human) return 1.1;
            if (attacker == Race.Human && defender == Race.Dwarf) return 0.9;
            return 1.0;
        }
        public Character() : this("Jonny", 100, 5, 0, Race.Human) { }
        public Character(string? name, int health, int damage, int defence, Race race)
        {
            this.name = name;
            Health = health;
            this.damage = damage;
            this.defence = defence;
            this.race = race;
        }
        public void print()
        {
            Console.WriteLine($"-< {name} >-");
            Console.WriteLine($" Здоров\'я: {health}");
            Console.WriteLine($" Шкода: {damage}");
            Console.WriteLine($" Захист: {defence}");
            Console.WriteLine($" Раса: {race}");
        }

        public virtual int takeDamage(int damage)
        {
            health = Math.Max(health - damage, 0);
            return health;
        }

        public int attack(Character target)
        {
            int new_damage = (int)(GetDamageRace(this.race, target.race) * damage);
            return target.takeDamage(new_damage);
        }

        public bool isAlive()
        {
            return health > 0;
        }
        public double raceAttackBonus(Race targetRace)
        {
            if (targetRace == this.race) return 1;
            else if (targetRace == Race.Ork) return 0.9;
            else return 1.1;
        }
    }

    class Berserk: Character
    {
        bool odin = true;
        public Berserk(string? name, int health, int damage, int defence, Race race = Race.Human): base(name, health, damage, defence, race) { }
        public Berserk() : this("Jonny", 100, 5, 0, Race.Human) { }
        public override int takeDamage(int damage)
        {
            health = Math.Max(health - damage, 0);
            if (this.health <= 0)
            {
                if (odin)
                {
                    this.health += 1;
                    odin = false;
                }
            }
            return health;
        }
        public new int attack(Character target)
        {
            int final_damage = (int)(this.damage * this.raceAttackBonus(target.Race));
            final_damage = this.health < 50 ? (int)(final_damage * 1.5) : final_damage;
            return target.takeDamage(final_damage);
            // return target.takeDamage(final_damage);
        }
        
    }
}