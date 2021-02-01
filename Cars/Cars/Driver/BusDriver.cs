using System;

namespace Cars
{
    public class BusDriver: Driver
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">driver's name</param>
        public BusDriver(string name) : base(name)
        {
            DrivingLicense = "D";
        }
        
        /// <summary>
        /// get instance
        /// </summary>
        /// <param name="name">name of driver</param>
        /// <returns>instance</returns>
        public override Driver Instance(String name)
        {
            return _instance ??= new BusDriver(name);
        }

        /// <summary>
        /// override method: for show name of driver
        /// </summary>
        /// <returns>"Bus" + base.ToString()</returns>
        public override string ToString()
        {
            return "Bus" + base.ToString();
        }
    }
}