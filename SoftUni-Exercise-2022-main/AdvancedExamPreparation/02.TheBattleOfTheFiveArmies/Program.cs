using System;
using System.Collections.Generic;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] middleEarth = new char[n][];

            int armyRow = 0;
            int armyCol = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                char[] arr = input.ToCharArray();
                middleEarth[i] = new char[arr.Length];
                for (int j = 0; j < arr.Length; j++)
                {
                    middleEarth[i][j] = arr[j];
                    if (middleEarth[i][j] == 'A')
                    {
                        armyRow = i;
                       armyCol = j;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                string[] arr = command.Split();
                string move = arr[0];
                int spawnRow = int.Parse(arr[1]);
                int spawnCol = int.Parse(arr[2]);

                armor--;
                middleEarth[spawnRow][spawnCol] = 'O';
                middleEarth[armyRow][armyCol] = '-';

                switch (move)
                {
                    case "up":
                        if (armyRow - 1 >= 0)
                        {
                            armyRow--;
                        }
                        break;

                    case "down":
                        if (armyRow + 1 < n)
                        {
                            armyRow++;
                        }
                        break;

                    case "left":
                        if (armyCol - 1 >= 0)
                        {
                            armyCol--;
                        }
                        break;

                    case "right":
                        if (armyCol + 1 < middleEarth[armyRow].Length)
                        {
                            armyCol++;
                        }
                        break;
                }

                if (middleEarth[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                }

                if (middleEarth[armyRow][armyCol] == 'M')
                {
                    middleEarth[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    middleEarth[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                middleEarth[armyRow][armyCol] = 'A';
            }


            for (int k = 0; k < n; k++)
            {
                Console.WriteLine(new string(middleEarth[k]));
            }
        }
    }
}
