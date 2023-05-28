using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] arr = command.Split();
                string name = arr[0];
                int age = int.Parse(arr[1]);
                string town = arr[2];

                var person = new Person(name, age, town);
                list.Add(person);
            }
            int n = int.Parse(Console.ReadLine());

            int isEqual = 0;
            int notEqual = 0;

            foreach (var person in list)
            {
                if (person.CompareTo(list[n - 1]) == 0)
                {
                    isEqual++;
                }
                else if (person.CompareTo(list[n - 1]) != 0)
                {
                    notEqual++;
                }
            }

            if (isEqual == 0 || isEqual == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{isEqual} {notEqual} {list.Count}");
            }
        }
    }
}
