namespace Airplane.Leafs
{
    /// <summary>
    /// Stewardess
    /// Extends Leaf
    /// </summary>
    public class Stewardess: Leaf
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of stewardess</param>
        public Stewardess(string name) : base(name, 0, typeof(Stewardess).ToString())
        {
            IsBaggageLoad = false;
        }
    }
}