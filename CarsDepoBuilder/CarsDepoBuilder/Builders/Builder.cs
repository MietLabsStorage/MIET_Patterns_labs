using System.Collections.Generic;
using CarsDepoBuilder.Cars;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder.Builders
{
    public abstract class Builder
    {
        protected List<Driver> Drivers { get; } = new List<Driver>();
        protected List<Passenger> Passengers { get; } = new List<Passenger>();
        public abstract void BoardDriver(params Driver[] driver);
        public abstract void BoardChild(params Child[] passenger);
        public abstract void BoardAdult(params Adult[] passenger);
        public abstract void BoardPreferential(params Preferential[] passenger);
        public abstract List<Car> GetResult();

    }
}