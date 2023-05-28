using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialNum = int.Parse(Console.ReadLine());
            string input = string.Empty;
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 0; i < initialNum; i++)
            {
                string[] arr = Console.ReadLine().Split('|').ToArray();
                string piece = arr[0];
                string composer = arr[1];
                string key = arr[2];
                if (!dict.ContainsKey(arr[0]))
                {
                    dict.Add(piece, new Dictionary<string, string>());
                    dict[piece].Add(composer, key);
                }
            }
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splitter = new string[] { "|" };
                string[] arr = input.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                string command = arr[0];
                string piece = arr[1];
                
                switch (command)
                {
                    case "Add":
                        string composer = arr[2];
                        string key = arr[3];
                        if (!dict.ContainsKey(piece))
                        {
                            dict.Add(piece, new Dictionary<string, string>());
                            dict[piece].Add(composer, key);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        break;

                    case "Remove":
                        if (dict.ContainsKey(piece))
                        {
                            dict.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!"); 
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":            
                        string newKey = arr[2];
                        if (dict.ContainsKey(piece))
                        {
                            string tempComposer = string.Empty;
                            foreach (var items in dict[piece])
                            {
                                tempComposer = items.Key;
                            }
                            string tempKey = dict[piece][tempComposer];
                            dict[piece][tempComposer] = dict[piece][tempComposer].Replace(tempKey, newKey);
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }
            }
            foreach (var items in dict)
            {
                foreach (var item in items.Value)
                {
                    Console.WriteLine($"{items.Key} -> Composer: {item.Key}, Key: {item.Value}");
                }
            }
        }
    }
}
