using System;
using System.Linq;
using Decanat.Properties;

namespace Decanat
{
    public class Teacher: IObserver
    {
        /// <summary>
        /// Name, surname, parent name
        /// </summary>
        public string Fio { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="fio"></param>
        public Teacher(string fio)
        {
            Fio = fio;
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="o">preferably as study week</param>
        public void Update(Object o)
        {
            var disciplines = AchievementsStats.Instance().Disciplines.Where(x => x.TeacherCurator == this);
            foreach (var discipline in disciplines)
            {
                AchievementsStats.Instance().AddRecord(
                    discipline,
                    new Achievement().CreateAchievements(
                        (o as StudyWeek)?.CurrentNum ?? -1,
                        discipline.Groups
                    ));
            }

        }
    }
}