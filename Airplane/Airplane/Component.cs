namespace Airplane
{
    public abstract class Component
    {
        /// <summary>
        /// name of component
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// weight of baggage of component
        /// </summary>
        public virtual int BaggageWeight { get; private set; }
        
        /// <summary>
        /// is baggage load;
        /// default - true
        /// </summary>
        public bool IsBaggageLoad { get; protected set; }
        
        /// <summary>
        /// id of component
        /// </summary>
        public string Id { get; protected set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name of component</param>
        /// <param name="baggageWeight">weight of baggage of component</param>
        /// <param name="type">type of component (name of class)</param>
        public Component(string name, int baggageWeight, string type)
        {
            Name = name;
            BaggageWeight = (baggageWeight > 5 && baggageWeight < 60 ) ? baggageWeight : 0;
            IsBaggageLoad = true;
            Id = GenerateID(type);
        }

        private static int _idCount = new int();
        private string GenerateID(string type)
        {
            return type + _idCount++;
        }
        
        /// <summary>
        /// add in component
        /// </summary>
        /// <param name="c">adding component</param>
        public abstract void Add(Component c); 
        
        /// <summary>
        /// remove from component
        /// </summary>
        /// <param name="c"></param>
        public abstract void Remove(Component c);

        /// <summary>
        /// set baggage load as false
        /// </summary>
        public virtual void ResetBaggedLoad()
        {
            IsBaggageLoad = false;
        }
        
        /// <summary>
        /// set baggage load as true
        /// </summary>
        public virtual void SetBaggedLoad()
        {
            IsBaggageLoad = true;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Baggage weight: {BaggageWeight}; Is baggage load: {IsBaggageLoad}; Id: {Id}";
        }
    }
}