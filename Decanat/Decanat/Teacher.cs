using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    public class Teacher : IObserver
    {
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
        public void Update()
        {
            var disciplines = AchievementState.Instance().Disciplines.Where(x => x.TeacherCurator.Fio.Equals(this.Fio));
            foreach (var discipline in disciplines)
            {
                AchievementState.Instance().AddRecord(
                    discipline,
                    new Achievement().CreateAchievements(
                        StudyWeek.Instance().Num,
                        discipline.Groups
                    )
                    );
            }

        }

        public override string ToString()
        {
            return Fio;
        }
    }
}
