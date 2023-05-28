using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumandMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < counter; i++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = arr[0];

                switch (command)
                {
                    case 1:
                        stack.Push(arr[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                }
                if (stack.Count > 0)
                {
                    switch (command)
                    {
                        case 3:
                            Console.WriteLine(stack.Max());
                            break;
                        case 4:
                            Console.WriteLine(stack.Min());
                            break;
                    }
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
