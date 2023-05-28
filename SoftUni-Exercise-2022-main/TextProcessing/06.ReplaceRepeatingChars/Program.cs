using System;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int counter = 0;

            while (true)
            {
                int tempCount = counter;
                char temp = text[counter];
                if (counter + 1 < text.Length)
                {
                    if (temp == text[counter + 1])
                    {
                        text = text.Remove(counter + 1, 1);
                        counter = 0;
                        continue;
                    }
                    else
                    {
                        counter++;
                        continue;
                    }
                }

                else
                {
                    break;
                }
                
            }
            Console.WriteLine(text);
        }
    }
}
