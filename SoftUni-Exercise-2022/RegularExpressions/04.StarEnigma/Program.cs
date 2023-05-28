using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            int attacked = 0;
            int destroyed = 0;

            for (int i = 0; i < counter; i++)
            {
                string firstInput = Console.ReadLine();
                string finalInput = string.Empty;
                int code = 0;
                Regex regex = new Regex(@"@(?<planetName>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attack>[Aa|Dd])![^@\-!:>]*->(?<soldierCount>\d+)");

                for (int j = 0; j < firstInput.Length; j++)
                {
                    if (firstInput[j] == 's' || firstInput[j] == 't' || firstInput[j] == 'a' || firstInput[j] == 'r'
                        || firstInput[j] == 'S' || firstInput[j] == 'T' || firstInput[j] == 'A' || firstInput[j] == 'R')
                    {
                        code++;
                    }
                }
                for (int k = 0; k < firstInput.Length; k++)
                {
                    finalInput += (char)(firstInput[k] - code);
                }

                Match match = regex.Match(finalInput);
                if (match.Success)
                {
                    if (char.Parse(match.Groups["attack"].Value) == 'A' || char.Parse(match.Groups["attack"].Value) == 'a')
                    {
                        if (!attackedPlanets.Contains(match.Groups["planetName"].Value))
                        {
                            attacked++;
                            attackedPlanets.Add(match.Groups["planetName"].Value);
                        }    
                    }
                    else if (char.Parse(match.Groups["attack"].Value) == 'D' || char.Parse(match.Groups["attack"].Value) == 'd')
                    {
                        if (!destroyedPlanets.Contains(match.Groups["planetName"].Value))
                        {
                            destroyed++;
                            destroyedPlanets.Add(match.Groups["planetName"].Value);
                        }
                    }
                }
            }
            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();

            if (attacked <= 0)
            {
                Console.WriteLine("Attacked planets: 0");
            }
            else
            {
                Console.WriteLine($"Attacked planets: {attacked}");
                Console.WriteLine($"-> {string.Join("\n-> ", attackedPlanets)}");
            }
            if (destroyed <= 0)
            {
                Console.WriteLine("Destroyed planets: 0");
            }
            else
            {
                Console.WriteLine($"Destroyed planets: {destroyed}");
                Console.WriteLine($"-> {string.Join($"\n-> ", destroyedPlanets)}");
            }
        }
    }
}
