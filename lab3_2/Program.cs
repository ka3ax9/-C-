using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Введення кількості елементів файлу
        Console.Write("Введіть кількість елементів файлу: ");
        int n = int.Parse(Console.ReadLine());

        // Введення елементів файлу з клавіатури та запис у файл
        Console.WriteLine("Введіть елементи файлу:");
        using (StreamWriter writer = new StreamWriter("file.txt"))
        {
            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                writer.WriteLine(element);
            }
        }

        // Введення числа n
        Console.Write("Введіть число n: ");
        double nValue = double.Parse(Console.ReadLine());

        // Підрахунок кількості елементів файлу, більших за n
        int count = 0;
        using (StreamReader reader = new StreamReader("file.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                double element = double.Parse(line);
                if (element > nValue)
                {
                    count++;
                }
            }
        }

        // Виведення результату
        Console.WriteLine("Кількість елементів файлу, більших за {0}: {1}", nValue, count);
    }
}
