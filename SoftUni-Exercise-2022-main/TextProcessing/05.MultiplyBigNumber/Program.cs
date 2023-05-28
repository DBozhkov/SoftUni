using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            string first = Console.ReadLine();
            int second = int.Parse(Console.ReadLine());

            if (second == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int remainder = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = first.Length - 1; i >= 0; i--)
            {
                int result = int.Parse(first[i].ToString()) * second + remainder;
                remainder = 0;

                if (result > 9)
                {
                    remainder = result / 10;
                    result = result % 10;
                }
                sb.Append(result);
            }

            if (remainder != 0)
            {
                sb.Append(remainder);
            }

            StringBuilder final = new StringBuilder();

            for (int j = sb.Length - 1; j >= 0; j--)
            {
                final.Append(sb[j]);
            }
            Console.WriteLine(final);
        }
    }
}