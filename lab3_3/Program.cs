using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the full path to the input file
            string inputPath = @"C:\Users\zenka\Documents\My_input_file\input.txt";

            // Read input from file
            string input = File.ReadAllText(inputPath);

            // Remove all numbers from text
            string output = Regex.Replace(input, @"\d+", "");

            // Set the full path to the output file
            string outputPath = @"C:\Users\zenka\Documents\My_input_file\output.txt";

            // Write output to file
            File.WriteAllText(outputPath, output);
        }
    }
}