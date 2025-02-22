using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAME;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Character pl = new Character();
        Mob mob = new Mob();
    }
}



//DRUGOE




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using GAME.spells;
using System.Diagnostics;
using System.Drawing;

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
        { this.opis = opis; }
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
        public bank() : this("USER", "123456789", 50000, 5) { }
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

    interface IDamageable
    {
        int Health { get; set; }
        int takeDamage(int damage, Character from);
    }

    interface ISpellCaster
    {
        int takeDamageCast(int damage);
        void CastRandomSpell(Character target);
    }

    interface ILootable
    {
        List<string> strings { get; }
    }

    class Character : IDamageable, ISpellCaster
    {
        protected string? name;
        protected int health;
        protected int damage;
        protected int defence;
        protected Race race;
        protected Spell[] spellsList = { new Fireball(), new Waterball() };

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
        private int spells()
        {
            Random rnd = new Random(Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds()));
            return rnd.Next(0, this.spellsList.Length);
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
        public void CastRandomSpell(Character target)
        {
            int spell_index = spells();
            this.spellsList[spell_index].cast(target);
        }
        public void print_cast()
        { this.spellsList[spells()].print_spell(); }
        public void print()
        {
            Console.WriteLine($"-< {name} >-");
            Console.WriteLine($" Здоров\'я: {health}");
            Console.WriteLine($" Шкода: {damage}");
            Console.WriteLine($" Захист: {defence}");
            Console.WriteLine($" Раса: {race}");
        }

        public virtual int takeDamage(int damage, Character from)
        {
            int new_damage = (int)(GetDamageRace(this.race, from.race) * damage);
            health = Math.Max(health - new_damage, 0);
            return health;
        }

        public int takeDamageCast(int damage)
        {
            health = Math.Max(health - damage, 0);
            return health;
        }

        public int attack(IDamageable target)
        {
            return target.takeDamage(this.damage, this);
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

    class Mob : ILootable
    {
        protected string? name;
        protected int health;
        protected int defence;
        List<string> Strings;
        public Mob() : this("ValeraNePeyPivoBezNas", 10, 5) { }
        public Mob(string? name, int health, int defence) { this.name = name; this.health = health; this.defence = defence; }

        public List<string> strings { get { return Strings; } }

        public virtual int takeDamage(int damage)
        {
            int new_damage = damage;
            health = Math.Max(health - new_damage, 0);
            return health;
        }
        public bool isAlive()
        {
            return health > 0;
        }
        public void isDead(string loot)
        {
            if (!isAlive())
            {
                strings.Add(loot);
                Console.WriteLine($"Mob drop: {loot}");
            }
        }
    }

    class Berserk : Character
    {
        bool odin = true;
        public Berserk(string? name, int health, int damage, int defence, Race race = Race.Human) : base(name, health, damage, defence, race) { }
        public Berserk() : this("Jonny", 100, 5, 0, Race.Human) { }
        public override int takeDamage(int damage, Character from)
        {
            int final_damage = (int)(this.damage * this.raceAttackBonus(from.Race));
            final_damage = this.health < 50 ? (int)(final_damage * 1.5) : final_damage;
            health = Math.Max(health - final_damage, 0);
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
            return target.takeDamage(target.Damage, this);
            // return target.takeDamage(final_damage);
        }

    }

    abstract class Shape
    {
        public virtual double GetArea() { return 0; }
    }

    class Square : Shape
    {
        double side;
        public Square(double side) { this.side = side; }
        public override double GetArea() { return Math.Pow(side, 2); }
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
        public override double GetArea() { return (3.14) * (Math.Pow(r, 2)); }
        public override string ToString()
        {
            return $"Сircle(radius={this.r})";
        }
    }

    class right_triangle : Shape
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

    class Student
    {
        string? name;
        List<double>? grades;
        double avgGrade;

        public string? Name { get { return name; } set { this.name = value; } }

        public List<double> Grades { get { return grades; } }

        public Student() : this("Vasya", new double[] { }) { }

        public Student(string? name, double[] grades)
        {
            this.name = name;
            this.grades = new List<double>(grades);
            this.CountAvgGrade();
        }

        public double CountAvgGrade()
        {
            if (grades == null)
            {
                this.avgGrade = 0;
                return 0;
            }
            this.avgGrade = grades.Sum() / grades.Count;
            return this.avgGrade;
        }

        public override string ToString()
        {
            return $"{this.name} ({this.avgGrade}) - {String.Join(",", this.grades)}";
        }
    }

    class Group
    {
        string? name;
        List<Student> student;

        public string? Name { get { return name; } set { this.name = value; } }

        public List<Student> Student { get { return student; } }

        public Group() : this("Group") { }
        public Group(string? name)
        {
            this.name = name;
            this.student = new List<Student>();
        }

        public double CountTotalAvgGrade()
        {
            double sum = 0;
            foreach (Student student in this.student) { sum += student.CountAvgGrade(); }
            return sum / this.student.Count;
        }

        public override string ToString()
        {
            return $"{this.name} ({this.CountTotalAvgGrade()}): \n {String.Join("\n ", this.student)}";
        }
    }

    enum Size
    {
        Small, Medium, Large
    }

    class Pizza
    {
        string? name;
        Size pizzaSize;
        double? pizzaPrice;

        public string? Name { get { return name; } set { this.name = value; } }

        public Size Size
        {
            get { return pizzaSize; }
        }

        public double? PizzaPrice
        {
            get { return pizzaPrice; }
        }

        public Pizza() : this("None", Size.Small, 89) { }

        public Pizza(string? name, Size pizzaSize, double? pizzaPrice)
        {
            this.name = name;
            this.pizzaSize = pizzaSize;
            this.pizzaPrice = pizzaPrice;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.pizzaSize} - {this.pizzaPrice} uah";
        }
    }
    class Customer
    {
        string? name;
        int phoneNumber;
        string? addres;

        public string? Name { get { return name; } set { this.name = value; } }

        public int PhoneNumber
        {
            get { return phoneNumber; }
        }

        public string? Addres
        {
            get { return addres; }
        }

        public Customer() : this("None", 999999999, "none") { }

        public Customer(string? name, int phoneNumber, string? addres)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.addres = addres;
        }

        public override string ToString()
        {
            return $"{this.name} - +380{this.phoneNumber} - {this.addres}";
        }
    }

    class Order
    {
        Customer customer;
        List<Pizza> pizzas;
        double? totalPrice;
        int a = 0;

        public void AddPizza(Pizza pizza)
        {
            this.pizzas.Add(pizza);
            a++;
        }

        public double? CalculateTotalPrice()
        {
            double? totalPrice = 0;
            for (int i = 0; i < this.pizzas.Count; i++)
            {
                totalPrice += pizzas[i].PizzaPrice;
            }
            this.totalPrice = totalPrice;
            return this.totalPrice;
        }

        public override string ToString()
        {
            return $"{String.Join("\n", this.customer)} \n{String.Join("\n", this.pizzas)} \n{this.CalculateTotalPrice}";
        }
    }
}



//DRUGOE ESHE



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GAME.spells
{
    abstract class Spell
    {
        string? name;
        string? Name { get { return name; } }
        public abstract void cast(ISpellCaster target);
        public abstract void print_spell();
    }
    class Fireball : Spell
    {
        string? name = "Fire ball";
        int damage = 13;
        public override void cast(ISpellCaster target)
        {
            target.takeDamageCast(this.damage);
        }
        public override void print_spell()
        {
            Console.Write("Fire ball");
        }
    }
    class Waterball : Spell
    {
        string? name = "Water ball";
        int damage = 10;
        public override void cast(ISpellCaster target)
        {
            target.takeDamageCast(this.damage);
        }
        public override void print_spell()
        {
            Console.Write("Water ball");
        }
    }
    class Death : Spell
    {
        string? name = "Death ball";
        int damage = 1000000000;
        public override void cast(ISpellCaster target)
        {
            target.takeDamageCast(this.damage);
        }
        public override void print_spell()
        {
            Console.Write("Death ball");
        }
    }
}
