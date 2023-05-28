using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class StackClass<T> : IEnumerable<T>
    {
        private List<T> list;

        public StackClass()
        {
            this.list = new List<T>();
        }

        public void Push(T element)
        {
            list.Add(element);
        }

        public void Pop()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                list.Remove(list[list.Count - 1]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
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
