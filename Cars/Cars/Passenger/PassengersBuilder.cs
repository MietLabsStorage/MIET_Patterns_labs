using System.Collections.Generic;

namespace Cars.Passenger
{
    public abstract class PassengersBuilder
    {
        /// <summary>
        /// Passengers
        /// </summary>
        public List<Passenger> Passengers { get; } = new List<Passenger>();

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