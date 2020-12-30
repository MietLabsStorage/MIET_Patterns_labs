using System;
using System.Collections.Generic;

namespace Cars
{
    class Program
    {
        //READ THIS
        //not add in lab 2 : "Child armchair", "Different price"
        static void Main(string[] args)
        {
            List<Passenger.Passenger> taxiPassengers = new List<Passenger.Passenger>();
            List<Passenger.Passenger> busPassengers = new List<Passenger.Passenger>();
            List<Passenger.Passenger> nonPassengers = new List<Passenger.Passenger>();
            
            //generate lists of passengers by builders
            taxiPassengers.AddRange(Passenger.Passengers.GeneratePassengers(new Passenger.TaxiPassengersBuilder(), 7));
            busPassengers.AddRange(Passenger.Passengers.GeneratePassengers(new Passenger.BusPassengersBuilder(), 33));
            
            //work with taxi (demonstrate abstract factory and singleton)
            BoardTaxi taxi = new BoardTaxi();
            Console.WriteLine("\tCan taxi drive? " + taxi.IsCanDrive());
            Console.WriteLine("\tAppoint John taxi-driver");
            taxi.BoardDriver("John");
            Console.WriteLine("\tCan taxi drive? " + taxi.IsCanDrive());
            Console.WriteLine("\t\tCurrent taxi-driver: " + taxi.Driver);
            Console.WriteLine("\tTry appoint Bill taxi-driver");
            taxi.BoardDriver("Bill");
            Console.WriteLine("\t\tCurrent taxi-driver: " + taxi.Driver);
            Console.WriteLine("\tSit passengers into taxi");
            nonPassengers.Clear();
            nonPassengers.AddRange(taxi.BoardPassenger(taxiPassengers));
            Console.WriteLine("\tIn taxi: ");
            foreach (Passenger.Passenger person in taxi.Passenger)
            {
                Console.WriteLine("\t\t" + person);
            }
            Console.WriteLine("\tNot in taxi: ");
            foreach (Passenger.Passenger person in nonPassengers)
            {
                Console.WriteLine("\t\t" + person);
            }
            
            //work with bus (demonstrate abstract factory and singleton)
            BoardBus bus = new BoardBus();
            Console.WriteLine("\tCan bus drive? " + bus.IsCanDrive());
            Console.WriteLine("\tAppoint Bill bus-driver");
            bus.BoardDriver("Bill");
            Console.WriteLine("\tCan bus drive? " + bus.IsCanDrive());
            Console.WriteLine("\t\tCurrent bus-driver: " + bus.Driver);
            Console.WriteLine("\tTry appoint John bus-driver");
            bus.BoardDriver("John");
            Console.WriteLine("\t\tCurrent bus-driver: " + bus.Driver);
            Console.WriteLine("\tSit passengers into bus");
            nonPassengers.Clear();
            nonPassengers.AddRange(bus.BoardPassenger(busPassengers));
            Console.WriteLine("\tIn bus: ");
            int count = 0;
            foreach (Passenger.Passenger person in bus.Passenger)
            {
                Console.WriteLine("\t\t" + count++ + " " + person);
            }
            Console.WriteLine("\tNot in bus: ");
            foreach (Passenger.Passenger person in nonPassengers)
            {
                Console.WriteLine("\t\t" + person);
            }
        }
    }
}