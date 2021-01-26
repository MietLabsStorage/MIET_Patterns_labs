using System;
using System.Collections.Generic;
using System.Text;
using Airplane.Composites;
using Airplane.Leafs;

namespace Airplane
{
    public class Plane
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maxBaggageWeight">max weight for baggage</param>
        public Plane(int maxBaggageWeight)
        {
            MaxBaggageWeight = maxBaggageWeight;
        }
        
        private int MaxBaggageWeight { get; init; }

        public FirstClass FirstClass { get; } = new FirstClass();
        public EconomyClass EconomyClass { get; } = new EconomyClass();
        public BusinessClass BusinessClass { get; } = new BusinessClass();
        public Pilots Pilots { get; } = new Pilots();
        public Stewardesses Stewardess { get; } = new Stewardesses();

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
                foreach(var passenger in EconomyClass.ChildComponents)
                {
                    if (!passenger.IsBaggageLoad && passenger is Passenger)
                    {
                        resetWeight += passenger.BaggageWeight;
                        passengersWithResetBaggage.Append($"*{passenger}\n ");
                    }
                }

                string map =
                    $"Limit weight baggage: {MaxBaggageWeight}\n" +
                    $"{BusinessClass.GetType().ToString()} baggage weight: {BusinessClass.BaggageWeight}\n" +
                    $"{FirstClass.GetType().ToString()} baggage weight: {FirstClass.BaggageWeight}\n" +
                    $"{EconomyClass.GetType().ToString()} baggage weight: {EconomyClass.BaggageWeight}\n" +
                    $"Is can fly up: {IsCanFlyUp}\n" +
                    $"Weight of reset baggage: {resetWeight}\n" +
                    $"Passengers with resetting baggage:\n {passengersWithResetBaggage}";
                
                return map;
            }
        }

        /// <summary>
        /// is can plane fly up
        /// </summary>
        public bool IsCanFlyUp => (MaxBaggageWeight >= FirstClass.BaggageWeight + EconomyClass.BaggageWeight + BusinessClass.BaggageWeight);
        

        private void BalanceBaggage()
        {
            if (EconomyClass.IsBaggageLoad)
            {
                while (MaxBaggageWeight <
                       FirstClass.BaggageWeight + EconomyClass.BaggageWeight + BusinessClass.BaggageWeight
                       && EconomyClass.BaggageWeight != 0)
                {
                    EconomyClass.ResetBaggedLoad();
                }
            }

        }
    }
}