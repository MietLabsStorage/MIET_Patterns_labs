using CarsDepoFactory.Drivers;

namespace CarsDepoFactory.Cars
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
    }
}