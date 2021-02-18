using System;
using System.Collections.Generic;
using CarsDepoFactory.Cars;
using CarsDepoFactory.Drivers;
using CarsDepoFactory.Passengers;

namespace CarsDepoFactory.Factories
{
    public class BoardBus: IBoardAnyCar
    {
        /// <summary>
        /// drivers
        /// </summary>
        public List<Driver> Drivers { get; } = new List<Driver>();
        /// <summary>
        /// passengers
        /// </summary>
        public List<Passenger> Passengers { get; } = new List<Passenger>();
        /// <summary>
        /// board drivers
        /// </summary>
        /// <param name="drivers">drivers</param>
        public void BoardDriver(List<Driver> drivers)
        {
            foreach (var driver in drivers)
            {
                if (driver is BusDriver)
                {
                    Drivers.Add(driver);
                }
            }
        }


        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="passengers">passengers</param>
        public void BoardPassengers(List<Passenger> passengers)
        {
            foreach (var passenger in passengers)
            {
                if (passenger is BusPassenger)
                {
                    Passengers.Add(passenger);
                }
            }
        }

        //get result cars
        public List<Car> Cars
        {
            get
            {
                List<Car> lst = new List<Car>();
                int i = 0;
                int capacity = new Bus().Capacity;
                while(i < Drivers.Count && i < Passengers.Count/((double)capacity))
                {
                    Car car = new Bus();
                    car.DriverInstance(Drivers[i]);
                    car.Passengers.AddRange(Passengers.GetRange(i*capacity,  Passengers.Count - i*capacity < capacity ? Passengers.Count - i*capacity : capacity));
                    lst.Add(car);
                    i++;
                }
                Drivers.RemoveRange(0,i);
                foreach (var car in lst)
                {
                    Passengers.RemoveRange(0, car.Passengers.Count);
                }

                return lst;
            }
        }
        
        private static IBoardAnyCar Instance { get; set; }

        private BoardBus()
        {
            
        }
        
        public static IBoardAnyCar BoardCarInstance()
        {
            return Instance ?? (Instance = new BoardBus());
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {Drivers.Count} drivers; {Passengers.Count} passengers \n";
        }
    }
}