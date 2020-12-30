namespace Cars
{
    public class TaxiDriver: Driver
    {
        private static TaxiDriver _instance;

        private TaxiDriver(string name) : base(name)
        {
            DrivingLicense = "B";
        }

        /// <summary>
        /// get instance of driver
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TaxiDriver Instance(string name)
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