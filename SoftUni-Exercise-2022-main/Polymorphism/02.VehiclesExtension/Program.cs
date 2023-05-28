using System;

namespace _02.VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                try
                {
                    if (command[0] == "Drive")
                    {
                        if (command[1] == "Car")
                        {
                            IDriveable idriveable = car;
                            idriveable.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            IDriveable idriveable = truck;
                            idriveable.Drive(double.Parse(command[2]));
                        }
                        else if ((command[1] == "Bus"))
                        {
                            IDriveable idriveable = bus;
                            bus.IsPopulated = IsPopulated.NotEmpty;
                            idriveable.Drive(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        IDriveable idriveable = bus;
                        bus.IsPopulated = IsPopulated.Empty;
                        idriveable.Drive(double.Parse(command[2]));
                    }
                    else
                    {
                        if (command[1] == "Car")
                        {
                            IDriveable idriveable = car;
                            idriveable.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            IDriveable idriveable = truck;
                            idriveable.Refuel(double.Parse(command[2]));
                        }
                        else
                        {
                            IDriveable idriveable = bus;
                            idriveable.Refuel(double.Parse(command[2]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
