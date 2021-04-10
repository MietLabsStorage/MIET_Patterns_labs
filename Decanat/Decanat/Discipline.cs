using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    public class Discipline
    {
        public List<Achievement> Achievements { get; } = new List<Achievement>();
        public Teacher TeacherCurator { get; }
        public Cathedra CathedraCurator { get; }
        public List<string> Groups { get; set; } = new List<string>();
        public string Name { get; }
        public Discipline(string name, Cathedra cathedraCurator, Teacher teacherCurator)
        {
            Name = name;
            CathedraCurator = cathedraCurator;
            TeacherCurator = teacherCurator;
        }

        public string MesInfo()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= StudyWeek.Instance().Num; i++)
            {
                str.Append($"{MesInfo(i)}\n");
            }

            return str.ToString();
        }

        public string MesInfo(int week)
        {
            //var achievement = Achievements.Count > week - 1 ? Achievements[week - 1] : new Achievement { Week = StudyWeek.Instance().Num };
            //return $"{Name}:: Teacher: {TeacherCurator};\t Achievements: {achievement}";
            StringBuilder str = new StringBuilder();
            foreach(var achievement in Achievements.Where(x => x.Week == week))
            {
                str.Append($"{Name}:: Cathedra: {CathedraCurator} Teacher: {TeacherCurator};\t Achievements: {achievement}\n");
            }
            return str.ToString();
        }
    }
}
