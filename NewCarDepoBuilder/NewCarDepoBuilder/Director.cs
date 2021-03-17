using System;
using System.Collections.Generic;
using NewCarDepoBuilder.Builders;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;
using NewCarDepoBuilder.Store;

namespace NewCarDepoBuilder
{
    public class Director
    {
        public IBuilder Builder { get; set; }
        public DriverStore DriverStore { get; set; }
        public PassengerStore PassengerStore { get; set; }

        public Director(IBuilder builder, DriverStore driverStore, PassengerStore passengerStore)
        {
            Builder = builder;
            DriverStore = driverStore;
            PassengerStore = passengerStore;
        }

        public void BuildCar()
        {
            switch (Builder)
            {
                case BusBuilder busBuilder:
                    BuildBus();
                    break;
                case TaxiBuilder taxiBuilder:
                    BuildTaxi();
                    break;
            }
        }

        private void BuildBus()
        {
            if (((BusBuilder) Builder).Car.Driver == null)
            {
                Builder.BoardDriver(DriverStore.GetDriver(typeof(BusDriver)));
            }
            while (((BusBuilder) Builder).Car.Passengers.Count != ((BusBuilder) Builder).Car.Capacity)
            {
                Passenger passenger = PassengerStore.GetPassenger(new HashSet<Type>(){typeof(Adult), typeof(Child), typeof(Preferential)});
                switch (passenger)
                {
                    case Child child:
                        Builder.BoardChild(child);
                        break;
                    case Preferential preferential:
                        Builder.BoardPreferential(preferential);
                        break;
                    case Adult adult:
                        Builder.BoardAdult(adult);
                        break;
                }
            }
        }
        
        private void BuildTaxi()
        {
            if (((TaxiBuilder) Builder).Car.Driver == null)
            {
                Builder.BoardDriver(DriverStore.GetDriver(typeof(TaxiDriver)));
            }
            while (((TaxiBuilder) Builder).Car.Passengers.Count != ((TaxiBuilder) Builder).Car.Capacity)
            {
                Passenger passenger = PassengerStore.GetPassenger(new HashSet<Type>(){typeof(Adult), typeof(Child)});
                switch (passenger)
                {
                    case Child child:
                        Builder.BoardChild(child);
                        break;
                    case Adult adult:
                        Builder.BoardAdult(adult);
                        break;
                }
            }
        }
        
        
    }
}