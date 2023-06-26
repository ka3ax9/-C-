using System;

class Program
{
    static void Main()
    {
        // Введення текстового рядка з клавіатури
        Console.WriteLine("Введіть текстовий рядок:");
        string text = Console.ReadLine();

        // Підрахунок кількості великих літер у тексті
        int uppercaseCount = 0;
        foreach (char c in text)
        {
            if (char.IsUpper(c))
            {
                uppercaseCount++;
            }
        }
        Console.WriteLine("Кількість великих літер у тексті: {0}", uppercaseCount);

        // Знаходження слів з найменшою кількістю літер
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int minWordLength = int.MaxValue;
        foreach (string word in words)
        {
            if (word.Length < minWordLength)
            {
                minWordLength = word.Length;
            }
        }
        Console.WriteLine("Слова з найменшою кількістю літер:");
        foreach (string word in words)
        {
            if (word.Length == minWordLength)
            {
                Console.WriteLine(word);
            }
        }
    }
}
