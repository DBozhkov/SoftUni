using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            HashSet<Person> hash = new HashSet<Person>();
            SortedSet<Person> sorted = new SortedSet<Person>();
            for (int i = 0; i < counter; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string name = arr[0];
                int age = int.Parse(arr[1]);
                var person = new Person(name, age);
                hash.Add(person);
                sorted.Add(person);
            }

            Console.WriteLine(hash.Count);
            Console.WriteLine(sorted.Count);
        }
    }
}
