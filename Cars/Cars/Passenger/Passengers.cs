using System;
using System.Collections.Generic;

namespace Cars.Passenger
{
    public static class Passengers
    {
        //names for generation passengers
        private static List<string> Names { get; } = new List<string>()
        {
            "John", "Jack", "Thom", "Lui", "Bob", "Bill", "Liz", "Mary",
            "Anna", "Emma", "Victory", "Harold", "Hector", "Elen", "Leo",
            "Teo", "Marine", "Angel", "Richard", "Steve", "Alex", "Sabrina"
        };

        /// <summary>
        /// generate list of passengers
        /// </summary>
        /// <param name="builder">builder that will generate passengers</param>
        /// <param name="amount">size of generating list</param>
        /// <returns>list of passengers</returns>
        public static List<Passenger> GeneratePassengers(PassengersBuilder builder, int amount)
        {
            while (builder.Passengers.Count != amount)
            {
                int type = new Random().Next(3);
                switch (type)
                {
                    case 0:
                        builder.AddAdult(new Adult(Names[new Random().Next(Names.Count)]));
                        break;
                    case 1:
                        builder.AddChild(new Child(Names[new Random().Next(Names.Count)]));
                        break;
                    case 2:
                        builder.AddPreferential(new Preferential(Names[new Random().Next(Names.Count)]));
                        break;
                }
            }

            return builder.Passengers;
        }
        
    }
}