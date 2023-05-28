using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmail
{
    class Program
    {
        static void Main()
        {
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[._-]*\w*)*@(?<host>[a-zA-Z]+?([.-][a-z]*)*(\.[a-zA-Z]{2,}))";

            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
