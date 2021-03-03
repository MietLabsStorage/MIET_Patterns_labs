using System;
using System.Collections.Generic;
using CarsDepoBuilder.Builders;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder
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
            
            List<Passenger> busQueue = new List<Passenger>();
            for (int i = 0; i < 140; i++)
            {
                switch (rnd.Next(3))
                {
                    case 0:
                        busQueue.Add(new Adult(
                            $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                        );
                        break;
                    
                    case 1:
                        busQueue.Add(new Child(
                            $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                        );
                        break;
                    
                    case 2:
                        busQueue.Add(new Preferential(
                            $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                        );
                        break;
                }
            }

            List<Driver> busDrivers = new List<Driver>();
            for (int i = 0; i < 8; i++)
            {
                busDrivers.Add(new BusDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            Voyage busVoyage = new Voyage(BusBuilder.CarBuilderInstance(), busDrivers, busQueue);
            
            Console.WriteLine(busVoyage);
            Console.WriteLine(BusBuilder.CarBuilderInstance());
            
            
            List<Passenger> taxiQueue = new List<Passenger>();
            for (int i = 0; i < 140; i++)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        busQueue.Add(new Adult(
                            $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                        );
                        break;
                    
                    case 1:
                        busQueue.Add(new Child(
                            $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                        );
                        break;
                    
                }
            }

            List<Driver> taxiDrivers = new List<Driver>();
            for (int i = 0; i < 8; i++)
            {
                taxiDrivers.Add(new TaxiDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            Voyage taxiVoyage = new Voyage(TaxiBuilder.CarBuilderInstance(), taxiDrivers, taxiQueue);
            
            Console.WriteLine(taxiVoyage);
            Console.WriteLine(TaxiBuilder.CarBuilderInstance());
        }
    }
}