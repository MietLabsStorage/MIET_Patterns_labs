using System;

namespace Cars.Passenger
{
    public class TaxiPassengersBuilder: PassengersBuilder
    {
        /// <summary>
        /// add adult passenger
        /// </summary>
        /// <param name="passenger">adult passenger</param>
        public override void AddAdult(Adult passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// add child passenger
        /// </summary>
        /// <param name="passenger">child passenger</param>
        public override void AddChild(Child passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// nothing work
        /// </summary>
        /// <param name="passenger">nothing</param>
        public override void AddPreferential(Preferential passenger) { }
    }
}