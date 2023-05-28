using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = Jagged(rows);
            AnalyzeJagged(jagged);
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split();
                string command = arr[0];
                if (command == "Add")
                {
                    if (arr.Length == 4)
                    {
                        int row = int.Parse(arr[1]);
                        int col = int.Parse(arr[2]);
                        int value = int.Parse(arr[3]);

                        if (row >= 0 && row < jagged.GetLength(0) && col >= 0 && col < jagged[row].Length)
                        {
                            jagged[row][col] += value;
                        }
                    }
                }

                else if (command == "Subtract")
                {
                    if (arr.Length == 4)
                    {
                        int row = int.Parse(arr[1]);
                        int col = int.Parse(arr[2]);
                        int value = int.Parse(arr[3]);

                        if (row >= 0 && row < jagged.GetLength(0) && col >= 0 && col < jagged[row].Length)
                        {
                            jagged[row][col] -= value;
                        }
                    }
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write($"{jagged[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static double[][] Jagged(int rows)
        {
            double[][] jagged = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = new double[nums.Length];
                for (int j = 0; j < nums.Length; j++)
                {
                    jagged[i][j] = nums[j];
                }
            }
            return jagged;
        }

        static void AnalyzeJagged(double[][] jagged)
        {
            for (int i = 0; i < jagged.GetLength(0) - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                    }

                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int k = 0; k < jagged[i].Length; k++)
                    {
                        jagged[i][k] /= 2;
                    }

                    for (int m = 0; m < jagged[i + 1].Length; m++)
                    {
                        jagged[i + 1][m] /= 2;
                    }
                }
            }
        }
    }
}
