using _04.WildFarm.Food;
using _04.WildFarm.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 1.00;
                this.FoodEaten += food.Quantity;
            }

            else
            {
                ThrowInvalidOperation(this, food);
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
