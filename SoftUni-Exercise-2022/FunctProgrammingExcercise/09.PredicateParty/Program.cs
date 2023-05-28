using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] arr = command.Split();
                string action = arr[0];
                string operation = arr[1];
                string value = arr[2];

                Predicate<string> prd = GetInfo(operation, value);

                if (action == "Remove")
                {
                    names.RemoveAll(prd);
                }

                else if (action == "Double")
                {
                    int index = 0;
                    List<string> final = names.FindAll(prd);
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (prd(names[i]))
                        {
                            index = i;
                        }
                    }
                    names.InsertRange(index, final);

                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
            }

            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        public static Predicate<string> GetInfo(string operation, string value)
        {
            Predicate<string> predicate = x => true;
            switch (operation)
            {
                case "StartsWith":
                    predicate = x => x.StartsWith(value);
                    break;
                case "EndsWith":
                    predicate = x => x.EndsWith(value);
                    break;
                case "Length":
                    predicate = x => x.Length == int.Parse(value);
                    break;
            }
            return predicate;
        }
    }
}
