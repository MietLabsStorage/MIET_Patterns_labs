using System;
using System.Text;
using Airplane.Composites;
using Airplane.Leafs;

namespace Airplane
{
    public class Plane: Composite
    {
        private int MaxBaggageWeight { get; set; }
        public Plane(string name, string type,int maxBaggageWeight, int capacity = 6) : base(name, type, capacity)
        {
            MaxBaggageWeight = maxBaggageWeight;
            this.Add(new Pilots());
            this.Add(new Stewardesses());
            this.Add(new FirstClass());
            this.Add(new EconomyClass());
            this.Add(new BusinessClass());
        }
        
        public override void Add(Component c)
        {
            if (c is Pilots || c is Stewardesses || c is Passengers)
            {
                base.Add(c);
            }
            else
            {
                throw new Exception($"Can\'t cast Component");
            }
        }
        
         /// <summary>
        /// generate load map
        /// </summary>
        public string LoadMap
        {
            get
            {
                BalanceBaggage();
                int resetWeight = new int();
                StringBuilder passengersWithResetBaggage = new StringBuilder();
                foreach(var passenger in (this["EconomyClass"] as EconomyClass)?.ChildComponents)
                {
                    if (!passenger.IsBaggageLoad && passenger is Passenger)
                    {
                        resetWeight += passenger.BaggageWeight;
                        passengersWithResetBaggage.Append($"*{passenger}\n ");
                    }
                }

                string map =
                    $"*****Load map*****\n" + 
                    $"Limit weight baggage: {MaxBaggageWeight}\n" +
                    $"{(this["BusinessClass"] as BusinessClass)?.GetType().ToString()} baggage weight: {(this["BusinessClass"] as BusinessClass)?.BaggageWeight}\n" +
                    $"{(this["FirstClass"] as FirstClass)?.GetType().ToString()} baggage weight: {(this["FirstClass"] as FirstClass)?.BaggageWeight}\n" +
                    $"{(this["EconomyClass"] as EconomyClass)?.GetType().ToString()} baggage weight: {(this["EconomyClass"] as EconomyClass)?.BaggageWeight}\n" +
                    $"Is can fly up: {IsCanFlyUp}\n" +
                    $"Weight of reset baggage: {resetWeight}\n" +
                    $"Passengers with resetting baggage:\n {passengersWithResetBaggage}" +
                    $"******************";
                
                return map;
            }
        }

        /// <summary>
        /// is can plane fly up
        /// </summary>
        public bool IsCanFlyUp => (MaxBaggageWeight >= (this["FirstClass"] as FirstClass)?.BaggageWeight + (this["EconomyClass"] as EconomyClass)?.BaggageWeight + (this["BusinessClass"] as BusinessClass)?.BaggageWeight);
        

        private void BalanceBaggage()
        {
            if ((this["EconomyClass"] as EconomyClass)?.IsBaggageLoad ?? false)
            {
                while (MaxBaggageWeight <
                       (this["FirstClass"] as FirstClass)?.BaggageWeight + (this["EconomyClass"] as EconomyClass)?.BaggageWeight + (this["BusinessClass"] as BusinessClass)?.BaggageWeight
                       && (this["EconomyClass"] as EconomyClass)?.BaggageWeight != 0)
                {
                    (this["EconomyClass"] as EconomyClass)?.ResetBaggedLoad();
                }
            }

        }

        public Component this[string index]
        {
            get
            {
                switch (index)
                {
                    case "Pilots":
                        return ChildComponents[0];
                    
                    case "Stewardesses":
                        return ChildComponents[1];
                    
                    case "FirstClass":
                        return ChildComponents[2];
                    
                    case "EconomyClass":
                        return ChildComponents[3];
                    
                    case "BusinessClass":
                        return ChildComponents[4];

                    default: 
                        return null;
                } 
            }
        }
    }
}