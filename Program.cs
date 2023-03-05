using System;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0; // вхідне значення х
            double y = Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - 5 * x + 9 + Math.Cos(x); // розрахунок значення y

            Console.WriteLine($"y = {y}"); // виведення результату на консоль
        }
    }
}