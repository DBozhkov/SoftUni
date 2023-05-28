using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public void AddItems(T input)
        {
            list.Add(input);
        }

        public void Swap(List<int> indexes)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
