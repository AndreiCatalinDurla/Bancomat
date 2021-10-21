using System;
using System.IO;
using System.Linq;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string cardNumber = ReadCardNumber();
            double sold = AuthenticateAndReturnSold(cardNumber);
            if (sold == double.MinValue)
            {

            }
            else
            {
                Play(sold);
            }
        }

        static string ReadCardNumber()
        {
            Console.WriteLine("Insert card(number):");
            return Console.ReadLine();
        }

        static string ReadPin()
        {
            Console.WriteLine("Insert pin:");
            return Console.ReadLine();
        }

        static double AuthenticateAndReturnSold(string cardNumber)
        {
            var lines = File.ReadLines(@"G:\work\Target Practice\Bank\Bank\Carduri.txt").ToList();
            for (int idx = 0; idx < lines.Count / 3; idx++)
            {
                if (lines[idx] == cardNumber)
                {
                    var pin = ReadPin();
                    if (lines[idx + 1] == pin)
                    {
                        return double.Parse(lines[idx + 2]);
                    }
                    else
                    {
                        Console.WriteLine("Incorect password");
                    }
                }
                else
                {
                    Console.WriteLine("Unknown card");
                }
            }
            return double.MinValue;
        }

        static double Deposit(double currentSold)
        {
            Console.Clear();
            Console.WriteLine("How much boss?");

            double deposit = double.Parse(Console.ReadLine());

            if (deposit <= 500)
            {
                currentSold += deposit;

                Console.WriteLine($"Your new sold is: {currentSold}");
            }
            else
            {
                Console.WriteLine("Too much boss");
            }
            return currentSold;
        }

        static double Withdraw(double currentsold)
        {
            Console.Clear();
            Console.WriteLine("How much boss?");

            double withdraw = double.Parse(Console.ReadLine());

            if (withdraw > 300)
            {
                Console.WriteLine("Too much boss");
            }
            else
            {
                currentsold -= withdraw;

                Console.WriteLine($"Your new sold is:{currentsold}");
            }

            return currentsold;
        }

        static void PrintMenu()
        {
            Console.WriteLine("1) Check Sold");
            Console.WriteLine("2) Deposit");
            Console.WriteLine("3) Withdraw");
            Console.WriteLine("4) Exit");
        }

        static void Play(double localSold)
        {
            while (true)
            {
                PrintMenu();

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(localSold);
                        break;

                    case 2:
                        localSold = Deposit(localSold);
                        break;

                    case 3:
                        localSold = Withdraw(localSold);
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
