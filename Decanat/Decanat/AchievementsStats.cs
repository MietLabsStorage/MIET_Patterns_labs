using System.Collections.Generic;
using System.Linq;
using System.Text;
using Decanat.Properties;

namespace Decanat
{
    public class AchievementsStats:IObservable
    {
        /// <summary>
        /// list of disciplines
        /// </summary>
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
        
        /// <summary>
        /// instance of AchievementStats
        /// </summary>
        /// <returns></returns>
        public static AchievementsStats Instance()
        {
            if(_instance == null)
                _instance = new AchievementsStats();
            return _instance;
        }
        private List<IObserver> _observers { get; } = new List<IObserver>();
        private static AchievementsStats _instance;
        private AchievementsStats() {}
        
        /// <summary>
        /// add observer
        /// </summary>
        /// <param name="o"></param>
        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        /// <summary>
        /// remove observer
        /// </summary>
        /// <param name="o"></param>
        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        /// <summary>
        /// notify observers (send AchievementStats)
        /// </summary>
        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(this);
            }
        }
        
        /// <summary>
        /// add record of achievements in discipline
        /// </summary>
        /// <param name="discipline"></param>
        /// <param name="achievements"></param>
        public void AddRecord(Discipline discipline, List<Achievement> achievements)
        {
            Disciplines.FirstOrDefault(x => x.Equals(discipline))?.Achievements.AddRange(achievements);
            NotifyObservers();
        }

        public string Info()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= StudyWeek.Num; i++)
            {
                str.Append($"{Info(i)}\n");
            }

            return str.ToString();
        }
        
        public string Info(int week)
        {
            StringBuilder str = new StringBuilder($"******Week {week}******");
            foreach (var discipline in Disciplines)
            {
                str.Append(discipline.MesInfo(week));
            }

            return str.ToString();
        }
    }
}