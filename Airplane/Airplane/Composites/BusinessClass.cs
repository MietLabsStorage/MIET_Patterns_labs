using System;
using Airplane.Leafs;

namespace Airplane.Composites
{
    public class BusinessClass: Passengers
    {
        /// <summary>
        /// constructor
        /// </summary>
        public BusinessClass(int capacity = 20) : base(typeof(BusinessClass).ToString(), typeof(BusinessClass).ToString(), capacity)
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
                ((Passenger) c).PaidPartOfBaggage -=
                    ((Passenger) c).PaidPartOfBaggage < 35 ? ((Passenger) c).PaidPartOfBaggage : 35;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}