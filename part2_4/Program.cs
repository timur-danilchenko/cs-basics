using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;
            int number;
            Console.Write("Enter the number: ");
            while(!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.Write("Fail. Possible options: number > 0. Enter the number: ");
            }
            while(number != 0)
            {
                Console.Write("Enter the value: ");
                int value;
                while(!int.TryParse(Console.ReadLine(), out value)) {
                    Console.Write("Fail. Possible options: integer value. Enter the value: ");
                }
                if(value < min)
                {
                    min = value;
                }
                number--;
            }
            Console.WriteLine($"Minumum value is {min}");
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
