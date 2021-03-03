using System;
using Airplane.Leafs;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane Plane = new Plane("Win", typeof(Plane).ToString(), 150);

            Plane["Pilots"].Add(new Pilot("Peter J."));
            Plane["Pilots"].Add(new Pilot("John L."));
            try
            {
                Plane["Pilots"].Add(new Pilot("John L."));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                Plane["Stewardess"].Add(new Passenger("Adam E.",0));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Plane["FirstClass"].Add(new Passenger("Sir J.", 55));
            Plane["BusinessClass"].Add(new Passenger("Mr G.", 50));
            Plane["EconomyClass"].Add(new Passenger("Joe Q.", 40));
            Plane["EconomyClass"].Add(new Passenger("Bill S.", 28));
            Plane["EconomyClass"].Add(new Passenger("Lui R.", 28));
            Console.WriteLine(Plane.IsCanFlyUp);
            
            Console.WriteLine(Plane.LoadMap);
        }
    }
}