namespace Cars.Passenger
{
    public class Child: Passenger
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of passenger</param>
        public Child(string name) : base(name){}

        /// <summary>
        /// override method
        /// </summary>
        /// <returns>"Child " + base.ToString()</returns>
        public override string ToString()
        {
            return "Child " + base.ToString();
        }
    }
}