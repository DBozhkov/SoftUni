using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(carInfo[1]);
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        IDriveable idriveable = car;
                        idriveable.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        IDriveable idriveable = truck;
                        idriveable.Drive(double.Parse(command[2]));
                    }
                }
                else
                {
                    if (command[1] == "Car")
                    {
                        IDriveable idriveable = car;
                        idriveable.Refuel(double.Parse(command[2]));
                    }
                    else
                    {
                        IDriveable idriveable = truck;
                        idriveable.Refuel(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
