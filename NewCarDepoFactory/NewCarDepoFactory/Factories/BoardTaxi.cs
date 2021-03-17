using NewCarDepoFactory.Cars;
using NewCarDepoFactory.Drivers;
using NewCarDepoFactory.Passengers;
using NewCarDepoFactory.Store;

namespace NewCarDepoFactory.Factories
{
    public class BoardTaxi : IBoardAnyCar
    {
        
        public Car Car { get; private set; }
        public int BoardDriver(DriverStore driverStore, int amount = 1)
        {
            if (Car.Driver  == null && driverStore.Count(typeof(TaxiDriver)) != 0)
            {
                Car.Driver = driverStore.GetDriver(typeof(TaxiDriver));
                return amount - 1;
            }
            else
            {
                return amount;
            }
        }

        public int BoardPassengers(PassengerStore passengerStore, int amount)
        {
            int k = amount;
            while (Car.Passengers.Count < Car.Capacity && amount > 0 && passengerStore.Count(typeof(TaxiPassenger)) != 0 )
            {
                Car.Passengers.Add(passengerStore.GetPassenger(typeof(TaxiPassenger)));
                k--;
            }

            return amount - k;
        }

        public Car GetCar()
        {
            if(Car.Driver != null && Car.Passengers.Count != 0)
            {
                Car rCar = this.Car;
                this.Car = new Taxi();
                return rCar;
            }
            else
            {
                return null;
            }
        }

        public BoardTaxi()
        {
            Car = new Taxi();
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {Car.Driver} - driver; {Car.Passengers.Count} passengers \n";
        }
    }
}