using System;

namespace Cars
{
    public abstract class Driver
    {
        public string Name { get; }
        public string DrivingLicense { get; init; } 
        
        public Driver(String name)
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