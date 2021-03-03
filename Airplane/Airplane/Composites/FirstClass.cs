using System;
using Airplane.Leafs;

namespace Airplane.Composites
{
    public class FirstClass: Passengers
    {
        /// <summary>
        /// constructor
        /// </summary>
        public FirstClass(int capacity = 10) : base(typeof(FirstClass).ToString(), typeof(FirstClass).ToString(), capacity)
        {
            
        }

        /// <summary>
        /// add passenger
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="Exception">look inner exception</exception>
        public override void Add(Component c)
        {
            try
            {
                base.Add(c);
                ((Passenger) c).PaidPartOfBaggage = 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}