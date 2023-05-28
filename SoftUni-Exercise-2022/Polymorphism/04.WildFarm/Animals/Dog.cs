using _04.WildFarm.Food;
using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.40;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                ThrowInvalidOperation(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{nameof(this.GetType)} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
