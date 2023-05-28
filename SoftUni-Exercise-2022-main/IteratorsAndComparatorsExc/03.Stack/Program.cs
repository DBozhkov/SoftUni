using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            StackClass<int> stackClass = new StackClass<int>();

            while ((command = Console.ReadLine()) != "END")
            {
                char[] splitter = new char[] { ',', ' ' };
                string[] arr = command.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                if (arr[0] == "Push")
                {
                    foreach (var item in arr.Skip(1))
                    {
                        stackClass.Push(int.Parse(item));
                    }             
                }

                else if (arr[0] == "Pop")
                {
                    stackClass.Pop();
                }
            }
            foreach (var item in stackClass)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stackClass)
            {
                Console.WriteLine(item);
            }
        }
    }
}
