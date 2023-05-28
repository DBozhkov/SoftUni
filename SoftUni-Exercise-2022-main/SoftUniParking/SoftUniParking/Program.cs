using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Dictionary<string, string> userPlates = new Dictionary<string, string>();

            for (int i = 0; i < counter; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string user = command[1];
                if (command.Contains("register"))
                {          
                    string plate = command[2];
                    if (!userPlates.ContainsKey(user))
                    {
                        userPlates.Add(user, plate);
                        Console.WriteLine($"{user} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                }
                if (command.Contains("unregister"))
                {
                    if (!userPlates.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        userPlates.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }
            foreach (var user in userPlates)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
