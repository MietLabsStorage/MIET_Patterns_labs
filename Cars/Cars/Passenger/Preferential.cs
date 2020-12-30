namespace Cars.Passenger
{
    public class Preferential: Passenger
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of passenger</param>
        public Preferential(string name) : base(name){}

        /// <summary>
        /// override method
        /// </summary>
        /// <returns>"Preferential " + base.ToString()</returns>
        public override string ToString()
        {
            return "Preferential " + base.ToString();
        }
    }
}