using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            double totalSum = 0.0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|%$.]*<(?<product>[\w]+)>[^|%$.]*[\w]*\|(?<count>[0-9]*)\|[A-Za-z]*(?<price>[\d]+[\.]?[0-9]*)\$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
                
                if (match.Success)
                {
                    double currPrice = 0.0;
                    currPrice = double.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value);
                    Console.WriteLine($"{match.Groups["customer"].Value}: {match.Groups["product"].Value} - {currPrice:f2}");
                    totalSum += currPrice;
                }
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
