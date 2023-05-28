using System;

namespace _03.DateModifier
{
    static class DateModifier
    {

        public static int CalculateDifference(string firstDate, string secondDate)
        {
            var first = DateTime.Parse(firstDate);
            var second = DateTime.Parse(secondDate);

            int diff = (first - second).Days;
            return Math.Abs(diff);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDifference(firstDate, secondDate));
        }
    }
}
