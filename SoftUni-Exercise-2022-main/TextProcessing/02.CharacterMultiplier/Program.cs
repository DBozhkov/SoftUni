using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            string frst = arr[0];
            string scnd = arr[1];
            Console.WriteLine(Sum(frst, scnd));
            
        }

        static int Sum(string first, string second)
        {
            int a = first.Length;
            int b = second.Length;
            int sum = 0;

            if (a > b)
            {
                for (int i = 0; i < a; i++)
                {
                    if (i > second.Length - 1)
                    {
                        for (int j = i; j < a; j++)
                        {
                            sum += (int)first[j];
                        }
                        break;
                    }
                    else
                    {
                        sum += (int)first[i] * (int)second[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < b; i++)
                {
                    if (i > first.Length - 1)
                    {
                        for (int j = i; j < b; j++)
                        {
                            sum += (int)second[j];
                        }
                        break;
                    }
                    else
                    {
                        sum += (int)first[i] * (int)second[i];
                    }
                }
        }

            return sum;
        }
}
}
