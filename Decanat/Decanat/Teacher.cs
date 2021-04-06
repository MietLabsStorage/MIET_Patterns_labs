using System.Linq;

namespace Decanat
{
    public class Teacher: IObserver
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
            var disciplines = AchievementState.Instance().Disciplines.Where(x => x.TeacherCurator == this);
            foreach (var discipline in disciplines)
            {
                AchievementState.Instance().AddRecord(
                    discipline,
                    new Achievement().CreateAchievements(
                        StudyWeek.Instance().Num,
                        discipline.Groups
                    ));
            }

        }

        public override string ToString()
        {
            return Fio;
        }
    }
}