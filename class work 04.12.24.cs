using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Site;

class ConsoleApp1
{
    static void Main(string[] args)
    {
        /*
        character_for_lesson4 player = new character_for_lesson4("Cisco", "cisco.com", "this cisco", "kakoy-to");
        player.print();*/
        bank bank = new bank();
        bank.print();
        Console.WriteLine(bank.CalculateYearlyInterest());
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

namespace Web_Site
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
}
