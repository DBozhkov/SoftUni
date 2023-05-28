using _04.WildFarm.Animals;
using _04.WildFarm.Food;
using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();
                    string[] foodInfo = Console.ReadLine().Split();

                    string animalType = animalInfo[0];
                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);

                    IAnimal animal = null;

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        if (animalType == "Cat")
                        {
                            animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        }

                        else
                        {
                            animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                        }
                    }

                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        if (animalType == "Owl")
                        {
                            animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        }

                        else
                        {
                            animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                        }
                    }

                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        if (animalType == "Mouse")
                        {
                            animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        }
                        else
                        {
                            animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                        }
                    }
                    Console.WriteLine(animal.ProduceSound());

                    IFood food = null;

                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(foodQuantity);
                    }

                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(foodQuantity);
                    }

                    else if (foodType == "Meat")
                    {
                        food = new Meat(foodQuantity);
                    }

                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(foodQuantity);
                    }

                    animal.Eat(food);
                    animals.Add(animal);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
