using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = ReadMatrix(size, size);

            int knightsReplaced = 0;
            int killerRow = 0;
            int killerCol = 0;

            while (true)
            {
                int attacksCount = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char current = matrix[row, col];
                        int currAttackCount = 0;
                        if (current == 'K')
                        {
                            currAttackCount = GetAttackCount(matrix, row, col, currAttackCount);
                        }

                        if (currAttackCount > attacksCount)
                        {
                            attacksCount = currAttackCount;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }

                if (attacksCount > 0)
                {
                    matrix[killerRow, killerCol] = '0';
                    knightsReplaced++;
                }

                else
                {
                    Console.WriteLine(knightsReplaced);
                    break;
                }
            }
        }

        private static int GetAttackCount(char[,] matrix, int row, int col, int currAttackCount)
        {
            if (isValid(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
            {
                currAttackCount++;
            }
            if (isValid(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
            {
                currAttackCount++;
            }

            return currAttackCount;
        }

        static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            return matrix;
        }
        static bool isValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
