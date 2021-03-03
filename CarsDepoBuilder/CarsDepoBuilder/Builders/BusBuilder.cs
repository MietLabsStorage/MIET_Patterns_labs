using System.Collections.Generic;
using CarsDepoBuilder.Cars;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder.Builders
{
    public class BusBuilder: Builder
    {
        private static BusBuilder Instance { get; set; }

        private BusBuilder()
        {
            
        }
        
        public static BusBuilder CarBuilderInstance()
        {
            return Instance ?? (Instance = new BusBuilder());
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
            Passengers.AddRange(passenger);
        }

        public override List<Car> GetResult()
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
        
        public override string ToString()
        {
            return $"{this.GetType()}: {Drivers.Count} drivers; {Passengers.Count} passengers \n";
        }
    }
}