using System;

namespace Airplane.Composites
{
    public class Stewardesses: Composite
    {
        /// <summary>
        /// constructor
        /// </summary>
        public Stewardesses(int capacity = 6) : base(typeof(Stewardesses).ToString(), typeof(Stewardesses).ToString(), capacity)
        {
        }

        /// <summary>
        /// add stewardess 
        /// </summary>
        /// <param name="c">adding stewardess</param>
        /// <exception cref="Exception">if component is not stewardess</exception>
        public override void Add(Component c)
        {
            if (c is Leafs.Stewardess)
            {
                base.Add(c);
            }
            else
            {
                throw new Exception($"Can\'t cast Component to {typeof(Leafs.Stewardess).ToString()}");
            }
        }
    }
}