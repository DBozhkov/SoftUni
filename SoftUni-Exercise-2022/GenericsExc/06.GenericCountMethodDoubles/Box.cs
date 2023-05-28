using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDoubles
{
    public class Box<T>
        where T : IComparable
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

        public int Compare ( T item)
        {
            int count = 0;
            foreach (var element in list)
            {
                int comparer = element.CompareTo(item);
                if (comparer > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
