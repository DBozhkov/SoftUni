using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitter = new string[] { ", " };
            string[] arr = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();
            bool isValid = true;

            foreach (var item in arr)
            {
                if ((item.Length >= 3 && item.Length <= 16))
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        string hyphen = char.ConvertFromUtf32(45);
                        string underscores = char.ConvertFromUtf32(95);
                        string temp = item[i].ToString();
                        if (temp == hyphen || temp.ToString() == underscores || Char.IsLetterOrDigit(item[i]))
                        {
                            isValid = true;
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                        
                    }
                    if (isValid)
                    {
                        Console.WriteLine(item);
                    }
                }
                
            }
        }
    }
}
