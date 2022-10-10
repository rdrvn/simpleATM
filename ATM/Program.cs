using ATM;
using System;
using System.Collections.Generic;

internal class CardHolder
{
    public String cardNumber { get; private set; }
    public String firstName { get; private set; }
    public String lastName { get; private set; }
    public double balance { get; private set; }
    public int pin { get; private set; }

    public CardHolder(string cardNumber, string firstName, string lastName, double balance, int pin)
    {
        this.cardNumber = cardNumber;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
        this.pin = pin;
    }

    public static void Main(String[] args)
    {
        Helper helper = new Helper();

        void printOptions()
        {
            Console.WriteLine("Please choose one of the following options....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            double deposit = helper.RequestValue("deposit");
            currentUser.balance += deposit;
            Console.WriteLine($"Thank you for your deposit. Now your balance is {currentUser.balance}. Have a great day :)");
        }

        void withdraw(CardHolder currentUser)
        {
            double withdrawal = helper.RequestValue("withdraw");
            // Check if the user has enough money
            if (currentUser.balance < withdrawal)
            {
                Console.WriteLine("Insufficient money");
            }
            else
            {
                currentUser.balance = currentUser.balance - withdrawal;
                Console.WriteLine("You're ready to go. Have a nice day :)");
            }
        }

        void checkBalance(CardHolder currentUser)
        {
            Console.WriteLine($"Your current balance is {currentUser.balance}. Have a good day :)");
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("371314223353372", "John", "Russell", 150.32, 1234));
        cardHolders.Add(new CardHolder("5203154779525129", "Michael", "Phillips", 31.2, 4321));
        cardHolders.Add(new CardHolder("4922578701875413", "Anna", "Williams", 402.21, 7890));
        cardHolders.Add(new CardHolder("3539339890912401", "James", "Young", 1242.64, 0987));

        Console.WriteLine("Welcome to simpleATM :)");
        String ?cardNumber;
        CardHolder ?currentUser;

        do
        {
            Console.Write("Please enter your card number: ");
            cardNumber = Console.ReadLine();
            currentUser = cardHolders.FirstOrDefault(ch => ch.cardNumber == cardNumber);
            if (currentUser != null) { break; }
            else { Console.WriteLine("Unknown card number. Please try again."); }
        } while (true);

        do
        {
            Console.Write("Please enter your PIN-code: ");
            
            if (int.TryParse(Console.ReadLine(), out int pinCode))
            {
                if (currentUser.pin == pinCode) { break; }
                else { Console.WriteLine("Incorrect PIN-code. Please try again."); }
            }
            else
            {
                Console.WriteLine("Invalid PIN-code. Please try again.");
            }
            
        } while (true);

        Console.WriteLine($"Welcome back, {currentUser.firstName} {currentUser.lastName}!");
        int option;

        do
        {
            printOptions();
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        deposit(currentUser);
                        break;
                    case 2:
                        withdraw(currentUser);
                        break;
                    case 3:
                        checkBalance(currentUser);
                        break;
                    case 4:
                        Console.WriteLine($"See you later, {currentUser.firstName} {currentUser.lastName}! Have a good day!");
                        break;
                    default:
                        Console.WriteLine("Incorrect option. Please choose another one.");
                        break;
                }
            }
        } while (option != 4);
    }
}