using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Cars
{
    public class Bus: Car
    {
        /// <summary>
        /// capacity of passengers
        /// </summary>
        public override int Capacity => 30;

        public virtual double TicketPrice(Passenger passenger)
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
                    return TicketPrice(new Adult(""));
            }
        }
    }
}