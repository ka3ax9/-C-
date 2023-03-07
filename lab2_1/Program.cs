using System;

namespace lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number from 1 to 7:");
            int number = int.Parse(Console.ReadLine());

            string colorName;
            switch (number)
            {
                case 1:
                    colorName = "red";
                    break;
                case 2:
                    colorName = "orange";
                    break;
                case 3:
                    colorName = "yellow";
                    break;
                case 4:
                    colorName = "green";
                    break;
                case 5:
                    colorName = "cyan";
                    break;
                case 6:
                    colorName = "blue";
                    break;
                case 7:
                    colorName = "violet";
                    break;
                default:
                    Console.WriteLine("Invalid number.");
                    return;
            }

            Console.WriteLine($"The color with serial number {number} is {colorName}.");
        }
    }
}