using System;

namespace lab2_5_B
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int m = int.Parse(Console.ReadLine());

           
            int[,] matrix = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                }
            }

            
            Console.WriteLine("Original matrix:");
            PrintMatrix(matrix);

            
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - i - 1, j];
                    matrix[n - i - 1, j] = temp;
                }
            }

           
            Console.WriteLine("Modified matrix:");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}