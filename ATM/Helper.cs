using System;

namespace ATM
{
    internal class Helper
    {
        public double RequestValue(String operation)
        {
            do
            {
                Console.WriteLine($"How much $$ would you like to {operation}?");
                if (double.TryParse(Console.ReadLine(), out double result)) { return result; }
                else { Console.WriteLine("Incorrent value. Please try again."); }
            } while (true);
        }
    }
}
