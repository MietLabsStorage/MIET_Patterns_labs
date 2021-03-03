using System;
using System.Collections.Generic;
using System.Linq;
using CarsDepoBuilder.Cars;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder.Builders
{
    public class TaxiBuilder: Builder
    {
        private static TaxiBuilder Instance { get; set; }

        private TaxiBuilder()
        {
            
        }

        public static TaxiBuilder CarBuilderInstance()
        {
            return Instance ?? (Instance = new TaxiBuilder());
        }
        public override void BoardDriver(params Driver[] driver)
        {
            Drivers.AddRange(driver);
        }

        public override void BoardChild(params Child[] passenger)
        {
            Passengers.AddRange(passenger);
        }

        public override void BoardAdult(params Adult[] passenger)
        {
            Passengers.AddRange(passenger);
        }

        public override void BoardPreferential(params Preferential[] passenger)
        {
            throw new Exception("Recast to child or adult");
        }

        public override List<Car> GetResult()
        {
            List<Car> lst = new List<Car>();
            int i = 0;
            int capacity = new Taxi().Capacity;
            while (i < Drivers.Count && i < Passengers.Count / ((double) capacity))
            {
                Car car = new Taxi();
                car.DriverInstance(Drivers[i]);
                car.Passengers.AddRange(Passengers.GetRange(i * capacity,
                    Passengers.Count - i * capacity < capacity ? Passengers.Count - i * capacity : capacity));
                lst.Add(car);
                i++;
                if (car.Passengers.Last() is Child)
                {
                    (car as Taxi).ChildChairsExisting = true;
                }
            }
            Drivers.RemoveRange(0,i);
            foreach (var car in lst)
            {
                Passengers.RemoveRange(0, car.Passengers.Count);
            }
            return lst;
        }
    }
}