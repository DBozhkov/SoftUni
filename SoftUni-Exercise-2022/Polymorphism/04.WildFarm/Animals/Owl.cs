using _04.WildFarm.Food;
using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                ThrowInvalidOperation(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
