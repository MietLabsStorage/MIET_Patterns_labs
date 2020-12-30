namespace Cars.Passenger
{
    public class BusPassengersBuilder: PassengersBuilder
    {
        /// <summary>
        /// add adult passenger
        /// </summary>
        /// <param name="passenger">adult passenger</param>
        public override void AddAdult(Adult passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// add child passenger
        /// </summary>
        /// <param name="passenger">child passenger</param>
        public override void AddChild(Child passenger)
        {
            Passengers.Add(passenger);
        }

        /// <summary>
        /// add preferential passenger
        /// </summary>
        /// <param name="passenger">preferential passenger</param>
        public override void AddPreferential(Preferential passenger)
        {
            Passengers.Add(passenger);
        }
    }
}