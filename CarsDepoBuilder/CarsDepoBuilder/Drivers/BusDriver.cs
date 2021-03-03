namespace CarsDepoBuilder.Drivers
{
    public class BusDriver: Driver
    {
        public override string DriveLicense => "D";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">driver's name</param>
        public BusDriver(string name) : base(name)
        {
            
        }
     
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver">driver</param>
        public BusDriver(Driver driver) : base(driver.Name)
        {
            
        }

        /// <summary>
        /// override method: for show name of driver
        /// </summary>
        /// <returns>"Bus" + base.ToString()</returns>
        public override string ToString()
        {
            return $"{base.ToString()} license: {DriveLicense}";
        }
        
    }
}