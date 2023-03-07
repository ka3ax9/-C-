using System;

namespace lab2_3_B
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
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-100, 101);
                Console.Write(arr[i] + "\t");
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
                Console.WriteLine("\nProduct of positive elements: " + product);
                Console.WriteLine("Sum of elements up to the last positive element: " + sum);
            }
        }
    }
}