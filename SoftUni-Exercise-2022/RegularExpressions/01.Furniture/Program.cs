using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<string> list = new List<string>();
            double sum = 0.0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    list.Add(match.Groups["furniture"].Value);
                    sum += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                }
            }
            Console.WriteLine("Bought furniture:");
            if (sum > 0)
            {
                Console.WriteLine(string.Join("\n", list).Trim());
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
