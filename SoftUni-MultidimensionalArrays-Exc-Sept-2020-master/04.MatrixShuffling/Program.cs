using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = ReadMatrix(rows, cols);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();

                if (input[0] == "swap" && input.Length == 5 && int.Parse(input[1]) < rows && int.Parse(input[3]) < rows && int.Parse(input[2]) < cols && int.Parse(input[4]) < cols)
                {
                    int rowOne = int.Parse(input[1]);
                    int colOne = int.Parse(input[2]);
                    int rowTwo = int.Parse(input[3]);
                    int colTwo = int.Parse(input[4]);

                    string first = matrix[rowOne, colOne];
                    string second = matrix[rowTwo, colTwo];
                    matrix[rowOne, colOne] = second;
                    matrix[rowTwo, colTwo] = first;
                    PrintMatrix(matrix);

                }

                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }

        static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            return matrix;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
