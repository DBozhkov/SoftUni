using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split();
            ListtyIterator<string> listtyIterator = null;
            if (items.Length > 1)
            {
                listtyIterator = new ListtyIterator<string>();
                for (int i = 1; i < items.Length; i++)
                {
                    listtyIterator.Add(items[i]);
                }
            }
            else
            {
                listtyIterator = new ListtyIterator<string>();
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listtyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listtyIterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(listtyIterator.Print());
                        break;
                }
            }
        }
    }
}
