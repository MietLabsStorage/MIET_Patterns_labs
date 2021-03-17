using System;
using NewCarDepoBuilder.Cars;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Builders
{
    public class TaxiBuilder: IBuilder
    {
        public Car Car { get; private set; } = new Taxi();

        public void BoardDriver(Driver driver)
        {
            Car.Driver = new TaxiDriver(driver);
        }

        public void BoardChild(Child passenger)
        {
            if (Car.Passengers.Count != Car.Capacity)
            {
                Car.Passengers.Add(passenger);
                ((Taxi) Car).ChildChairsExisting = true;
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
            throw new NotImplementedException("Taxi cant ride preferential - cast to other type");
        }

        public Car GetResult()
        {
            Car result = Car;
            Car = new Taxi();
            return result;
        }
        
        public override string ToString()
        {
            return $"{this.GetType()}: {Car.Driver} - driver; {Car.Passengers.Count} passengers \n";
        }
    }
}