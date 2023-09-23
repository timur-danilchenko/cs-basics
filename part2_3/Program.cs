using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.Write("Fail. Possible options: number >= 0. Enter correct number: ");
            }
            bool isPrime = true;
            for(int i = 2; i * i <= number && isPrime; i++)
            {
                if(number % i == 0)
                {
                    isPrime = false;
                }
            }
            Console.WriteLine($"Number is prime: {isPrime}");
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
