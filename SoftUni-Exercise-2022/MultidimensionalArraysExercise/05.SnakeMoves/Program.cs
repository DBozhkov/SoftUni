using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            char[,] matrix = ReadMatrix(matrixSize[0], matrixSize[1], snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMatrix(int rows, int cols, string snake)
        {
            char[,] matrix = new char[rows, cols];
            int n = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] chars = snake.ToCharArray();

                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (n == chars.Length - 1)
                        {
                            n = -1;
                        }
                        n++;
                        matrix[row, col] = chars[n];
                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {

                        if (n == chars.Length - 1)
                        {
                            n = -1;
                        }
                        n++;
                        matrix[row, col] = chars[n];
                    }
                }
            }
            return matrix;
        }
    }
}
