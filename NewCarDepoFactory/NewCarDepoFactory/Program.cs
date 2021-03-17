using System;
using System.Collections.Generic;
using NewCarDepoFactory.Drivers;
using NewCarDepoFactory.Factories;
using NewCarDepoFactory.Passengers;
using NewCarDepoFactory.Store;

namespace NewCarDepoFactory
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                "John", "Jack", "Liz", "Alan", "Ann",
                "Ire", "Kate", "Mary", "Jane", "Sue", "Bill",
                "Will", "Hugh", "Alex", "Sandro", "Kris",
                "Lothar", "Karl", "Ingrid", "Aaron", "Darina",
                "Bianka", "Dan"
            };

            List<string> surnames = new List<string>()
            {
                "Black", "Brown", "Scot", "Ericsson",
                "Jeferson", "Li", "Martel", "King", "Eir"
            };

            Random rnd = new Random();

            DriverStore driverStore = new DriverStore();
            for (int i = 0; i < 5; i++)
            {
                driverStore.Add(new BusDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
                driverStore.Add(new TaxiDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            PassengerStore passengerStore = new PassengerStore();
            for (int i = 0; i < 140; i++)
            {
                passengerStore.Add(new BusPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", $"ticket-{i}")
                );
                passengerStore.Add(new TaxiPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", rnd.NextDouble()*10)
                );
            }


            BoardBus Krukovo = new BoardBus();
            while (passengerStore.Count(typeof(BusPassenger))!=0 && 
                   driverStore.Count(typeof(BusDriver))!=0)
            {
                int x = Krukovo.BoardDriver(driverStore);
                int y = Krukovo.BoardPassengers(passengerStore, 35);
                Console.WriteLine($"*{x}*{y}*");
                Console.WriteLine(Krukovo.GetCar());
            }
            
            BoardTaxi Area17 = new BoardTaxi();
            while (passengerStore.Count(typeof(TaxiPassenger))!=0 && 
                   driverStore.Count(typeof(TaxiDriver))!=0)
            {
                int x = Area17.BoardDriver(driverStore);
                int y = Area17.BoardPassengers(passengerStore, 6);
                Console.WriteLine($"*{x}*{y}*");
                Console.WriteLine(Area17.GetCar());
            }
        }
    }
}