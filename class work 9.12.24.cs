using System.Text;
using System.Threading;
using CSH_P35.Game;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;
        Character player1 = new Character();
        player1.print();
        Console.WriteLine();
        // player1.Health = 100;
        player1.print();
        Console.WriteLine();


        Character player2 = new Character("Anton", 90, 8, 0, Race.Elf);
        player2.print();

        while (player1.isAlive() && player2.isAlive())
        {
            player1.attack(player2);
            player2.attack(player1);
            Thread.Sleep(1000);
        }

        Console.WriteLine("\n");
        player1.print();
        Console.WriteLine();
        player2.print();

    }
}


// другое


namespace CSH_P35.Game
{
    enum Race
    {
        Human,
        Ork,
        Elf,
        Dwarf
    }

    class Character
    {
        string? name;
        int health;
        int damage;
        int defence;
        Race race;

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
        private double GetDamageRace(Race attacker, Race defender)
        {
            if (attacker == Race.Human && defender == Race.Elf) 
                return 1.2;
            if (attacker == Race.Elf && defender == Race.Human)
                return 0.8;
            if (attacker == Race.Elf && defender == Race.Ork) 
                return 1.5;
            if (attacker == Race.Ork && defender == Race.Elf)
                return 0.7;
            if (attacker == Race.Ork && defender == Race.Dwarf) 
                return 1.3;
            if (attacker == Race.Dwarf && defender == Race.Ork)
                return 0.9;
            if (attacker == Race.Dwarf && defender == Race.Human) 
                return 1.1;
            if (attacker == Race.Human && defender == Race.Dwarf) 
                return 0.9;
            return 1.0;
        }
        public Character() : this("Jonny", 100, 5, 0, Race.Human) { }
        public Character(string? name, int health, int damage, int defence, Race race = Race.Human)
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

        public int takeDamage(int damage)
        {
            health = Math.Max(health - damage, 0);
            return health;
        }

        public void attack(Character target)
        {
            double get_race = GetDamageRace(this.race, target.race);
            int new_damage = (int) (get_race * damage);
            target.takeDamage(new_damage);
        }

        public bool isAlive()
        {
            return health > 0;
        }
    }
}
