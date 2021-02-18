namespace CarsDepoFactory.Drivers
{
    public class TaxiDriver: Driver
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">driver's name</param>
        public TaxiDriver(string name) : base(name)
        {
            
        }
        
        public TaxiDriver(Driver driver) : base(driver.Name)
        {
            
        }

        public override string DriveLicense => "B";

        /// <summary>
        /// override method: for show name of driver
        /// </summary>
        /// <returns>"Taxi" + base.ToString()</returns>
        public override string ToString()
        {
            return $"{base.ToString()} license: {DriveLicense}";
        }
    }
}