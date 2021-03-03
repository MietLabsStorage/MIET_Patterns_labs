using System.Collections.Generic;
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder.Cars
{
    public abstract class Car
    {
        /// <summary>
        /// capacity of passengers
        /// </summary>
        public abstract int Capacity { get; }
        
        /// <summary>
        /// Driver
        /// </summary>
        protected Driver Driver { get; set; } = null;
        
        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>instance</returns>
        public abstract Driver DriverInstance(string name = "");
        
        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="driver">driver</param>
        /// <returns>instance</returns>
        public abstract Driver DriverInstance(Driver driver);
        
        /// <summary>
        /// Passengers
        /// </summary>
        public List<Passenger> Passengers { get; } = new List<Passenger>();
        
    }
}