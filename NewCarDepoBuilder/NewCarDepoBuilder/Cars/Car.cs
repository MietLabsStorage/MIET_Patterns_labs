using System.Collections.Generic;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Cars
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
        public Driver Driver { get; set; } = null;
        
        /// <summary>
        /// Passengers
        /// </summary>
        public List<Passenger> Passengers { get; } = new List<Passenger>();
        
        public override string ToString()
        {
            return ($"{this.GetType()}: {this.Driver} - {this.Passengers.Count}");
        }
        
    }
}