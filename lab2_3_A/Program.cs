using System;

namespace lab2_3_A
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter the size of the array: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer: ");
            }

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the value for element {0}: ", i);
                while (!int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    Console.Write("Invalid input. Please enter an integer: ");
                }
            }

            int product = 1, sum = 0, lastPositiveIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    product *= arr[i];
                    lastPositiveIndex = i;
                }
                sum += arr[i];
            }

            if (lastPositiveIndex == -1)
            {
                Console.WriteLine("There are no positive elements in the array.");
            }
            else
            {
                Console.WriteLine("Product of positive elements: " + product);
                Console.WriteLine("Sum of elements up to the last positive element: " + sum);
            }

        }
    }
}