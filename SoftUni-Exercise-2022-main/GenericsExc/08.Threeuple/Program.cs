using System;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();
            string[] thirdArr = Console.ReadLine().Split();

            string firstName = firstArr[0];
            string lastName = firstArr[1];
            string address = firstArr[2];
            string town = string.Empty;
            for (int i = 3; i < firstArr.Length; i++)
            {
                if (i == firstArr.Length - 1)
                {
                    town += firstArr[i];
                    break;
                }
                town += $"{firstArr[i]} ";
            }
            var nameAdress = new CustomThreeuple<string, string, string>($"{firstName} {lastName}", address, town);

            string fName = secondArr[0];
            int litres = int.Parse(secondArr[1]);
            bool isDrunk = false;
            if (secondArr[2] == "drunk")
            {
                isDrunk = true;
            }

            else if (secondArr[2] == "not")
            {
                isDrunk = false;
            }
            var nameBeer = new CustomThreeuple<string, int, bool>(fName, litres, isDrunk);

            string tName = thirdArr[0];
            double balance = double.Parse(thirdArr[1]);
            string bankName = thirdArr[2];
            var intDouble = new CustomThreeuple<string, double, string>(tName, balance, bankName);

            Console.WriteLine(nameAdress.Print());
            Console.WriteLine(nameBeer.Print());
            Console.WriteLine(intDouble.Print());
        }
    }
}
