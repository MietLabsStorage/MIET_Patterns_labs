using System.Collections.Generic;
using NewCarDepoBuilder.Cars;
using NewCarDepoBuilder.Drivers;
using NewCarDepoBuilder.Passengers;

namespace NewCarDepoBuilder.Builders
{
    public interface IBuilder
    {
        void BoardDriver(Driver driver);
        void BoardChild(Child passenger);
        void BoardAdult(Adult passenger);
        void BoardPreferential(Preferential passenger);
    }
}