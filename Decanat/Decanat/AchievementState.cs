using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    class AchievementState: IObservable
    {
        public List<Discipline> Disciplines { get; } = new List<Discipline>();

        private static AchievementState _instance;
        private AchievementState() { }
        public static AchievementState Instance()
        {
            return _instance ?? (_instance = new AchievementState());
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


        /// <summary>
        /// add record of achievements in discipline
        /// </summary>
        /// <param name="discipline"></param>
        /// <param name="achievements"></param>
        public void AddRecord(Discipline discipline, List<Achievement> achievements)
        {
            //Disciplines.FirstOrDefault(x => x.Equals(discipline))?.Achievements.AddRange(achievements);
            Disciplines.FirstOrDefault(x => x.Name.Equals(discipline.Name))?.Achievements?.AddRange(achievements);
            NotifyObservers();
        }

        public string Info()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= StudyWeek.Instance().Num; i++)
            {
                str.Append($"{Info(i)}\n");
            }

            return str.ToString();
        }

        public string Info(int week)
        {
            StringBuilder str = new StringBuilder($"******Week {week}******\n");
            foreach (var discipline in Disciplines)
            {
                str.Append($"{discipline.MesInfo(week)}\n");
            }
            return str.ToString();
        }
    }
}
