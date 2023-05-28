using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(size, size);
            int primarySum = 0;
            int secondarySum = 0;
            int row = 0;

            for (int i = 0; i < size; i++)
            {
                primarySum += matrix[i, i];
            }

            for (int col = size - 1; col >= 0; col--)
            {
                secondarySum += matrix[row, col];
                row++;
            }

            Console.WriteLine($"{Math.Abs(primarySum - secondarySum)}");
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
