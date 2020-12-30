using System.Collections.Generic;

namespace Cars
{
    public abstract class BoardAnyCars
    {
        public Driver Driver { get; protected set; }
        public List<Passenger.Passenger> Passenger { get; } = new List<Passenger.Passenger>();

        /// <summary>
        /// board driver in car
        /// </summary>
        /// <param name="name">name of driver</param>
        public abstract void BoardDriver(string name);

        /// <summary>
        /// board in car passengers
        /// </summary>
        /// <param name="passengers">list of passengers</param>
        /// <returns>passengers who not board</returns>
        public abstract List<Passenger.Passenger> BoardPassenger(List<Passenger.Passenger> passengers);
        
        /// <summary>
        /// check is can car drive
        /// </summary>
        /// <returns>existing of driver</returns>
        public bool IsCanDrive() => Driver != null;
    }
}