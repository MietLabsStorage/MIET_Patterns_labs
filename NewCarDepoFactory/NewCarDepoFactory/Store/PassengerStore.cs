using System;
using System.Collections.Generic;
using System.Linq;
using NewCarDepoFactory.Passengers;

namespace NewCarDepoFactory.Store
{
    public class PassengerStore
    {
        private List<Passenger> Passengers { get; set; } = new List<Passenger>();

        public int Count(Type passengerType) => Passengers.Count(x => x.GetType() == passengerType);

        public void Add(Passenger passenger)
        {
            Passengers.Add(passenger);
        }

        public void AddList(List<Passenger> passengers)
        {
            passengers.AddRange(passengers);
        }

        public Passenger GetPassenger(Type passengerType)
        {
            Passenger passenger = Passengers.First(x => x.GetType() == passengerType);
            Passengers.Remove(passenger);
            return passenger;
        }

        public override string ToString()
        {
            string str = "";
            foreach (var passenger in Passengers)
            {
                str += $"{passenger}\n";
            }

            return str;
        }
    }
}