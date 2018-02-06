using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab12_RockPaperScissors
{
    public static class Validator
    {
        public static ConsoleKey YesOrNo(string message)
        {
            Console.WriteLine(message);
            ConsoleKey input = Console.ReadKey().Key;
            while(input != ConsoleKey.Y && input != ConsoleKey.N)
            {
                Console.WriteLine($"Invalid input,\n{message}");
                input = Console.ReadKey().Key;
            }
            return input;
        }

        public static ConsoleKey OneorTwo(string message)
        {
            Console.WriteLine(message);
            ConsoleKey input = Console.ReadKey().Key;
            while (input != ConsoleKey.D1 && input != ConsoleKey.NumPad1 &&
                input != ConsoleKey.D2 && input != ConsoleKey.NumPad2)
            {
                Console.WriteLine($"Invalid input, {message}");
                input = Console.ReadKey().Key;
            }
            return input;
        }

        public static Roshambo CheckIsRoshambo(string message)
        {
            Console.WriteLine(message);
            Roshambo value;
            while(!Enum.TryParse(Console.ReadLine().ToLower(), out value) || !Enum.IsDefined(typeof(Roshambo), value))
            {
                Console.WriteLine($"Invalid input, {message}");
            }
            return value;
        }

        public static string CheckName(string message)
        {
            Console.WriteLine(message);
            Regex pattern = new Regex(@"^+");
            string input = Console.ReadLine();
            while (!pattern.IsMatch(input))
            {
                Console.WriteLine($"Invalid input, {message}");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
