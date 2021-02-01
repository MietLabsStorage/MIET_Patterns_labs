using System;

namespace Cars
{
    public abstract class Driver
    {
        protected string Name { get; }
        protected string DrivingLicense { get; init; } 
        
        protected static Driver _instance;

        protected Driver(String name)
        {
            Name = name;
        }

        /// <summary>
        /// get instance
        /// </summary>
        /// <param name="name">name of driver</param>
        /// <returns>instance</returns>
        public abstract Driver Instance(String name);
        
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