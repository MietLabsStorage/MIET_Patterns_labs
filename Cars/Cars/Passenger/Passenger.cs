namespace Cars.Passenger
{
    public abstract class Passenger
    {
        /// <summary>
        /// name of passenger
        /// </summary>
        public string Name { get; init; }

        //constructor
        public Passenger(string name)
        {
            Name = name;
        }

        /// <summary>
        /// override method
        /// </summary>
        /// <returns>name of passenger</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}