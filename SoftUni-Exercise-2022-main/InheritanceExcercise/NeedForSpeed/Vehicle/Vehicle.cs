using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = DefaultFuelConsumption;
        }

        public virtual void Drive(double km)
        {
            if (Fuel - (FuelConsumption * km) <= 0)
            {
                Fuel = 0;
            }
            else
            {
                Fuel -= FuelConsumption * km;
            }
        }
    }
}
