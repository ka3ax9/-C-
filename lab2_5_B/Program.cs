using System;

namespace lab2_3_В
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input for array size
            int n = 0;
            while (n <= 0)
            {
                Console.Write("Enter array size: ");
                if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }

            // Fill array with random values
            int[] arr = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-100, 101);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            // Calculate sum of elements before last positive element
            int sum = 0;
            int lastPositiveIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    lastPositiveIndex = i;
                }
            }

            if (lastPositiveIndex < 0)
            {
                Console.WriteLine("No positive elements found.");
            }
            else if (lastPositiveIndex == 0)
            {
                Console.WriteLine("The first element is positive. The sum before the last positive element is zero.");
            }
            else
            {
                for (int i = 0; i < lastPositiveIndex; i++)
                {
                    sum += arr[i];
                }
                Console.WriteLine("Sum of elements before last positive element: " + sum);
            }

            // Calculate product of positive elements
            int product = 1;
            bool positiveFound = false;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    positiveFound = true;
                    product *= arr[i];
                }
            }

            if (!positiveFound)
            {
                Console.WriteLine("No positive elements found. Product is 0.");
            }
            else
            {
                Console.WriteLine("Product of positive elements: " + product);
            }

            Console.ReadLine();
        }
    }
}
