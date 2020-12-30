namespace Cars.Passenger
{
    public class Adult: Passenger
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of passenger</param>
        public Adult(string name) : base(name){}

        /// <summary>
        /// override method
        /// </summary>
        /// <returns>"Adult " + base.ToString()</returns>
        public override string ToString()
        {
            return "Adult " + base.ToString();
        }
    }
}