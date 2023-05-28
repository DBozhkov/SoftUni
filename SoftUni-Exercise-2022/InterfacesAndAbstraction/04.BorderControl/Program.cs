using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var identifiable = new List<IIdentifiable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] arr = input.Split();
                if (arr.Length == 2)
                {
                    identifiable.Add(new Robot(arr[0], arr[1]));
                }
                else if (arr.Length == 3)
                {
                    identifiable.Add(new Citizen(arr[0], int.Parse(arr[1]), arr[2]));
                }

                input = Console.ReadLine();
            }
            string finalNUms = Console.ReadLine();
            identifiable = identifiable.Where(x => x.Id.EndsWith(finalNUms)).ToList();

            foreach (var member in identifiable)
            {
                Console.WriteLine(member.Id);
            }
        }
    }
}
