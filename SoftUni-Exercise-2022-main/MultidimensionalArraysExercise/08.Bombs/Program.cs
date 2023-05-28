using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[,] field = new int[fieldSize, fieldSize];

            ReadFieldFromConsole(field);
            string[] splitter = new string[] { " " };
            string[] coordinatesValues = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            ExplodeTheBombs(field, coordinatesValues);

            int aliveCells = 0;
            int sumAliveCells = 0;

            foreach (int cell in field)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sumAliveCells += cell;
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            PrintField(field);
        }

        private static void PrintField(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");

                }
                Console.WriteLine();
            }
        }

        private static void ExplodeTheBombs(int[,] field, string[] coordinatesValues)
        {
            foreach (string rowColPair in coordinatesValues)
            {
                string[] splitter = new string[] { "," };
                int[] currentBombCoordinates = rowColPair
                    .Split(splitter, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentBombRow = currentBombCoordinates[0];
                int currentBombCol = currentBombCoordinates[1];
                int currentBomb = field[currentBombRow, currentBombCol];


                for (int row = currentBombRow - 1; row <= currentBombRow + 1; row++)
                {
                    for (int col = currentBombCol - 1; col <= currentBombCol + 1; col++)
                    {
                        if (row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1))
                        {
                            if (field[row, col] <= 0 || currentBomb < 0)
                            {
                                continue;
                            }
                            field[row, col] -= currentBomb;
                        }
                    }
                }
            }
        }

        private static void ReadFieldFromConsole(int[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                string[] splitter = new string[] { " " };
                int[] currentRow = Console.ReadLine()
                    .Split(splitter, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentRow[col];
                }
            }
        }
    }
}