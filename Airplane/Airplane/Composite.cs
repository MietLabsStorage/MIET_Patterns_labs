using System;
using System.Collections.Generic;
using System.Linq;

namespace Airplane
{
    public abstract class Composite: Component
    {
        /// <summary>
        /// list of child components
        /// </summary>
        public List<Component> ChildComponents { get; } = new List<Component>();
        
        /// <summary>
        /// capacity for adding components in this composite
        /// </summary>
        private int Capacity { get; init; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of composite</param>
        /// <param name="type">type of composite (name of class)</param>
        /// <param name="capacity">capacity for adding components in this composite</param>
        protected Composite(string name, string type, int capacity) : base(name, 0, type)
        {
            Capacity = capacity;
        }

        /// <summary>
        /// eight of baggage of composite
        /// </summary>
        public override int BaggageWeight
        {
            get
            {
                if (IsBaggageLoad)
                {
                    int sumWeight = 0;
                    foreach (Component component in ChildComponents)
                    {
                        sumWeight += component.IsBaggageLoad ? component.BaggageWeight : 0;
                    }

                    return sumWeight;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// add in composite
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="Exception">capacity overflow</exception>
        public override void Add(Component c)
        {
            if (ChildComponents.Count < Capacity)
            {
                ChildComponents.Add(c);
            }
            else
            {
                throw new Exception("Capacity overflow");
            }
        }

        /// <summary>
        /// remove from composite
        /// </summary>
        /// <param name="c">adding component</param>
        public override void Remove(Component c)
        {
            if (ChildComponents.Count < Capacity)
            {
                ChildComponents.Remove(c);
            }
        }

        /// <summary>
        /// set baggage load for child component with max baggage weight as false
        /// </summary>
        public override void ResetBaggedLoad()
        {
            ChildComponents.FirstOrDefault(
                    component => component.BaggageWeight == ChildComponents.Where(w => w.IsBaggageLoad == true).Max(
                        w => w.BaggageWeight))
                ?.ResetBaggedLoad();
        }

        /// <summary>
        /// set baggage load for child component with min baggage weight from false baggage load as true
        /// </summary>
        public override void SetBaggedLoad()
        {
            ChildComponents.FirstOrDefault(
                    component => component.BaggageWeight == ChildComponents.Where(w => w.IsBaggageLoad == false).Min(
                        w => w.BaggageWeight))
                ?.SetBaggedLoad();
        }
    }
}