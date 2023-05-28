using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];

                if (curr == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(curr);
                }
                else if (power == 0)
                {
                    sb.Append(curr);
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}