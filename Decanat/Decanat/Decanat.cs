using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Dictionary<String, List<Teacher>> Forgotters { get; } = new Dictionary<String, List<Teacher>>();

        public void Update()
        {
            /*Forgotters.Clear();
            var disciplines = AchievementState.Instance().Disciplines;
            if (disciplines != null)
                foreach (var discipline in disciplines.Where(x =>
                    x.Achievements.Count != x.Groups.Count))
                {
                    Forgotters.Add(discipline.TeacherCurator);
                }
            */
            Forgotters.Clear();
            var disciplines = AchievementState.Instance().Disciplines;
            foreach (var discipline in disciplines/*.Where(x => x == x.Achievements.Where(y => y.Marks.Count == 0))*/)
            {
                if (discipline.Achievements.Where(x => x.Week == StudyWeek.Instance().Num).FirstOrDefault<Achievement>()?.Marks.Count == 0)
                {
                    if (Forgotters.ContainsKey(discipline.CathedraCurator.Name))
                    {
                        Forgotters[discipline.CathedraCurator.Name].Add(discipline.TeacherCurator);
                    }
                    else
                    {
                        Forgotters[discipline.CathedraCurator.Name] = new List<Teacher>();
                        Forgotters[discipline.CathedraCurator.Name].Add(discipline.TeacherCurator);
                    }
                }
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
            foreach (var o in Observers)
            {
                o.Update();
            }

        }
    }
}
