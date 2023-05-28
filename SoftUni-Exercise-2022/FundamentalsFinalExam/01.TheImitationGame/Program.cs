using System;
using System.Linq;
using System.Text;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = string.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                sb.Append(message[i]);
            }

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] arr = input.Split('|');
                string temp = string.Empty;
                string command = arr[0];

                if (command == "Move")
                {
                    for (int i = 0; i < int.Parse(arr[1]); i++)
                    {
                        temp += sb[i];
                    }
                    sb.Remove(0, int.Parse(arr[1]));
                    sb.Append(temp);
                }
                else if (command == "Insert")
                {
                    sb.Insert(int.Parse(arr[1]), arr[2]);
                }
                else if (command == "ChangeAll")
                {
                    sb.Replace(arr[1], arr[2]);
                }
            }
            Console.WriteLine($"The decrypted message is: {sb}");
        }
    }
}
