using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+");

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string barcode = match.Groups[1].Value;
                string group = string.Empty;
                for (int j = 0; j < barcode.Length; j++)
                {
                    if (char.IsDigit(barcode[j]))
                    {
                        group += barcode[j];
                    }
                }

                if (string.IsNullOrEmpty(group))
                {
                    group = "00";
                }

                Console.WriteLine($"Product group: {group}");
            }
        }
    }
}
