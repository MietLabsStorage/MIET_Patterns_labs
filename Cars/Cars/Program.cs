using System;
using System.Collections.Generic;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract factory and singleton demonstration::");
            List<string> passengers = new List<string>() {"Michel", "Jack", "Lui", "Mary", "Ingrid", "Anna", "Eugine"};
            List<string> nonPassengers = new List<string>();
            
            
            BoardTaxi taxi = new BoardTaxi();
            Console.WriteLine("\tAppoint John taxi-driver");
            taxi.BoardDriver("John");
            Console.WriteLine("\t\tCurrent taxi-driver: " + taxi.Driver);
            Console.WriteLine("\tTry appoint Bill taxi-driver");
            taxi.BoardDriver("Bill");
            Console.WriteLine("\t\tCurrent taxi-driver: " + taxi.Driver);
            Console.WriteLine("\tSit passengers into taxi");
            nonPassengers.Clear();
            nonPassengers.AddRange(taxi.BoardPassenger(passengers));
            Console.WriteLine("\tIn taxi: ");
            foreach (string person in taxi.Passenger)
            {
                Console.WriteLine("\t\t" + person);
            }
            Console.WriteLine("\tNot in taxi: ");
            foreach (string person in nonPassengers)
            {
                Console.WriteLine("\t\t" + person);
            }
            
            
            BoardBus bus = new BoardBus();
            Console.WriteLine("\tAppoint Bill bus-driver");
            bus.BoardDriver("Bill");
            Console.WriteLine("\t\tCurrent bus-driver: " + bus.Driver);
            Console.WriteLine("\tTry appoint John bus-driver");
            bus.BoardDriver("John");
            Console.WriteLine("\t\tCurrent bus-driver: " + bus.Driver);
            Console.WriteLine("\tSit passengers into bus");
            nonPassengers.Clear();
            for (int i = 0; i < 6; i++)
            {
                List<string> items = bus.BoardPassenger(passengers);
                if (items.Count != 0)
                {
                    nonPassengers.AddRange(items);
                }
            }
            Console.WriteLine("\tIn bus: ");
            int count = 0;
            foreach (string person in bus.Passenger)
            {
                Console.WriteLine("\t\t" + count++ + " " + person);
            }
            Console.WriteLine("\tNot in bus: ");
            foreach (string person in nonPassengers)
            {
                Console.WriteLine("\t\t" + person);
            }
        }
    }
}