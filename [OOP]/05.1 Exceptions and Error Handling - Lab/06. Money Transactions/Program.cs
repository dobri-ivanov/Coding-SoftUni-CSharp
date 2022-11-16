using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();
            string[] inputTokens = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputTokens.Length; i++)
            {
                int accountNumber = int.Parse(inputTokens[i].Split("-", StringSplitOptions.RemoveEmptyEntries).First());
                double accountValue = double.Parse(inputTokens[i].Split("-", StringSplitOptions.RemoveEmptyEntries).Skip(1).First());
                bankAccounts.Add(accountNumber, accountValue);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int accountNum = int.Parse(tokens[1]);
                double accountVal = double.Parse(tokens[2]);

                try
                {
                    if (command == "Deposit")
                    {
                        bankAccounts[accountNum] += accountVal;
                        Console.WriteLine($"Account {accountNum} has new balance: {bankAccounts[accountNum]:f2}");
                    }
                    else if (command == "Withdraw")
                    {
                        if (accountVal > bankAccounts[accountNum])
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }
                        bankAccounts[accountNum] -= accountVal;
                        Console.WriteLine($"Account {accountNum} has new balance: {bankAccounts[accountNum]:f2}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid command!");
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Enter another command");
            }
        }
    }
}
