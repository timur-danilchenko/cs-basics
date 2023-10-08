using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part5
{
    class User
    {
        public static int id = 0;
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDay { get; set; }
        public string BirthPlace { get; set; }

        public User() { }
        public User(string fullName, int age, int height, DateTime birthday, string birthplace)
        {
            this.Id = id++;
            this.TimeCreated = DateTime.Now;
            this.FullName = fullName;
            this.Age = age;
            this.Height = height;
            this.BirthDay = birthday;
            this.BirthPlace = birthplace;
        }

        public static User Parse(string str)
        {
            string[] info = str.Split('#');
            User user = new User();
            user.Id = int.Parse(info[0]);
            user.TimeCreated = DateTime.Parse(info[1]);
            user.FullName = info[2];
            user.Age = int.Parse(info[3]);
            user.Height = int.Parse(info[4]);
            user.BirthDay = DateTime.Parse(info[5]);
            user.BirthPlace = info[6];
            return user;
        }
        
        public void printUser()
        {
            Console.Write($"Id: {this.Id}\n" +
                $"TimeCreated: {this.TimeCreated}\n" +
                $"FullName: {this.FullName}\n" +
                $"Age: {this.Age}\n" +
                $"Heigth: {this.Height}\n" +
                $"BirthDay: {this.BirthDay.Date.ToString("MM/dd/yyyy")}\n" +
                $"BirthPlace: {this.BirthPlace}\n");
        }

        public override string ToString()
        {
            return this.Id.ToString() + "#" + this.TimeCreated.ToString() + "#" + this.FullName.ToString() + "#" + this.Age.ToString() + "#" + this.Height.ToString() + "#" + this.BirthDay.ToString().Split(' ')[0] + "#" + this.BirthPlace.ToString();
        }
    }

    internal class Program
    {
        static void PrintHelp()
        {
            Console.Write("Commands:\n" +
                "0: exit\n" +
                "1: print data\n" +
                "2: add data\n" +
                "3: help\n");
        }

        static void showDataFromFile(string filePath)
        {
            Console.WriteLine("--------------------------------------");
            if (File.ReadLines(filePath).ToArray().Length == 0) {
                Console.WriteLine("No users");
                Console.WriteLine("--------------------------------------");
                return;
            }
            foreach (string line in File.ReadLines(filePath))
            {
                User user = User.Parse(line);
                user.printUser();
                Console.WriteLine("--------------------------------------");
            }
            return;
        }

        static void addDataToFile(string filePath)
        {

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Birthday\n");
            Console.Write("Enter year: ");
            int year;
            while(!int.TryParse(Console.ReadLine(), out year) || year < 0 || year > DateTime.Now.Year)
            {
                Console.Write($"Error: Invalid year number\nPossible options: 0 - {DateTime.Now.Year}\nEnter year: ");
            }
            Console.Write("Enter month: ");
            int month;
            int possibleMonths = ((year == DateTime.Now.Year) ? DateTime.Now.Month : 12);
            while (!int.TryParse(Console.ReadLine(), out month) || month < 0 || month > possibleMonths)
            {
                Console.Write($"Error: Invalid month number\nPossible options: 0 - {possibleMonths}\nEnter month: ");
            }
            Console.Write("Enter day: ");
            int day;
            int[] daysByMonths = { 31, 28 + ((year % 4 == 0) ? 1 : 0), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            int possibleDays = (year == DateTime.Now.Year && month == DateTime.Now.Month) ? DateTime.Now.Day : daysByMonths[month];
            while(!int.TryParse(Console.ReadLine(), out day) || day < 0 || day > possibleDays)
            {
                Console.Write($"Error: Invalid day number\nPossible options: 0 - {possibleDays}\nEnter day: ");
            }
            DateTime birthday = new DateTime(year, month, day);
            Console.Write("Enter birthplace: ");
            string birthplace = Console.ReadLine();
            User user = new User(fullName, age, height, birthday, birthplace);
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(user.ToString());
            }
            return;
        }

        static void Main(string[] args)
        {
            string title = "Thesaurus";
            string filePath = System.IO.Directory.GetCurrentDirectory() + "/" + title + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            // If file exist, need to get last id
            User.id = (File.ReadAllLines(filePath).ToArray().Length != 0) ? int.Parse(File.ReadLines(filePath).Last().Split('#')[0]) + 1 : 0;
            // Boolean flag for interactive input
            bool stop = false;
            Console.WriteLine(title);
            PrintHelp();
            while (!stop)
            {
                Console.Write("Enter command number: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Incorrect input");
                    PrintHelp();
                    Console.Write("Please input one of the commands number: ");
                }
                switch (choice)
                {
                    case 0:
                        stop = true;
                        break;
                    case 1:
                        showDataFromFile(filePath);
                        break;
                    case 2:
                        addDataToFile(filePath); 
                        break;
                    case 3:
                        PrintHelp();
                        break;
                    default:
                        Console.WriteLine("Undefined behavior");
                        break;
                }

            }
        }
    }
}
