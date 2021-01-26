using System;
using Airplane.Leafs;

namespace Airplane.Composites
{
    public class EconomyClass: Passengers
    {
        /// <summary>
        /// constructor
        /// </summary>
        public EconomyClass() : base(typeof(EconomyClass).ToString(), typeof(EconomyClass).ToString(), 150)
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
                    ((Passenger) c).PaidPartOfBaggage < 35 ? ((Passenger) c).PaidPartOfBaggage : 25;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}