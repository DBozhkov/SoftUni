using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] splitter = new char[] { ' ' };
                int[] input = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int totalSum = int.MinValue;
            
            int bestRow = 0;
            int bestCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (sum > totalSum)
                    {
                        totalSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

                Console.WriteLine($"Sum = {totalSum}");
                for (int roww = bestRow; roww < bestRow + 3; roww++)
                {
                    for (int coll = bestCol; coll < bestCol + 3; coll++)
                    {
                        Console.Write($"{matrix[roww, coll]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
