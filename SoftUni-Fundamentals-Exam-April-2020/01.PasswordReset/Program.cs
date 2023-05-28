using System;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                if (command.Contains("TakeOdd"))
                {
                    string temp = string.Empty;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            temp += password[i];
                        }
                                    }
                    password = temp;
                    Console.WriteLine(password);
                }

                if (command.Contains("Cut"))
                {
                    var arr = command.Split();

                    int index = int.Parse(arr[1]);
                    int length = int.Parse(arr[2]);

                    password = password.Remove(index, length);
                    Console.WriteLine(password);
                }

                if (command.Contains("Substitute"))
                {
                    var arr = command.Split();

                    string substring = arr[1];
                    string sub = arr[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, sub);
                        Console.WriteLine(password);
                    }

                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
