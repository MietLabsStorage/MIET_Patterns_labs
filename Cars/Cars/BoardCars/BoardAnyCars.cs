using System.Collections.Generic;

namespace Cars.BoardCars
{
    public interface IBoardAnyCars
    {
        /// <summary>
        /// board driver in car
        /// </summary>
        /// <param name="name">name of driver</param>
        Driver BoardDriver(string name);
        
        /// <summary>
        /// board in car passengers
        /// </summary>
        /// <param name="congestion">count of peoples in car</param>
        /// <param name="queue">queue to car</param>
        /// <returns></returns>
        List<Passenger.Passenger> BoardPassenger(int congestion, List<Passenger.Passenger> queue);
        
    }
}