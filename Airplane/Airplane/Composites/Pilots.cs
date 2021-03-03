using System;

namespace Airplane.Composites
{
    public class Pilots: Composite
    {
        /// <summary>
        /// constructor
        /// </summary>
        public Pilots(int capacity = 2) : base(typeof(Pilots).ToString(), typeof(Pilots).ToString(), capacity)
        {
        }

        /// <summary>
        /// add pilot
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="Exception">if component is not pilot</exception>
        public override void Add(Component c)
        {
            if (c is Leafs.Pilot)
            {
                base.Add(c);
            }
            else
            {
                throw new Exception($"Can\'t cast Component to {typeof(Leafs.Pilot).ToString()}");
            }
        }
    }
}