using System;

namespace Airplane.Composites
{
    public abstract class Passengers: Composite
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of passengers-class</param>
        /// <param name="type">type of passengers-class</param>
        /// <param name="capacity">capacity of passengers-class</param>
        protected Passengers(string name, string type, int capacity) : base(name, type, capacity)
        {
        }
        
        /// <summary>
        /// add passenger
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="Exception">if component is not passenger</exception>
        public override void Add(Component c)
        {
            if (c is Leafs.Passenger)
            {
                base.Add(c);
            }
            else
            {
                throw new Exception($"Can\'t cast Component to {typeof(Leafs.Passenger).ToString()}");
            }
        }


    }
}