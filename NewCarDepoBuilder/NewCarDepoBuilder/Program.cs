using System;
using System.Collections.Generic;
using NewCarDepoBuilder.Builders;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;
using NewCarDepoBuilder.Store;

namespace NewCarDepoBuilder
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
            for (int i = 0; i < 240; i++)
            {
                passengerStore.Add(new Adult(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
                passengerStore.Add(new Child(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
                passengerStore.Add(new Preferential(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            BusBuilder Krukovo = new BusBuilder();
            TaxiBuilder Area17 = new TaxiBuilder();
            Director director = new Director(Krukovo, driverStore, passengerStore);

            while (passengerStore.Count() != 0 &&
                   driverStore.Count(typeof(BusDriver)) != 0)
            {
                director.BuildCar();
                Console.WriteLine(Krukovo.GetResult());
            }


            director.Builder = Area17;
            while (passengerStore.Count() != 0 &&
                   driverStore.Count(typeof(TaxiDriver)) != 0)
            {
                director.BuildCar();
                Console.WriteLine(Area17.GetResult());
            }
        }
    }
}