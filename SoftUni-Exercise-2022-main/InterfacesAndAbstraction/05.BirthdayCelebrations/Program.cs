using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inameable = new List<INameable>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] arr = input.Split();

                if (arr[0] == "Citizen")
                {
                    inameable.Add(new Citizen(arr[1], int.Parse(arr[2]), arr[3], arr[4]));
                }
                else if (arr[0] == "Pet")
                {
                    inameable.Add(new Pet(arr[1], arr[2]));
                }

                input = Console.ReadLine();
            }
            int year = int.Parse(Console.ReadLine());
            inameable.Where(y => y.Birthdate.Year == year).Select(x => x.Birthdate).ToList().ForEach(dt => Console.WriteLine(dt.ToString(@"dd/mm/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
