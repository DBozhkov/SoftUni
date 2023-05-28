using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Toppings> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Toppings>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }

        public void AddTopping(Toppings topping)
        {
            if (toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range[0..10].");
            }
            toppings.Add(topping);
        }

        public double TotalCalories()
        {
            return this.Dough.Calories + toppings.Sum(x => x.Calories);
        }
    }
}
