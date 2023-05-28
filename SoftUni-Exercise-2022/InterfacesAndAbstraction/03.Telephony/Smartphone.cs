using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private static IEnumerable numbers;

        public Smartphone(IEnumerable numbers)
        {
            this.Numbers = numbers;
        }

        public Smartphone(IEnumerable numbers, IEnumerable websites) : this(numbers)
        {
            this.Websites = websites;
        }

        public IEnumerable Numbers { get; private set; }
        public IEnumerable Websites { get; private set; }

        public void Call()
        {
            Console.WriteLine($"Calling... {Numbers}");
        }

        public void Browse()
        {
            Console.WriteLine($"Browsing: {Websites}!");
        }

    }
}
