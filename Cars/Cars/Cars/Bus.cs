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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        /// <param name="name">name of driver</param>
        public Bus(string carNum, string name) : base(carNum, name)
        {
        }

        /// <summary>
        /// board driver
        /// </summary>
        /// <param name="name">driver name</param>
        public override void BoardDriver(string name)
        {
            if (Driver != null)
            {
                Driver = new BoardBus().BoardDriver(name);
            }
        }

        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="addingAmount">count of peoples in generating queue</param>
        public override void BoardPassengers(int addingAmount)
        {
            Passengers.AddRange(new BoardBus().
                BoardPassenger(Passengers.Count, new BusQueue(addingAmount).GeneratePassengers(new BusPassengersBuilder())));
        }

        /// <summary>
        /// cost for ride for passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>cost</returns>
        public override int Cost(Passenger.Passenger passenger)
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