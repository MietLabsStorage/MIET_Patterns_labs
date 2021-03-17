namespace NewCarDepoFactory.Drivers
{
    public abstract class Driver
    {
        public string Name { get; set; }
        
        public abstract string DriveLicense { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">driver's name</param>
        protected Driver(string name)
        {
            Name = name;
        }
        
        protected Driver(Driver driver){}
        
        /// <summary>
        /// override method: for show name of driver
        /// </summary>
        /// <returns>$"Driver {Name}"</returns>
        public override string ToString()
        {
            return $"Driver {Name}";
        }
    }
}