using CarsDepoFactory.Drivers;

namespace CarsDepoFactory.Cars
{
    public class Taxi: Car
    {
        /// <summary>
        /// capacity of passengers
        /// </summary>
        public override int Capacity => 4;
        
        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>instance</returns>
        public override Driver DriverInstance(string name="")
        {
            return Driver ?? (Driver = new TaxiDriver(name));
        }

        /// <summary>
        /// Driver instance
        /// </summary>
        /// <param name="driver">driver</param>
        /// <returns>instance</returns>
        public override Driver DriverInstance(Driver driver)
        {
            return Driver ?? (Driver = new TaxiDriver(driver));
        }
    }
}