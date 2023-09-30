using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_1
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
            int sum = 0;
            int[,] matrix = new int[rows, columns];
            for(byte row = 0; row < rows; row++)
            {
                Console.Write("|");
                for (byte column = 0; column < columns; column++)
                {
                    matrix[row, column] = random.Next(byte.MaxValue);
                    sum += matrix[row, column];
                    Console.Write($"{matrix[row, column],4}");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine($"Total sum: {sum}");
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
