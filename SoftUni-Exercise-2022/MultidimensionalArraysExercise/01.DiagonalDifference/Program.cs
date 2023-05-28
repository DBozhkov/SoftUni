using System;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];

            for (int rows = 0; rows < n; rows++)
            {
                string[] arr = Console.ReadLine().Split();
                for (int cols = 0; cols < arr.Length; cols++)
                {
                    matrix[rows,cols] = int.Parse(arr[cols]);
                }
            }

            int sumOne = 0;
            int sumTwo = 0;

            for (int i = 0; i < n; i++)
            {
                sumOne += matrix[i,i];
            }
            for (int j = 0; j < n; j++)
            {
                sumTwo += matrix[j, matrix.GetLength(1) - 1 - j];
            }

            Console.WriteLine(Math.Abs(sumOne - sumTwo));
        }
    }
}
