using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Toppings
    {
        private Dictionary<string, double> caloriesToppingTypes = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };

        private string type;
        private double weigth;

        public Toppings(string type, double weigth)
        {
            this.Type = type;
            this.Weigth = weigth;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (!caloriesToppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weigth
        {
            get { return weigth; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                weigth = value;
            }
        }

        public double Calories => 2 * Weigth * caloriesToppingTypes[this.Type.ToLower()];
    }
}
