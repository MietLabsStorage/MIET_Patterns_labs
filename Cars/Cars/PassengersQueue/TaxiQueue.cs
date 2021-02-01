using System;
using System.Collections.Generic;
using Cars.Passenger;

namespace Cars.PassengersQueue
{
    public class TaxiQueue
    {
        //names for generation passengers
        private static List<string> Names { get; } = new List<string>()
        {
            "John", "Jack", "Thom", "Lui", "Bob", "Bill", "Liz", "Mary",
            "Anna", "Emma", "Victory", "Harold", "Hector", "Elen", "Leo",
            "Teo", "Marine", "Angel", "Richard", "Steve", "Alex", "Sabrina"
        };
        
        /// <summary>
        /// size of queue
        /// </summary>
        public int Size { get; init; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="size">size of queue</param>
        public TaxiQueue(int size)
        {
            Size = size;
        }

        /// <summary>
        /// generate list of passengers
        /// </summary>
        /// <param name="builder">builder that will generate passengers</param>
        /// <returns>list of passengers</returns>
        public List<Passenger.Passenger> GeneratePassengers(PassengersBuilder.IPassengersBuilder builder)
        {
            while (builder.Passengers.Count != Size)
            {
                int type = new Random().Next(2);
                switch (type)
                {
                    case 0:
                        builder.AddAdult(new Adult(Names[new Random().Next(Names.Count)]));
                        break;
                    case 1:
                        builder.AddChild(new Child(Names[new Random().Next(Names.Count)]));
                        break;
                }
            }

            return builder.Passengers;
        }
    }
}