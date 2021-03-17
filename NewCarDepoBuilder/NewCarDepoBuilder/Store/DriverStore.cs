using System;
using System.Collections.Generic;
using System.Linq;
using NewCarDepoBuilder.Drivers;

namespace NewCarDepoBuilder.Store
{
    public class DriverStore
    {
        private List<Driver> Drivers { get; set; } = new List<Driver>();
        
        public int Count(Type driverType) => Drivers.Count(x => x.GetType() == driverType);

        public void Add(Driver driver)
        {
            Drivers.Add(driver);
        }

        public void AddList(List<Driver> drivers)
        {
            Drivers.AddRange(drivers);
        }

        public Driver GetDriver(Type driverType)
        {
            Driver driver = Drivers.First(x => x.GetType() == driverType);
            Drivers.Remove(driver);
            return driver;
        }

        public override string ToString()
        {
            string str = "";
            foreach (var driver in Drivers)
            {
                str += $"{driver}\n";
            }

            return str;
        }
    }
}