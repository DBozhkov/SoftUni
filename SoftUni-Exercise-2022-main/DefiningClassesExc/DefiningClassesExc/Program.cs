using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DefineCLassPerson
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

    class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person ReturnOldest()
        {
            Person prsn = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return prsn;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < counter; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string name = arr[0];
                int age = int.Parse(arr[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }
            Person oldest = family.ReturnOldest();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
