using System;

namespace lab3_1_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();

            // Розділяємо текст на слова
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Знаходимо мінімальну кількість літер серед усіх слів
            int minLetters = int.MaxValue;
            foreach (string word in words)
            {
                if (word.Length < minLetters)
                {
                    minLetters = word.Length;
                }
            }

            Console.WriteLine("Words with the minimum number of letters:");

            // Виводимо на екран всі слова, які мають мінімальну кількість літер
            foreach (string word in words)
            {
                if (word.Length == minLetters)
                {
                    Console.WriteLine(word);
                }
            }

            Console.ReadKey();
        }
    }
}
