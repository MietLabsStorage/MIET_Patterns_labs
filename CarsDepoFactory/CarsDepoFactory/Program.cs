using System;
using System.Collections.Generic;
using CarsDepoFactory.Drivers;
using CarsDepoFactory.Factories;
using CarsDepoFactory.Passengers;

namespace CarsDepoFactory
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
                busQueue.Add(new BusPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", $"ticket{i}")
                );
            }

            List<Driver> busDrivers = new List<Driver>();
            for (int i = 0; i < 8; i++)
            {
                busDrivers.Add(new BusDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            Voyage busVoyage = new Voyage(BoardBus.BoardCarInstance(), busDrivers, busQueue);
            
            Console.WriteLine(busVoyage);
            Console.WriteLine(BoardBus.BoardCarInstance());
            
            
            
            
            
            List<Passenger> taxiQueue = new List<Passenger>();
            for (int i = 0; i < 140; i++)
            {
                taxiQueue.Add(new TaxiPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", rnd.NextDouble()*10)
                );
            }

            List<Driver> taxiDrivers = new List<Driver>();
            for (int i = 0; i < 8; i++)
            {
                taxiDrivers.Add(new TaxiDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            Voyage taxiVoyage = new Voyage(BoardTaxi.BoardCarInstance(), taxiDrivers, taxiQueue);
            
            Console.WriteLine(taxiVoyage);
            Console.WriteLine(BoardTaxi.BoardCarInstance());

            
            


            List<Passenger> queue = new List<Passenger>();
            for (int i = 0; i < 41; i++)
            {
                queue.Add(new BusPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", $"ticket-{i}")
                );
                queue.Add(new TaxiPassenger(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}", rnd.NextDouble()*10)
                );
            }

            List<Driver> drivers = new List<Driver>();
            for (int i = 0; i < 4; i++)
            {
                drivers.Add(new BusDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
                drivers.Add(new TaxiDriver(
                    $"{names[rnd.Next(names.Count)]} {surnames[rnd.Next(surnames.Count)]}")
                );
            }

            Voyage voyage1 = new Voyage(BoardBus.BoardCarInstance(), drivers, queue);
            Voyage voyage2 = new Voyage(BoardTaxi.BoardCarInstance(), drivers, queue);
            
            Console.WriteLine(voyage1);
            Console.WriteLine(voyage2);
            Console.WriteLine(BoardBus.BoardCarInstance());
            Console.WriteLine(BoardTaxi.BoardCarInstance());
        }
    }
}