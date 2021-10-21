using System;

namespace Bank
{
    class Program
    {
        static string InsertCard()
        {
            Console.WriteLine("Insert card(number):");
            string cardNumber = Console.ReadLine();

            return cardNumber;
        }
         static double CardValidation(string receivedCardNumber)
        {
            bool checkCard = false;
            bool checkPIN = false;
            double currentSold = double.MinValue;

            foreach (string line in System.IO.File.ReadLines(@"G:\work\Target Practice\Bank\Bank\Carduri.txt"))
            {
                if (checkPIN)
                {
                    Console.Clear();

                    currentSold = double.Parse(line);

                    Console.WriteLine($"Your account sold is:{currentSold}$");

                    break;
                }
                else if(checkCard)
                {
                    Console.Clear();

                    Console.WriteLine("Insert PIN:");
                    int PIN = int.Parse(Console.ReadLine());

                    if (line == PIN.ToString())
                    {
                        checkPIN = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorect password");
                    }
                }
                else if( line ==  receivedCardNumber)
                {
                    checkCard = true;
                }
                
            }

            if(currentSold == double.MinValue)
            {
                Console.WriteLine("Unknown card");
            }

            return currentSold;

        }

        static double Deposit(double currentSold)
        {
            Console.Clear();
            Console.WriteLine("How much boss?");

            double deposit = double.Parse(Console.ReadLine());

            if(deposit <= 500)
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
            
            if(withdraw >300)
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

        static void Menu()
        {
            Console.WriteLine("1) Check Sold");
            Console.WriteLine("2) Deposit");
            Console.WriteLine("3) Withdraw");
            Console.WriteLine("4) Exit");
        }

        static void Play(double localSold)
        {
            bool temp = true;

            while(temp)
            {
                Menu();

                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine(localSold);
                        break;

                    case 2:
                        Deposit(localSold);
                        break;

                    case 3:
                        Withdraw(localSold);
                        break;

                    case 4:
                        InsertCard();
                        break;

                }

                
            }
        }
        
        static void Main(string[] args)
        {
            string cardNumber = InsertCard();
            double sold;

            sold = CardValidation(cardNumber);

            Play(sold);


        }
    }
}
