using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class CustomTuple<T, K>
    {
        public T FirstItem { get; set; }
        public K SecondItem { get; set; }


        public CustomTuple(T first, K second)
        {
            FirstItem = first;
            SecondItem = second;
        }

        public string Print()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
