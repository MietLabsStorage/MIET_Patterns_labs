namespace Cars
{
    public class BusDriver: Driver
    {
        private static BusDriver _instance;

        private BusDriver(string name) : base(name)
        {
            DrivingLicense = "D";
        }

        /// <summary>
        /// get instance of driver
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static BusDriver Instance(string name)
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