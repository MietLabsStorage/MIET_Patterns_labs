namespace NewCarDepoFactory.Passengers
{
    public class TaxiPassenger: Passenger
    {
        public double Rating { get; set; }
        
        public TaxiPassenger(string name, double rating) : base(name)
        {
            Rating = rating;
        }
        
        public override string ToString()
        {
            return $"{base.ToString()} #{Rating}";
        }
    }
}