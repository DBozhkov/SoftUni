using System;
using System.Linq;
using System.Collections.Generic;

namespace _10.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var userBySide = new Dictionary<string, string>();
            var sideByUsers = new Dictionary<string, int>();

            string input = string.Empty;
            string side = string.Empty;
            string user = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    GetAddedDictionaries(userBySide, sideByUsers, input, side, user);
                }
                else if (input.Contains(" -> "))
                {
                    GetDictionaries(userBySide, sideByUsers, input, side, user);
                }
            }
            PrintResult(sideByUsers, userBySide);
        }

        private static void GetDictionaries
            (Dictionary<string, string> userBySide, Dictionary<string, int> sideByUsers, string input, string side, string user)
        {
            
            string[] inputCommand = input.Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);

            user = inputCommand[0];
            side = inputCommand[1];

            if (userBySide.ContainsKey(user) && userBySide[user] != side && sideByUsers.ContainsKey(userBySide[user]))
            {
                sideByUsers[userBySide[user]]--;

                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;

                userBySide[user] = side;
            }
            else if (!userBySide.ContainsKey(user))
            {
                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;
                userBySide[user] = side;
            }
            Console.WriteLine($"{user} joins the {side} side!");
        }

        private static void GetAddedDictionaries
            (Dictionary<string, string> userBySide, Dictionary<string, int> sideByUsers, string input, string side, string user)
        {
            string[] inputCommand = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            side = inputCommand[0];
            user = inputCommand[1];

            if (!userBySide.ContainsKey(user))
            {
                userBySide.Add(user, side);

                if (!sideByUsers.ContainsKey(side))
                {
                    sideByUsers.Add(side, 0);
                }
                sideByUsers[side]++;
            }
        }

        private static void PrintResult(Dictionary<string, int> sideByUsers, Dictionary<string, string> userBySide)
        {
            foreach (var kvp in sideByUsers.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                if (kvp.Value > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value}");

                    foreach (var item in userBySide.OrderBy(k => k.Key))
                    {
                        if (item.Value == kvp.Key)
                        {
                            Console.WriteLine($"! {item.Key}");
                        }
                    }
                }
            }
        }
    }
}