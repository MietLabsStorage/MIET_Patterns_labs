namespace NewCarDepoFactory.Passengers
{
    public class BusPassenger: Passenger
    {
        public string Ticket { get; set; }
        
        public BusPassenger(string name, string ticket) : base(name)
        {
            Ticket = ticket;
        }

        public override string ToString()
        {
            return $"{base.ToString()} #{Ticket}";
        }
    }
}