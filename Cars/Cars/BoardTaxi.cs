using System.Collections.Generic;

namespace Cars
{
    public class BoardTaxi: BoardAnyCars
    {
        /// <summary>
        /// board driver in taxi
        /// </summary>
        /// <param name="name">name of driver</param>
        public override void BoardDriver(string name)
        {
            this.Driver = TaxiDriver.Instance(name);
        }

        /// <summary>
        /// board in taxi passengers
        /// </summary>
        /// <param name="passengers">list of passengers</param>
        /// <returns>passengers who not board</returns>
        public override List<Passenger.Passenger> BoardPassenger(List<Passenger.Passenger> passengers)
        {
            int k = 0;
            while (Passenger.Count < 4 && k < passengers.Count)
            {
                Passenger.Add(passengers[k]);
                k++;
            }
            return passengers.GetRange(k, passengers.Count - k);
        }
    }
}