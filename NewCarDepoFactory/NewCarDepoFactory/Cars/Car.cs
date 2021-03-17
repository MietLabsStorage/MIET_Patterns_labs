using System.Collections.Generic;
using NewCarDepoFactory.Drivers;
using NewCarDepoFactory.Passengers;

namespace NewCarDepoFactory.Cars
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