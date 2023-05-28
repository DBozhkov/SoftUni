using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class CustomThreeuple<T, K, L>
    {
        public T FirstItem { get; set; }
        public K SecondItem { get; set; }
        public L ThirdItem { get; set; }


        public CustomThreeuple(T first, K second, L third)
        {
            FirstItem = first;
            SecondItem = second;
            ThirdItem = third;
        }

        public string Print()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
