using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone(IEnumerable numbers)
        {
            this.Numbers = numbers;
        }
        public IEnumerable Numbers { get; private set; }

        public void Call()
        {
            Console.WriteLine($"Dialing... {Numbers}");
        }
    }
}
