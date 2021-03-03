namespace CarsDepoBuilder.Passengers
{
    public class Child: Passenger
    {
        public Child(string name): base(name) { }

        public override string ToString()
        {
            return $"{this.GetType().Name} {Name}";
        }
    }
}