using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaArgs = Console.ReadLine().Split();
                string[] doughArgs = Console.ReadLine().Split();

                string flourType = doughArgs[1];
                string bakingTechnique = doughArgs[2];
                double weigth = double.Parse(doughArgs[3]);
                Dough dough = new Dough(flourType, bakingTechnique, weigth);
                Pizza pizza = new Pizza(pizzaArgs[1], dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppings = input.Split();
                    var topping = new Toppings(toppings[1], double.Parse(toppings[2]));
                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
