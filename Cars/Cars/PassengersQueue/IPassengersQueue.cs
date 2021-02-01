using System.Collections.Generic;

namespace Cars.PassengersQueue
{
    public interface IPassengersQueue
    {
        /// <summary>
        /// create list of passengers queue
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        List<Passenger.Passenger> GeneratePassengers(PassengersBuilder.IPassengersBuilder builder);
    }
}