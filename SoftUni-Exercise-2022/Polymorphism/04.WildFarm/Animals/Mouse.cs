using _04.WildFarm.Food;
using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += food.Quantity * 0.10;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                ThrowInvalidOperation(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{nameof(this.GetType)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
