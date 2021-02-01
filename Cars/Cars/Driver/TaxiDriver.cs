using System;

namespace Cars
{
    public class TaxiDriver: Driver
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">driver's name</param>
        public TaxiDriver(string name) : base(name)
        {
            DrivingLicense = "B";
        }

        /// <summary>
        /// get instance
        /// </summary>
        /// <param name="name">name of driver</param>
        /// <returns>instance</returns>
        public override Driver Instance(String name)
        {
            return _instance ??= new TaxiDriver(name);
        }
        
        /// <summary>
        /// override method: for show name of driver
        /// </summary>
        /// <returns>"Taxi" + base.ToString()</returns>
        public override string ToString()
        {
            return "Taxi" + base.ToString();
        }
    }
}