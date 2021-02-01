using System.Collections.Generic;
using Cars.Passenger;

namespace Cars.PassengersBuilder
{
    public interface IPassengersBuilder
    {
        /// <summary>
        /// Passengers
        /// </summary>
        public List<Passenger.Passenger> Passengers { get; }

        /// <summary>
        /// add adult passenger
        /// </summary>
        /// <param name="passenger">adult passenger</param>
        public abstract void AddAdult(Adult passenger);

        /// <summary>
        /// add child passenger
        /// </summary>
        /// <param name="passenger">child passenger</param>
        public abstract void AddChild(Child passenger);

        /// <summary>
        /// add preferential passenger
        /// </summary>
        /// <param name="passenger">preferential passenger</param>
        public abstract void AddPreferential(Preferential passenger);
    }
}