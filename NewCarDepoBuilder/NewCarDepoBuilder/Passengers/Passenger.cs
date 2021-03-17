namespace NewCarDepoBuilder.Passengers
{
    public abstract class Passenger
    {
        public string Name { get; private set; }
        
        protected Passenger(string name)
        {
            Name = name;
        }
    }
}