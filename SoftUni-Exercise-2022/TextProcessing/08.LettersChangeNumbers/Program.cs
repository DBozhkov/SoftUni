using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] splitter = new string[] { " " };
            string[] arr = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();
            double sum = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                double tempSum = 0.0;
                string tempStringInt = string.Empty;
                char[] firstTemp = arr[i].ToCharArray();
                int alphabetPosition = firstTemp[0] % 32;
                for (int k = 0; k < firstTemp.Length; k++)
                {
                    char temp = firstTemp[k];

                    if (char.IsDigit(temp))
                    {
                        tempStringInt += temp;
                    }
                }

                if (char.IsLower(firstTemp[0]))
                {
                    tempSum += double.Parse(tempStringInt) * alphabetPosition;
                }
                else if (char.IsUpper(firstTemp[0]))
                {
                    tempSum += double.Parse(tempStringInt) / alphabetPosition;
                }
                if (char.IsLower(firstTemp[firstTemp.Length - 1]))
                {
                    alphabetPosition = firstTemp[firstTemp.Length - 1] % 32;
                    tempSum += alphabetPosition;
                }
                else if (char.IsUpper(firstTemp[firstTemp.Length - 1]))
                {
                    alphabetPosition = firstTemp[firstTemp.Length - 1] % 32;
                    tempSum -= alphabetPosition;
                }
                sum += tempSum;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
