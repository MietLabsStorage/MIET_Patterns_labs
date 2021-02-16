using System.Collections.Generic;

namespace Cars.BoardCars
{
    public class BoardTaxi: IBoardAnyCars
    {
        private static BoardTaxi _instance;

        private BoardTaxi()
        {
        }

        public static BoardTaxi Instance()
        {
            return _instance ??= new BoardTaxi();
        }
        
        /// <summary>
        /// board driver in taxi
        /// </summary>
        /// <param name="name">name of driver</param>
        public Driver BoardDriver(string name)
        {
            return new TaxiDriver(name);
        }

        /// <summary>
        /// board in car passengers
        /// </summary>
        /// <param name="congestion">count of peoples in car</param>
        /// <param name="queue">queue to car</param>
        /// <returns></returns>urns>
        public List<Passenger.Passenger> BoardPassenger(int congestion, ref List<Passenger.Passenger> queue)
        {
            List<Passenger.Passenger> passengers = new List<Passenger.Passenger>();
            int k = 0;
            while (!(passengers.Count == 4 - congestion || k == queue.Count))
            {
                passengers.Add(queue[k]);
                k++;
            }
            queue = queue.GetRange(k, queue.Count - k);
            return passengers;

        }
    }
}