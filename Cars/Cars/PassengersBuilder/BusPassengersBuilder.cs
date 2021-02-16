using System.Collections.Generic;
using Cars.Passenger;

namespace Cars.PassengersBuilder
{
    public class BusPassengersBuilder: PassengersBuilder.IPassengersBuilder
    {
        public List<Passenger.Passenger> Passengers { get; } = new List<Passenger.Passenger>();

        /// <summary>
        /// add adult passenger
        /// </summary>
        /// <param name="passenger">adult passenger</param>
        public void AddAdult(Adult passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// add child passenger
        /// </summary>
        /// <param name="passenger">child passenger</param>
        public void AddChild(Child passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// add preferential passenger
        /// </summary>
        /// <param name="passenger">preferential passenger</param>
        public void AddPreferential(Preferential passenger)
        {
            Passengers.Add(passenger);
        }
    }
}