using System;

namespace lab1_2
{
    public class Program
    {
        static public double Example(double x)
        {

            double y = Math.Pow(x, 3) - 4 * Math.Pow(x, 2) - 5 * x + 9 + Math.Cos(x);
            Console.WriteLine(x.ToString() + "^3 - 4 * " + x.ToString() + "^2 - 5 * " + x.ToString() + " + 9 + cos(" + x.ToString() + ")" + " = " + y.ToString());
            return y;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x:");

            double x = double.Parse(Console.ReadLine());
            Example(x);

           
        }
    }
}
