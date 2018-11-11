using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                return amount;
            }
            Console.WriteLine("Insufficient balance");
            return 0;
        }

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance:F2}";
        }
    }
}
