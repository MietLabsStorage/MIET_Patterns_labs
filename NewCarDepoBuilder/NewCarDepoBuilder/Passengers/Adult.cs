namespace NewCarDepoBuilder.Passengers
{
    public class Adult: Passenger
    {
        public Adult(string name): base(name) { }

        public override string ToString()
        {
            return $"{this.GetType().Name} {Name}";
        }
    }
}