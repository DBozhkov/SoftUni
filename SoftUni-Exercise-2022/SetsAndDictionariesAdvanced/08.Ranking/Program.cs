using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>(Contests());
            Dictionary<string, Dictionary<string, int>> candidates = Candidates(contests);

            string bestCandidate = string.Empty;
            int bestPoints = 0;
            int currSum = 0;
            foreach (var users in candidates)
            {
                foreach (var candt in users.Value)
                {
                    currSum += candt.Value;
                }
                if (currSum > bestPoints)
                {
                    bestPoints = currSum;
                    currSum = 0;
                    bestCandidate = users.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            candidates = candidates.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value));
            foreach (var item in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        static Dictionary<string, string> Contests()
        {
            string input = string.Empty;
            Dictionary<string, string> contests = new Dictionary<string, string>();
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] arr = input.Split(':');
                if (!contests.ContainsKey(arr[0]))
                {
                    contests.Add(arr[0], arr[1]);
                }
            }
            return contests;
        }

        static Dictionary<string, Dictionary<string, int>> Candidates(Dictionary<string, string> contests)
        {
            string input = string.Empty;
            string[] splitter = new string[] { "=>" };
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] arr = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                string contest = arr[0];
                string password = arr[1];
                string user = arr[2];
                int points = int.Parse(arr[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!candidates.ContainsKey(user))
                        {
                            candidates.Add(user, new Dictionary<string, int>());
                            candidates[user].Add(contest, points);
                        }
                        else
                        {
                            if (candidates.ContainsKey(user) && !candidates[user].ContainsKey(contest))
                            {
                                candidates[user][contest] = 0;
                            }
                            if (points > candidates[user][contest])
                            {
                                candidates[user][contest] = points;
                            }
                        }
                    }
                }
            }
            return candidates;
        }
    }
}