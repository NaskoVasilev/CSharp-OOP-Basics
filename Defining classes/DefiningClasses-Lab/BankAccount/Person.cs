using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<BankAccount> Accounts { get; set; }

        public Person()
        {
            this.Accounts = new List<BankAccount>();
        }

        public Person(string name, int age) : this()
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts) : this(name, age)
        {
            this.Accounts.AddRange(accounts);
        }

        public decimal GetBalance()
        {
            decimal balance = 0L;

            foreach (var account in this.Accounts)
            {
                balance += account.Balance;
            }

            return balance;
        }

    }
}
