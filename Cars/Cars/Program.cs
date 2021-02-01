using System;
using System.Collections.Generic;
using Cars.BoardCars;
using Cars.Cars;
using Cars.PassengersBuilder;

namespace Cars
{
    class Program
    {
        //READ THIS
        //not add in lab 2 : "Child armchair", "Different price"
        static void Main(string[] args)
        {
            Bus bus1 = new Bus("111");
            Console.WriteLine(bus1);
            try
            {
                Bus bus2 = new Bus("111");
                Console.WriteLine(bus2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Bus bus3 = new Bus("111", "gg");
                Console.WriteLine(bus3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
    }
}