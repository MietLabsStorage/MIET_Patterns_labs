using System;
using System.Collections.Generic;
using System.Linq;
using Decanat.Properties;

namespace Decanat
{
    public class Decanat:IObserver, IObservable
    {
        private List<IObserver> _observers { get; } = new List<IObserver>();
        private List<Teacher> Forgotters { get; set; } = new List<Teacher>();
        public void Update(Object o)
        {
            var disciplines = (o as AchievementsStats)?.Disciplines;
            if (disciplines != null)
                foreach (var discipline in disciplines.Where(x =>
                    x.Achievements.Count != x.Groups.Count))
                {
                    Forgotters.Add(discipline.TeacherCurator);
                }
            NotifyObservers();
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void NotifyObservers()
        {
            foreach (Teacher teacher in Forgotters)
            {
                foreach (var o in _observers)
                {
                    if ((o as Cathedra)?.Teachers.Contains(teacher) ?? false)
                    {
                        o.Update(teacher);
                    }
                }
            }
        }
    }
}