using System;
using System.Collections.Generic;
using System.Linq;
using Cars.BoardCars;

namespace Cars.Cars
{
    public abstract class Car
    {
        private static List<String> _allCarNums = new List<string>();
        
        /// <summary>
        /// Driver
        /// </summary>
        public Driver Driver { get; protected set; } = null;

        /// <summary>
        /// Passengers
        /// </summary>
        public List<Passenger.Passenger> Passengers { get; } = new List<Passenger.Passenger>();
        
        /// <summary>
        /// unique car number
        /// </summary>
        public String CarNum { get; init; }
        
        /// <summary>
        /// is can car ride
        /// </summary>
        public bool IsCanRide => Driver != null && Passengers.Count != 0;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        /// <exception cref="Exception">car number not unique</exception>
        public Car(String carNum)
        {
            if (_allCarNums.All(x => x != carNum))
            {
                CarNum = carNum;
                _allCarNums.Add(carNum);
            }
            else
            {
                throw new Exception($"{carNum} is already registered num for other car");
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="carNum">unique car number</param>
        /// <param name="name">name of driver</param>
        public Car(String carNum, String name): this(carNum)
        {
            Driver = new BoardBus().BoardDriver(name);
        }

        /// <summary>
        /// board driver
        /// </summary>
        /// <param name="name">driver name</param>
        public abstract void BoardDriver(String name);

        /// <summary>
        /// board passengers
        /// </summary>
        /// <param name="addingAmount">count of peoples in generating queue</param>
        public abstract void BoardPassengers(int addingAmount);

        /// <summary>
        /// cost for ride for passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns>cost</returns>
        public abstract int Cost(Passenger.Passenger passenger);

        public override string ToString()
        {
            return $"{CarNum}. driver: {Driver}";
        }
    }
}