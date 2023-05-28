using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
                    }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
