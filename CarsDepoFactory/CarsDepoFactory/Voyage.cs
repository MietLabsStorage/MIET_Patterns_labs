using System;
using System.Collections.Generic;
using CarsDepoFactory.Cars;
using CarsDepoFactory.Drivers;
using CarsDepoFactory.Factories;
using CarsDepoFactory.Passengers;

namespace CarsDepoFactory
{
    public class Voyage
    {
        public List<Car> Cars { get; } = new List<Car>();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="depo">factory</param>
        /// <param name="drivers">drivers</param>
        /// <param name="passengers">passengers</param>
        public Voyage(IBoardAnyCar depo, List<Driver> drivers, List<Passenger> passengers)
        {
            depo.BoardDriver(drivers);
            depo.BoardPassengers(passengers);
            Cars.AddRange(depo.Cars);
        }

        public override string ToString()
        {
            string str = "";
            foreach(var car in Cars)
            {
                str += ($"{car.GetType()}: {car.DriverInstance()} - {car.Passengers.Count}\n");
            }

            return str;
        }
    }
}