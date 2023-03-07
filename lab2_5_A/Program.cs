using System;

namespace lab2_5_A
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get input for matrix dimensions
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int m = int.Parse(Console.ReadLine());

            // Create integer matrix
            int[,] matrix = new int[n, m];

            // Get input for matrix elements
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("Enter element [{0},{1}]: ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Print original matrix
            Console.WriteLine("Original matrix:");
            PrintMatrix(matrix);

            // Swap top and lower half of matrix
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - i - 1, j];
                    matrix[n - i - 1, j] = temp;
                }
            }

            // Print modified matrix
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