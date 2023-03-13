using System;

namespace lab3_1_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsUpper(text[i]))
                {
                    count++;
                }
            }

            Console.WriteLine("Count big words: {0}", count);
            Console.ReadKey();
        }
    }
}
