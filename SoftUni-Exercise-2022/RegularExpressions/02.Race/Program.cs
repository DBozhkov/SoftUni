using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contestants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = string.Empty;
            Dictionary<string, int> dict = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end of race")
            {
                string firstPattern = @"(?<name>[A-Za-z]*)";
                string secondPattern = @"(?<distance>\d)";
                Regex regexFirst = new Regex(firstPattern);
                Regex regexSecond = new Regex(secondPattern);

                MatchCollection firstMatches = regexFirst.Matches(input);
                string name = string.Empty;
                foreach (Match match in firstMatches)
                {
                    name += match;
                }

                MatchCollection secondMatches = regexSecond.Matches(input);
                int sum = 0;
                foreach (Match match in secondMatches)
                {
                    sum += int.Parse(match.Value);
                }

                if (contestants.Contains(name))
                {
                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, sum);
                    }
                    else
                    {
                        dict[name] += sum;
                    }
                }
            }


            dict= dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<string> final = new List<string>();

            foreach (var item in dict)
            {
                final.Add(item.Key);
            }

            Console.WriteLine($"1st place: {final[0]}");
            Console.WriteLine($"2nd place: {final[1]}");
            Console.WriteLine($"3rd place: {final[2]}");
        }
    }
}
