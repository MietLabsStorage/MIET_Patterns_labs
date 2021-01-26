namespace Airplane.Leafs
{
    /// <summary>
    /// Pilot
    /// Extends Leaf
    /// </summary>
    public class Pilot: Leaf
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of pilot</param>
        public Pilot(string name) : base(name, 0, typeof(Pilot).ToString())
        {
            IsBaggageLoad = false;
        }
    }
}