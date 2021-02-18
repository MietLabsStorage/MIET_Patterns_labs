using System.Collections.Generic;
using CarsDepoFactory.Cars;
using CarsDepoFactory.Drivers;
using CarsDepoFactory.Passengers;

namespace CarsDepoFactory.Factories
{
    public interface IBoardAnyCar
    {
        /// <summary>
        /// drivers
        /// </summary>
        List<Driver> Drivers { get; }
        /// <summary>
        /// passengers
        /// </summary>
        List<Passenger> Passengers { get; }
        
        /// <summary>
        /// board drivers
        /// </summary>
        /// <param name="drivers">drivers</param>
        void BoardDriver(List<Driver> drivers);
        
        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="passengers">passengers</param>
        void BoardPassengers(List<Passenger> passengers);

        //get result cars
        List<Car> Cars { get; }
    }
}