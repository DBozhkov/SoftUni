using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            var filtered = new List<string>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] arr = command.Split(';');
                string action = arr[0];
                string operation = arr[1];
                string value = arr[2];
                string dictKey = $"{operation}_{value}";

                if (action == "Add filter")
                {

                    filtered.Add($"{operation};{value}");
                }

                else if (action == "Remove filter")
                {
                    if (filtered.Contains($"{operation};{value}"))
                    {
                        filtered.Remove($"{operation};{value}");
                    }
                }
            }

            Func<string, int, bool> lengthFilter = (name, length)
               => name.Length == length;
            Func<string, string, bool> startsFilter = (name, letter)
                => name.StartsWith(letter);
            Func<string, string, bool> endsFilter = (name, letter)
                => name.EndsWith(letter);
            Func<string, string, bool> containsFilter = (name, letter)
                => name.Contains(letter);
            foreach (var item in filtered)
            {
                string[] curr = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string action = curr[0];
                string value = curr[1];

                if (action == "Starts with")
                {
                    names = names
                        .Where(name => !startsFilter(name, value))
                        .ToList();
                }
                else if (action == "Ends with")
                {
                    names = names
                        .Where(name => !endsFilter(name, value))
                        .ToList();
                }
                else if (action == "Length")
                {
                    names = names
                        .Where(name => !lengthFilter(name, int.Parse(value)))
                        .ToList();
                }
                else if (action == "Contains")
                {
                    names = names
                        .Where(name => !containsFilter(name, value))
                        .ToList();
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }

    }
}