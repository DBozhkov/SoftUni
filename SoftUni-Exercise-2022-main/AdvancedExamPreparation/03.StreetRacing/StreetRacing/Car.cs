using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{

    //    •	Make: string
    //•	Model: string
    //•	LicensePlate: string
    //•	HorsePower: int
    //•	Weight: double

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }

        //        •	Override ToString() method in the format:
        //"Make: {Make}
        // Model: {Model}
        // License Plate: {LicensePlate}
        // Horse Power: {HorsePower}
        // Weight: {Weight}"

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"License Plate: {this.LicensePlate}");
            sb.AppendLine($"Horse Power: {this.HorsePower}");
            sb.AppendLine($"Weight: {this.Weight}");

            return sb.ToString().TrimEnd();
        }
    }
}
