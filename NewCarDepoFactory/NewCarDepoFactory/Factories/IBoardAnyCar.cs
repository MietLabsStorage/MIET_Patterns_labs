using NewCarDepoFactory.Cars;
using NewCarDepoFactory.Store;

namespace NewCarDepoFactory.Factories
{
    public interface IBoardAnyCar
    {
        Car Car { get; }
        int BoardDriver(DriverStore driverStore, int amount = 1);
        int BoardPassengers(PassengerStore passengerStore, int amount);
        Car GetCar();

    }
}