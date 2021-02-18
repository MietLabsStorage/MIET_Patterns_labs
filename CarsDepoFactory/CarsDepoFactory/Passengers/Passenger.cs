namespace CarsDepoFactory.Passengers
{
    public abstract class Passenger
    {
        public string Name { get; protected set; }

        protected Passenger(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Passenger {Name}";
        }
    }
}