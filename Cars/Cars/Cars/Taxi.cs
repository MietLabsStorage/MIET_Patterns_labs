using System;
using System.Collections.Generic;
using Cars.BoardCars;
using Cars.Passenger;
using Cars.PassengersBuilder;
using Cars.PassengersQueue;

namespace Cars.Cars
{
    public class Taxi : Car
    {
        private bool ChildChairsExisting { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        public Taxi(string carNum) : base(carNum)
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        /// <param name="name">name of driver</param>
        public Taxi(string carNum, string name) : base(carNum, name)
        {
        }

        /// <summary>
        /// board driver
        /// </summary>
        /// <param name="name">driver name</param>
        public override void BoardDriver(string name)
        {
            if (Driver != null)
            {
                Driver = new BoardTaxi().BoardDriver(name);
            }
        }

        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="addingAmount">count of peoples in generating queue</param>
        public override void BoardPassengers(int addingAmount)
        {
            List<Passenger.Passenger> tmp = new List<Passenger.Passenger>();
            foreach (var pretender in new BoardBus().BoardPassenger(Passengers.Count,
                new TaxiQueue(addingAmount).GeneratePassengers(new TaxiPassengersBuilder())))
            {
                if (pretender is Adult)
                {
                    tmp.Add(pretender);
                    continue;
                }

                if (pretender is Child)
                {
                    if (ChildChairsExisting)
                    {
                        tmp.Add(pretender);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Sorry, I have no childchairs");
                    }
                }

                if (pretender is Preferential)
                {
                    throw new Exception("Sorry, we don't transport preferentials");
                }
            }
            Passengers.AddRange(tmp);
        }

        /// <summary>
        /// cost for ride for passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>cost</returns>
        public override int Cost(Passenger.Passenger passenger)
        {
            try
            {
                return 150 / Passengers.Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}