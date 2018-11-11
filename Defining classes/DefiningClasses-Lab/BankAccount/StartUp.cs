using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                int id = int.Parse(data[1]);

                switch (command)
                {
                    case "Create":
                        if (accounts.ContainsKey(id))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            BankAccount currentAccount = new BankAccount();
                            currentAccount.Id = id;
                            accounts.Add(id, currentAccount);
                        }
                        break;
                    case "Deposit":
                        decimal value = int.Parse(data[2]);
                        if (accounts.ContainsKey(id))
                        {
                            accounts[id].Deposit(value);
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                    case "Withdraw":
                        decimal valueToWithdraw = decimal.Parse(data[2]);
                        if (accounts.ContainsKey(id))
                        {
                            accounts[id].Withdraw(valueToWithdraw);
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                    case "Print":
                        if (accounts.ContainsKey(id))
                        {
                            Console.WriteLine(accounts[id].ToString());
                        }
                        else
                        {
                            Console.WriteLine("Account does not exist");
                        }
                        break;
                }
            }
        }
    }
}
