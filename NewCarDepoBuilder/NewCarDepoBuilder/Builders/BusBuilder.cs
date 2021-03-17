using System.Collections.Generic;
using NewCarDepoBuilder.Cars;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Builders
{
    public class BusBuilder: IBuilder
    {
        public Car Car { get; private set; } = new Bus();

        public void BoardDriver(Driver driver)
        {
            Car.Driver = new BusDriver(driver);
        }

        public void BoardChild(Child passenger)
        {
            if (Car.Passengers.Count != Car.Capacity)
            {
                Car.Passengers.Add(passenger);
            }
        }

        public void BoardAdult(Adult passenger)
        {
            if (Car.Passengers.Count != Car.Capacity)
            {
                Car.Passengers.Add(passenger);
            }
        }

        public void BoardPreferential(Preferential passenger)
        {
            if (Car.Passengers.Count != Car.Capacity)
            {
                Car.Passengers.Add(passenger);
            }
        }

        public Car GetResult()
        {
            Car result = Car;
            Car = new Bus();
            return result;
        }
        
        public override string ToString()
        {
            return $"{this.GetType()}: {Car.Driver} - driver; {Car.Passengers.Count} passengers \n";
        }
    }
}