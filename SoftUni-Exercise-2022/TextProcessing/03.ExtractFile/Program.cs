using System;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //C:\Internal\training-internal\Template.pptx
            string[] splitter = new string[] {":", "\\"};
            string[] arr = Console.ReadLine().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[] finalArr = arr[arr.Length - 1].Split('.').ToArray();
            Console.WriteLine($"File name: {finalArr[0]}");
            Console.WriteLine($"File extension: {finalArr[1]}");
        }
    }
}
