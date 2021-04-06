using System;
using System.Collections.Generic;
using System.Linq;

namespace Decanat
{
    public class Decanat : IObserver, IObservable
    {
        
        private static Decanat _instance;

        private Decanat()
        {
        }
 
        public static Decanat Instance()
        {
            return _instance ?? (_instance = new Decanat());
        }
        
        public List<Teacher> Forgotters { get; } = new List<Teacher>();

        public void Update()
        {
            Forgotters.Clear();
            var disciplines = AchievementState.Instance().Disciplines;
            if (disciplines != null)
                foreach (var discipline in disciplines.Where(x =>
                    x.Achievements.Count != x.Groups.Count))
                {
                    Forgotters.Add(discipline.TeacherCurator);
                }

            NotifyObservers();
        }

        public List<IObserver> Observers { get; } = new List<IObserver>();

        public void AddObserver(IObserver o)
        {
            Observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            Observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (Teacher teacher in Forgotters)
            {
                foreach (var o in Observers)
                {
                    o.Update();
                }
            }
        }
    }
}