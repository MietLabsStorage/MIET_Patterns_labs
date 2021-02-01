using System;
using System.Collections.Generic;
using Cars.Passenger;

namespace Cars.PassengersBuilder
{
    public class TaxiPassengersBuilder: PassengersBuilder.IPassengersBuilder
    {
        public List<Passenger.Passenger> Passengers { get; }

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
        /// nothing work
        /// </summary>
        /// <param name="passenger">nothing</param>
        public void AddPreferential(Preferential passenger)
        {
            throw new NotImplementedException("Can\'t add preferential for taxi");
        }
    }
}