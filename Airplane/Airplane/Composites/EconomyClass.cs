using System;
using Airplane.Leafs;

namespace Airplane.Composites
{
    public class EconomyClass: Passengers
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EconomyClass(int capacity = 150) : base(typeof(EconomyClass).ToString(), typeof(EconomyClass).ToString(), capacity)
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
                    ((Passenger) c).PaidPartOfBaggage < 20 ? ((Passenger) c).PaidPartOfBaggage : 20;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}