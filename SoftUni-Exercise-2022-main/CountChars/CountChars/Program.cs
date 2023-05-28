using System;
using System.Collections.Generic;
using System.Linq;

namespace TempWork
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();

            Dictionary<char, int> charCounter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                int counter = 1;
                if (text[i] == ' ')
                {
                    continue;
                }
                if (!charCounter.ContainsKey(text[i]))
                {
                    charCounter.Add(text[i], counter);
                }
                else
                {
                    charCounter[text[i]]++;
                }
            }
            foreach (KeyValuePair<char, int> pair in charCounter)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
