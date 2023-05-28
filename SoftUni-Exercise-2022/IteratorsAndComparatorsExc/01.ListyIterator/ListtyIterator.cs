using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListtyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;


        public ListtyIterator()
        {
            this.list = new List<T>();
            index = 0;
        }

        public void Add(T item) => list.Add(item);

        public bool HasNext() => index < list.Count - 1;

        public bool Move()
        {
            if (index + 1 > list.Count - 1)
            {
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }

        public string Print()
        {
            if (list.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            else
            {
                return list[index].ToString();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
