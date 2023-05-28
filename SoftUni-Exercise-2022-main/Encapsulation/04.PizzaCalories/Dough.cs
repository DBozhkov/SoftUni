using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> caloriesFlourType = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0}

        };

        private Dictionary<string, double> caloriesBakingTechnique = new Dictionary<string, double>
        {
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}

        };

        private string flourType;
        private string bakingTechnique;
        private double weigth;

        public Dough(string flourType, string bakingTechnique, double weigth)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weigth = weigth;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!caloriesFlourType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }


        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (!caloriesBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        public double Weigth
        {
            get { return weigth; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weigth = value;
            }
        }

        public double Calories => 2 * Weigth * caloriesFlourType[this.flourType.ToLower()] * caloriesBakingTechnique[this.bakingTechnique.ToLower()];
    }
}
