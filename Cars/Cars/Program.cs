using System;
using System.Collections.Generic;
using Cars.BoardCars;
using Cars.Cars;
using Cars.PassengersBuilder;
using static System.Console;

namespace Cars
{
    class Program
    {
        /// <summary>
        /// main function
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            WriteLine("#########create bus#########");
            Bus bus19E = new Bus("19e820");
            WriteLine(bus19E);
            WriteLine($"Is can ride: {bus19E.IsCanRide}");
            WriteLine();

            WriteLine("#########add permanent driver in bus#########");
            bus19E.BoardDriver("Vasiliy");
            bus19E.BoardDriver("Petr");
            WriteLine(bus19E);
            WriteLine($"Is can ride: {bus19E.IsCanRide}");
            WriteLine();
            
            WriteLine("#########board passengers in bus#########");
            int queueCount = bus19E.BoardPassengers(15).Count;
            WriteLine(bus19E);
            WriteLine($"Is can ride: {bus19E.IsCanRide}");
            WriteLine($"Last peoples in queue: {queueCount}");
            queueCount = bus19E.BoardPassengers(25).Count;
            WriteLine(bus19E);
            WriteLine($"Is can ride: {bus19E.IsCanRide}");
            WriteLine($"Last peoples in queue: {queueCount}");
            WriteLine();
            
            WriteLine("#########bus passengers#########");
            foreach(var people in bus19E.Passengers)
            {
                WriteLine($"{people.GetType()}: {people.Name} - {(new Bus("")).Cost((people))} rub");
            }
            WriteLine();
            
            WriteLine();
            
            WriteLine("#########create taxi#########");
            Taxi taxiYa = new Taxi("7459356");
            WriteLine(taxiYa);
            WriteLine($"Is can ride: {taxiYa.IsCanRide}");
            WriteLine();

            WriteLine("#########add permanent driver in taxi#########");
            taxiYa.BoardDriver("Ignat");
            taxiYa.BoardDriver("Aaron");
            WriteLine(taxiYa);
            WriteLine($"Is can ride: {taxiYa.IsCanRide}");
            WriteLine();
            
            WriteLine("#########board passengers in taxi#########");
            try
            {
                queueCount = taxiYa.BoardPassengers(2).Count;
                WriteLine($"Last peoples in queue: {queueCount}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            WriteLine(taxiYa);
            WriteLine($"Is can ride: {taxiYa.IsCanRide}");

            taxiYa.ChildChairsExisting = true;
            try
            {
                queueCount = taxiYa.BoardPassengers(5).Count;
                WriteLine($"Last peoples in queue: {queueCount}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            WriteLine(taxiYa);
            WriteLine($"Is can ride: {taxiYa.IsCanRide}");
            WriteLine();
            
            WriteLine("#########taxi passengers#########");
            foreach(var people in taxiYa.Passengers)
            {
                WriteLine($"{people.GetType()}: {people.Name} - {taxiYa.Cost((people))} rub");
            }
            WriteLine();

        }
    }
}