using System;
using Airplane.Leafs;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = new Plane(300);

            plane.Pilots.Add(new Pilot("Peter J."));
            plane.Pilots.Add(new Pilot("John L."));
            try
            {
                plane.Pilots.Add(new Pilot("John L."));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                plane.Stewardess.Add(new Passenger("Adam E.",0));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            plane.FirstClass.Add(new Passenger("Sir J.", 250));
            plane.BusinessClass.Add(new Passenger("Mr G.", 150));
            plane.EconomyClass.Add(new Passenger("Joe Q.", 100));
            plane.EconomyClass.Add(new Passenger("Bill S.", 80));
            Console.WriteLine(plane.IsCanFlyUp);
            
            Console.WriteLine(plane.LoadMap);
        }
    }
}