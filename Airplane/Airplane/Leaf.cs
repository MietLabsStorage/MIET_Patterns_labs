using System;

namespace Airplane
{
    /// <summary>
    /// Leaf-component
    /// </summary>
    public abstract class Leaf: Component
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of leaf</param>
        /// <param name="baggageWeight">weight of baggage of leaf</param>
        /// <param name="type">type of leaf (name of class)</param>
        protected Leaf(string name, int baggageWeight, string type) : base(name, baggageWeight, type)
        {
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="NotImplementedException">always!</exception>
        public override void Add(Component c)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">adding component</param>
        /// <exception cref="NotImplementedException">always!</exception>
        public override void Remove(Component c)
        {
            throw new System.NotImplementedException();
        }
        
    }
}