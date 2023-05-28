using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; }
    }

    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }

    class Tire
    {
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < counter; i++)
            {

                string[] arr = Console.ReadLine().Split();
                string model = arr[0];
                int speed = int.Parse(arr[1]);
                int power = int.Parse(arr[2]);
                int weight = int.Parse(arr[3]);
                string type = arr[4];
                double tireOnePressure = double.Parse(arr[5]);
                int tireOneAge = int.Parse(arr[6]);
                double tireTwoPressure = double.Parse(arr[7]);
                int tireTwoAge = int.Parse(arr[8]);
                double tireThreePressure = double.Parse(arr[9]);
                int tireThreeAge = int.Parse(arr[10]);
                double tireFourPressure = double.Parse(arr[11]);
                int tireFourAge = int.Parse(arr[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weight);
                List<Tire> tires = new List<Tire>()
                {
                    new Tire(tireOneAge, tireOnePressure),
                    new Tire(tireTwoAge, tireTwoPressure),
                    new Tire(tireThreeAge, tireThreePressure),
                    new Tire(tireFourAge, tireFourPressure)
                };
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string input = Console.ReadLine();

            var finalCars = new List<string>();
            if (input == "fragile")
            {
                finalCars = cars.Where(x => x.Cargo.Type == "fragile").Where(v => v.Tires.Any(b => b.Pressure < 1)).Select(n => n.Model).ToList();
            }
            else if (input == "flammable")
            {
                finalCars = cars.Where(x => x.Cargo.Type == "flammable").Where(v => v.Engine.Power > 250).Select(n => n.Model).ToList();
            }

            Console.WriteLine(string.Join($"{Environment.NewLine}", finalCars));
        }
    }
}
