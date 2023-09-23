using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of cards: ");
            int numberOfCards;
            while(!int.TryParse(Console.ReadLine(), out numberOfCards))
            {
                Console.Write("Please, enter the number: ");
            }
            int totalSum = 0;
            for (int i = 0; i < numberOfCards; i++)
            {
                Console.Write("Enter card value: ");
                string value = Console.ReadLine();
                int tmp;
                if (int.TryParse(value, out tmp))
                {
                    if(tmp >= 1 && tmp <= 10) { 
                        totalSum += tmp;
                    } else {
                        Console.WriteLine("Unknown card. Possible cards: [1-10, J, Q, K, A]"); --i; break; 
                    }
                } else {
                    switch (value) { 
                        case "J":
                            totalSum += 10; break;
                        case "Q":
                            totalSum += 10; break;
                        case "K":
                            totalSum += 10; break;
                        case "A":
                            totalSum += 10; break;
                        default:
                            Console.WriteLine("Unknown card. Possible cards: [1-10, J, Q, K, A]"); --i; break;
                    }
                }
            }
            Console.WriteLine($"Total card sum: {totalSum}");
            Console.WriteLine("Press any button to exit...");
            Console.ReadKey();
        }
    }
}
