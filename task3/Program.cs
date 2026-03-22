using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {         
        var accounts = new Accounts();
        var acc1 = new BankAccount("1", 1000);
        var acc2 = new BankAccount("2", 500);
        var acc3 = new BankAccount("3", 200);
        accounts.AddAccount(acc1);
        accounts.AddAccount(acc2);
        accounts.AddAccount(acc3);
        Console.WriteLine("Commands:\n help\n addaccount <number> <initialBalance>\n removeaccount <number>\n deposit <number> <amount>\n withdraw <number> <amount>\n transfer <source> <target> <amount>\n transactions <number>\n getallaccounts\n exit");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string cmd = parts[0].ToLower();

            try
            {
                switch (cmd)
                {
                    case "addaccount":
                        accounts.AddAccount(new BankAccount(parts[1], decimal.Parse(parts[2])));
                        Console.WriteLine("Added."); break;

                    case "removeaccount":
                        Console.WriteLine(accounts.RemoveAccount(parts[1]) ? "Removed." : "Not found."); break;

                    case "deposit":
                        accounts[parts[1]]?.Deposit(decimal.Parse(parts[2]));
                        Console.WriteLine("Deposited."); break;

                    case "withdraw":
                        accounts[parts[1]]?.Withdraw(decimal.Parse(parts[2]));
                        Console.WriteLine("Withdrawn."); break;

                    case "transfer":
                        accounts[parts[1]]?.Transfer(accounts[parts[2]], decimal.Parse(parts[3]));
                        Console.WriteLine("Transferred."); break;

                    case "transactions":
                        Console.WriteLine(accounts.GetTransactionsString(parts[1])); break;
                    case "getallaccounts":
                        foreach (var acc in accounts.GetAllAccounts())
                        {
                            Console.WriteLine($"Account: {acc.AccountNumber}, Balance: {acc.Balance}");
                        }
                        break;
                    case "help":
                        Console.WriteLine("Commands:\n help\n addaccount <number> <initialBalance>\n removeaccount <number>\n deposit <number> <amount>\n withdraw <number> <amount>\n transfer <source> <target> <amount>\n transactions <number>\n getallaccounts\n exit");
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Unknown command"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        }
    }
}
