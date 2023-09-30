using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            byte rows, columns;
            Console.Write("Enter the rows number: ");
            while (!byte.TryParse(Console.ReadLine(), out rows) || rows <= 0)
            {
                Console.Write("Fail. Possible options: rows > 0. Enter the rows number: ");
            }
            Console.Write("Enter the columns number: ");
            while (!byte.TryParse(Console.ReadLine(), out columns) || columns <= 0)
            {
                Console.Write("Fail. Possible options: columns > 0. Enter the columns number: ");
            }
            int[,] matrix1 = new int[rows, columns];
            int[,] matrix2 = new int[rows, columns];
            int[,] sum = new int[rows, columns];
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    matrix1[row, column] = random.Next(byte.MaxValue);
                    matrix2[row, column] = random.Next(byte.MaxValue);
                    sum[row, column] = matrix1[row, column] + matrix2[row, column];
                }
            }
            for (int row = 0; row < rows; row++)
            {
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrix1[row, column],4}");
                }
                Console.Write("|");
                Console.Write(row == rows / 2 ? '+' : ' ');
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrix2[row, column],4}");
                }
                Console.Write("|");
                Console.Write(row == rows / 2 ? '=' : ' ');
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{sum[row, column],4}");
                }
                Console.WriteLine("|");

            }
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
