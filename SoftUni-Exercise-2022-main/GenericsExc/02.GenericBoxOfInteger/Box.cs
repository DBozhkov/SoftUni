using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {

        public T TValue { get; set; }

        public Box()
        {

        }

        public Box(T input) : this()
        {
           TValue = input;
        }

        public override string ToString()
        {
            return $"{TValue.GetType()}: {TValue}";
        }
    }
}
