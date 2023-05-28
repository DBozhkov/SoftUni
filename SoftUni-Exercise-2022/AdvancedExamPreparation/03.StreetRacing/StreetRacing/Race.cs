using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace StreetRacing
{
    public class Race : IEnumerable<Car>
    {
        public Dictionary<Car, string> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Keys.Count;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Participants = new Dictionary<Car, string>();
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
        }

        public void Add(Car car)
        {
            if (!Participants.ContainsValue(car.LicensePlate) && this.Capacity > 0 && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car, car.LicensePlate);
                Capacity--;
            }
        }

        public bool Remove(string licensePlate)
        {
            bool isRemoved = false;
            if (Participants.ContainsValue(licensePlate))
            {
                foreach (var car in Participants)
                {
                    if (car.Value == licensePlate)
                    {
                        Participants.Remove(car.Key);
                        isRemoved = true;
                        break;
                    }
                }
            }
            return isRemoved;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var car in Participants)
            {
                if (car.Value.Contains(licensePlate))
                {
                    return car.Key;
                }
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Keys.Count > 0)
            {
                return Participants.Keys.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.Key.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (var car in Participants)
            {
                yield return car.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
