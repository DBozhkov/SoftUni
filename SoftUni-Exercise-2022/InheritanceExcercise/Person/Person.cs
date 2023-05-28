using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {

        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString();
        }

    }
}
