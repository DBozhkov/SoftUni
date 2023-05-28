using System;

namespace _07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();
            string[] thirdArr = Console.ReadLine().Split();

            var nameAdress = new CustomTuple<string, string>($"{firstArr[0]} {firstArr[1]}", firstArr[2]);
            var nameBeer = new CustomTuple<string, int>(secondArr[0], int.Parse(secondArr[1]));
            var intDouble = new CustomTuple<int, double>(int.Parse(thirdArr[0]), double.Parse(thirdArr[1]));

            Console.WriteLine(nameAdress.Print());
            Console.WriteLine(nameBeer.Print());
            Console.WriteLine(intDouble.Print());
        }
    }
}
