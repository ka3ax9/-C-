using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        // Читання тексту з вхідного файлу
        string inputText = File.ReadAllText(inputFileName);

        // Видалення слів, що містять латинські літери
        string textWithoutLatinWords = RemoveLatinWords(inputText);

        // Видалення чисел з тексту
        string textWithoutNumbers = RemoveNumbers(textWithoutLatinWords);

        // Запис результату в вихідний файл
        File.WriteAllText(outputFileName, textWithoutNumbers);

        Console.WriteLine("Результати були записані у файл {0}.", outputFileName);
    }

    static string RemoveLatinWords(string inputText)
    {
        // Використовуємо регулярний вираз для знаходження слів, що містять латинські літери
        string pattern = @"\b\w*[a-zA-Z]+\w*\b";
        string textWithoutLatinWords = Regex.Replace(inputText, pattern, string.Empty);

        return textWithoutLatinWords;
    }

    static string RemoveNumbers(string inputText)
    {
        // Використовуємо регулярний вираз для знаходження чисел
        string pattern = @"\b\d+\b";
        string textWithoutNumbers = Regex.Replace(inputText, pattern, string.Empty);

        return textWithoutNumbers;
    }
}
