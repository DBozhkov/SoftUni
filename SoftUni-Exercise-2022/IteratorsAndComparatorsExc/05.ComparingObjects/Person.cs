using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public string Name => name;
        public int Age => age;
        public string Town => town;

        public int CompareTo(Person person)
        {
            int equal = 0;

            if (Name.CompareTo(person.name) == equal)
            {
                if (Age.CompareTo(person.age) == equal)
                {
                    if (Town.CompareTo(person.town) == equal)
                    {
                        return equal;
                    }
                }
            }
            else
            {
                equal = 1;
            }

            return equal;
        }
    }
}
