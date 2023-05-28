using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = new int[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    jagged[row][col] = rowData[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();
                int row = int.Parse(input[1]);
                int column = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if ((row <= jagged.Length - 1 && row >= 0) && (column >= 0 && column <= jagged.Length - 1))
                {
                    if (input.Contains("Add"))
                    {
                        jagged[row][column] += value;
                    }
                    else if (input.Contains("Subtract"))
                    {
                        jagged[row][column] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
