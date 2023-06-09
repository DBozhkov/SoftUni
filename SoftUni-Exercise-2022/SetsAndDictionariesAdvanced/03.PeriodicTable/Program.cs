﻿using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                for (int j = 0; j < arr.Length; j++)
                {
                    set.Add(arr[j]);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
