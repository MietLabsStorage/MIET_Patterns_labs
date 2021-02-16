using System.Collections.Generic;
using Cars.BoardCars;
using Cars.Passenger;
using Cars.PassengersBuilder;
using Cars.PassengersQueue;

namespace Cars.Cars
{
    public class Bus: Car
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        public Bus(string carNum) : base(carNum)
        {
        }
        

        protected override Driver DriverInstance(string name)
        {
            return Driver ??= BoardBus.Instance().BoardDriver(name);
        }

        /// <summary>
        /// board driver
        /// </summary>
        /// <param name="name">driver name</param>
        public override void BoardDriver(string name)
        {
            DriverInstance(name);
        }

        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="addingAmount">count of peoples in generating queue</param>
        public override List<Passenger.Passenger> BoardPassengers(int addingAmount)
        {
            List<Passenger.Passenger> busQueue = new BusQueue(addingAmount).GeneratePassengers(new BusPassengersBuilder());
            Passengers.AddRange(BoardBus.Instance().BoardPassenger(Passengers.Count, ref busQueue));
            return busQueue;
        }

        /// <summary>
        /// cost for ride for passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>cost</returns>
        public override double Cost(Passenger.Passenger passenger)
        {
            switch (passenger)
            {
                case Child child:
                    return 14;
                case Preferential preferential:
                    return 15;
                case Adult adult:
                    return 25;
                default:
                    return Cost(new Adult(""));
            }
        }
    }
}