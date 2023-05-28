using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OpinionPoll
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Name = " ";
            Age = 1;
        }
        public Person(int age) : this()
        {
            Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            Name = name;
        }
    }

    class People
    {
        public People()
        {
            Pple = new List<Person>();
        }
        public List<Person> Pple { get; set; }


        public void Add(Person person)
        {
            Pple.Add(person);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            var people = new People();

            for (int i = 0; i < counter; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string name = arr[0];
                int age = int.Parse(arr[1]);
                var person = new Person(name, age);
                people.Add(person);
            }
            var final = people.Pple.Where(x => x.Age > 30).OrderBy(x => x.Name);
            foreach (var person in final)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
