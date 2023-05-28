using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            long[][] triangle = new long[count][];
            int cols = 1;

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[cols];
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < triangle[row].Length - 1; col++)
                    {
                        long[] prevRow = triangle[row - 1];
                        long first = prevRow[col];
                        long second = prevRow[col - 1];
                        triangle[row][col] = first + second;
                    }
                }
                cols++;
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
