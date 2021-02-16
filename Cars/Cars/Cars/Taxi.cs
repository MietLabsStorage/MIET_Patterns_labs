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
        public bool ChildChairsExisting { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        public Taxi(string carNum) : base(carNum)
        {
        }
        
        protected override Driver DriverInstance(string name)
        {
            return Driver ??=  BoardTaxi.Instance().BoardDriver(name);
        }

        /// <summary>
        /// board driver
        /// </summary>
        /// <param name="name">driver name</param>
        public override void BoardDriver(string name)
        {
            DriverInstance(name);
        }

        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="addingAmount">count of peoples in generating queue</param>
        public override List<Passenger.Passenger> BoardPassengers(int addingAmount)
        {
            List<Passenger.Passenger> tmp = new List<Passenger.Passenger>();
            List<Passenger.Passenger> taxiQueue =
                new TaxiQueue(addingAmount).GeneratePassengers(new TaxiPassengersBuilder());
            foreach (var pretender in BoardTaxi.Instance().BoardPassenger(Passengers.Count, ref taxiQueue))
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
            return taxiQueue;
        }

        /// <summary>
        /// cost for ride for passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>cost</returns>
        public override double Cost(Passenger.Passenger passenger)
        {
            try
            {
                return 150.0 / this.Passengers.Count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}