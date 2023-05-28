using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> vLogger = new Dictionary<string, Dictionary<string, List<string>>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] arr = command.Split();
                string vloggerName = arr[0];


                if (arr[1] == "joined")
                {
                    if (!vLogger.ContainsKey(vloggerName))
                    {
                        vLogger.Add(vloggerName, new Dictionary<string, List<string>>());
                        vLogger[vloggerName].Add("followers", new List<string>());
                        vLogger[vloggerName].Add("following", new List<string>());
                    }
                    else
                    {
                        continue;
                    }
                }


                if (arr[1] == "followed")
                {
                    if (!vLogger.ContainsKey(arr[2]) && !vLogger.ContainsKey(arr[0]))
                    {
                        continue;
                    }
                    else
                    {
                        if (arr[2] != arr[0] && vLogger.ContainsKey(arr[0]) && vLogger.ContainsKey(arr[2]) && !vLogger[arr[2]]["followers"].Contains(arr[0]) && !vLogger[arr[0]]["following"].Contains(arr[2]))
                        {
                            vLogger[arr[2]]["followers"].Add(arr[0]);
                            vLogger[arr[0]]["following"].Add(arr[2]);
                        }
                    }
                }

            }

            Console.WriteLine($"The V-Logger has a total of {vLogger.Keys.Count} vloggers in its logs.");

            var finalVlog = vLogger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);
            int counter = 1;

            foreach (var vlogger in finalVlog)
            {

                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;

            }
        }
    }
}

