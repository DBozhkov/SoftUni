using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitter = new string[] { ", " };
            string[] initialSongs = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(initialSongs);
            

            while (queue.Count > 0)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "Play":
                        queue.Dequeue();
                    break;
                    case "Add":
                        string finalSong = string.Empty;
                        foreach (string symbol in command)
                        {
                            finalSong += symbol + " ";
                        }
                        finalSong = finalSong.Substring(command[0].Length + 1).TrimEnd();

                        if (!queue.Contains(finalSong))
                        {
                            queue.Enqueue(finalSong);
                        }
                        else
                        {
                            Console.WriteLine($"{finalSong} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine($"{string.Join(", ", queue)}");
                        break;
                }

            }
            Console.WriteLine("No more songs!");
        }
    }
}
