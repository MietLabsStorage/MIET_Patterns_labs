using System;
using System.Collections.Generic;
using System.Linq;
using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Store
{
    public class PassengerStore
    {
        private List<Passenger> Passengers { get; set; } = new List<Passenger>();

        public int Count(Type passengerType) => Passengers.Count(x => x.GetType() == passengerType);
        public int Count() => Passengers.Count();
        public int Count(HashSet<Type> passengerTypes) => Passengers.Count(x =>  passengerTypes.Contains(x.GetType()));

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
        
        public Passenger GetPassenger(HashSet<Type> passengerTypes)
        {
            Passenger passenger = Passengers.First(x => passengerTypes.Contains(x.GetType()));
            Passengers.Remove(passenger);
            return passenger;
        }
        
        public Passenger GetPassenger()
        {
            Passenger passenger = Passengers.First();
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