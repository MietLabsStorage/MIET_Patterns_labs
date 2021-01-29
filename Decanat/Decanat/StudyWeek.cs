using System;
using System.Collections.Generic;

namespace Decanat.Properties
{
    public class StudyWeek: IObservable
    {
        /// <summary>
        /// num of current week
        /// </summary>
        public static int Num { get; private set; } = 0;
        
        /// <summary>
        /// num of current week
        /// </summary>
        public int CurrentNum => Num;
        
        /// <summary>
        /// is session now
        /// </summary>
        public bool IsSession => Num >= 18;
        
        /// <summary>
        /// reset num of week
        /// </summary>
        public void Reset() => Num = 0;
        
        private static List<IObserver> Observers { get; } = new List<IObserver>();
        private static StudyWeek _instance; 
        private StudyWeek() {}
        
        /// <summary>
        /// instance of week
        /// </summary>
        /// <returns></returns>
        public static StudyWeek Instance()
        {
            if(_instance == null)
                _instance = new StudyWeek();
            return _instance;
        }
        
        /// <summary>
        /// inc num of week
        /// </summary>
        /// <exception cref="Exception">can't begin new week when session</exception>
        public void NewWeek()
        {
            if (Num <= 18)
            {
                Num++;
                NotifyObservers();
            }
            else
            {
                throw new Exception("Session already");
            }
        }

        /// <summary>
        /// add observer
        /// </summary>
        /// <param name="o"></param>
        public void AddObserver(IObserver o)
        {
            Observers.Add(o);
        }

        /// <summary>
        /// remove observer
        /// </summary>
        /// <param name="o"></param>
        public void RemoveObserver(IObserver o)
        {
            Observers.Remove(o);
        }

        /// <summary>
        /// notify observers (send StudyWeek for observers)
        /// </summary>
        public void NotifyObservers()
        {
            foreach (IObserver o in Observers)
            {
                o.Update(this);
            }
        }
    }
}