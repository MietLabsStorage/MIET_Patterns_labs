namespace Cars
{
    public abstract class Driver
    {
        // name of driver
        private string Name { get; }
        protected string DrivingLicense { get; init; } 
        
        //constructor
        private protected Driver(string name)
        {
            Name = name;
        }

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