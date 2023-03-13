using System;
using System.IO;

namespace lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for filename and open file for writing
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            StreamWriter writer = new StreamWriter(filename);

            // Prompt user for number of elements to write to file and write them to file
            Console.Write("Enter number of elements: ");
            int numElements = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter real numbers:");
            for (int i = 0; i < numElements; i++)
            {
                double num = double.Parse(Console.ReadLine());
                writer.WriteLine(num);
            }
            writer.Close();

            // Prompt user for value to compare against
            Console.Write("Enter value to compare against: ");
            double n = double.Parse(Console.ReadLine());

            // Open file for reading and count number of elements greater than n
            StreamReader reader = new StreamReader(filename);
            int count = 0;
            while (!reader.EndOfStream)
            {
                double num = double.Parse(reader.ReadLine());
                if (num > n)
                {
                    count++;
                }
            }
            reader.Close();

            // Display result to user
            Console.WriteLine($"Number of elements greater than {n}: {count}");
        }
    }
}