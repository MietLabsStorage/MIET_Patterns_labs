
using CarsDepoBuilder.Drivers;
using CarsDepoBuilder.Passengers;

namespace CarsDepoBuilder.Cars
{
    public class Bus: Car
    {
        /// <summary>
        /// capacity of passengers
        /// </summary>
        public override int Capacity => 30;
        
        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>instance</returns>
        public override Driver DriverInstance(string name="")
        {
            return Driver ?? (Driver = new BusDriver(name));
        }

        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="driver">driver</param>
        /// <returns>instance</returns>
        public override Driver DriverInstance(Driver driver)
        {
            return Driver ?? (Driver = new BusDriver(driver));
        }

        public virtual double TicketPrice(Passenger passenger)
        {
            switch (passenger)
            {
                case Child child:
                    return 14;
                case Preferential preferential:
                    return 15;
                case Adult adult:
                    return 25;
                default:
                    return TicketPrice(new Adult(""));
            }
        }
    }
}