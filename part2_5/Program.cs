using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Game: Guess the number");
            Console.WriteLine("Lower limit: 0");
            Console.Write("Enter the upper limit: ");
            int upperLimit;
            while(!int.TryParse(Console.ReadLine(), out upperLimit))
            {
                Console.Write("Fail. Possible options: limit > 0. Enter the number: ");
            }
            int hiddenNumber = random.Next(upperLimit + 1);
            Console.WriteLine($"Limits: [0, {upperLimit}]");
            Console.WriteLine("Hint: enter empty string to exit");
            Console.WriteLine("Let the fun begin!");
            while(true)
            {
                Console.Write("Enter the number: ");
                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine($"Hidden number was {hiddenNumber}");
                    break;
                }
                else
                {
                    int number;
                    if(!int.TryParse(input, out number) || number < 0 || number > upperLimit)
                    {
                        Console.Write($"Fail. Possible options: 0 <= number <= {upperLimit}");
                        continue;
                    }
                    if (number < hiddenNumber)
                    {
                        Console.WriteLine("Hidden number is greater");
                    } 
                    else if (number > hiddenNumber)
                    {
                        Console.WriteLine("Hidden number is less");
                    }
                    else
                    {
                        Console.WriteLine("Congrats, you guessed the hidden number");
                        Console.WriteLine($"Hidden number is {hiddenNumber}");
                        break;
                    }
                }
            }
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
