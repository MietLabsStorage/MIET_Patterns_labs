namespace Airplane.Leafs
{
    /// <summary>
    /// Passenger
    /// Extends Leaf
    /// </summary>
    public class Passenger: Leaf
    {
        public int PaidPartOfBaggage { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of passenger</param>
        /// <param name="baggageWeight">weight of baggage</param>
        public Passenger(string name, int baggageWeight) : base(name, baggageWeight, typeof(Passenger).ToString())
        {
            PaidPartOfBaggage = baggageWeight;
        }
        
        
    }
}