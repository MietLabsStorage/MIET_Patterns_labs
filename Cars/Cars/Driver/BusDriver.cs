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
        /// override method: for show name of driver
        /// </summary>
        /// <returns>"Bus" + base.ToString()</returns>
        public override string ToString()
        {
            return "Bus" + base.ToString();
        }
    }
}