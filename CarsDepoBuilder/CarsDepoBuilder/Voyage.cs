using System.Collections.Generic;
using System.Linq;
using CarsDepoBuilder.Builders;
using CarsDepoBuilder.Cars;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder
{
    public class Voyage
    {
        private List<Car> Cars { get; } = new List<Car>();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="depo">factory</param>
        /// <param name="drivers">drivers</param>
        /// <param name="passengers">passengers</param>
        public Voyage(Builder depo, List<Driver> drivers, List<Passenger> passengers)
        {
            depo.BoardDriver(drivers.Where(x => x is BusDriver).ToArray());
            foreach (var passenger in passengers)
            {
                switch (passenger)
                {
                    case Child child:
                        depo.BoardChild(child);
                        break;
                    case Preferential preferential:
                        depo.BoardPreferential(preferential);
                        break;
                    case Adult adult:
                        depo.BoardAdult(adult);
                        break;
                }
            }
            Cars.AddRange(depo.GetResult());
        }

        public override string ToString()
        {
            string str = "";
            foreach(var car in Cars)
            {
                str += ($"{car.GetType()}: {car.DriverInstance()} - {car.Passengers.Count}; is exist child chairs: \n");
            }

            return str;
        }

        public static Adult ToAdult(Preferential preferential)
        {
            return new Adult(preferential.Name);
        }
        
        public static Child ToChild(Preferential preferential)
        {
            return new Child(preferential.Name);
        }
    }
}