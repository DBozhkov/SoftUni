using System;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            foreach (var num in phoneNumbers)
            {
                bool isValidNum = true;
                char[] numAsChars = num.ToCharArray();
                foreach (var charr in numAsChars)
                {
                    if (!Char.IsDigit(charr))
                    {
                        Console.WriteLine("Invalid number!");
                        isValidNum = false;
                        break;
                    }
                }
                if (!isValidNum)
                {
                    continue;
                }
                else
                {
                    if (numAsChars.Length == 7)
                    {
                        Calling(new StationaryPhone(num)); 
                    }
                    else if (numAsChars.Length == 10)
                    {
                        Calling(new Smartphone(num));
                    }
                }
            }

            foreach (var website in websites)
            {
                bool isValidWebsite = true;
                char[] stringAsChars = website.ToCharArray();
                foreach (var charr in stringAsChars)
                {
                    if (Char.IsDigit(charr))
                    {
                        Console.WriteLine("Invalid URL!");
                        isValidWebsite = false;
                        break;
                    }
                }
                if (!isValidWebsite)
                {
                    continue;
                }
                else
                {
                    Browsing(new Smartphone(string.Empty, website));
                }
            }
        }



        public static void Calling(ICallable callable)
        {
            callable.Call(); 
        }

        public static void Browsing(IBrowsable browsable)
        {
            browsable.Browse();
        }
    }
}
