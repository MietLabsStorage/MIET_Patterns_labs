using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    public class StudyWeek : IObservable
    {
        private static StudyWeek _instance;

        private StudyWeek(int weeks)
        {
            MaxWeek = weeks;
        }

        public static StudyWeek Instance(int weeks = 18)
        {
            return _instance ?? (_instance = new StudyWeek(weeks));
        }

        public int MaxWeek { get; private set; }
        public int Num { get; private set; } = 0;

        public bool IsSession => Num > MaxWeek;

        public void Reset() => Num = 0;

        public void NewWeek()
        {
            if (!IsSession)
            {
                Num++;
                NotifyObservers();
            }
            else
            {
                throw new Exception("Session is here");
            }
        }

        public List<IObserver> Observers { get; } = new List<IObserver>();
        public void AddObserver(IObserver o)
        {
            Observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            Observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in Observers)
            {
                o.Update();
            }
        }
    }
}
