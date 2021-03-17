namespace NewCarDepoBuilder.Passengers
{
    public class Preferential: Passenger
    {
        public Preferential(string name) : base(name) { }

        public override string ToString()
        {
            return $"{this.GetType().Name} {Name}";
        }
    }
}