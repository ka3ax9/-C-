using System;
using System.IO;
using System.Text.RegularExpressions;

namespace lab3_3
{
    class Program
    {
        static void Main(string[] args)
        {
         
            string inputPath = @"C:\Users\zenka\Documents\My_input_file\input.txt";

            
            string input = File.ReadAllText(inputPath);

            
            string output = Regex.Replace(input, @"\d+", "");

            
            string outputPath = @"C:\Users\zenka\Documents\My_input_file\output.txt";

           
            File.WriteAllText(outputPath, output);
        }
    }
}
