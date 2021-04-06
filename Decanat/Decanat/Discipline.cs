using System.Collections.Generic;
using System.Text;

namespace Decanat
{
    public class Discipline
    {
        public List<Achievement> Achievements { get; } = new List<Achievement>();
        public Teacher TeacherCurator { get; }
        public List<string> Groups { get; set; } = new List<string>();
        public string Name { get; }
        public Discipline(string name, Teacher teacherCurator)
        {
            Name = name;
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
            var achievement = Achievements.Count > week - 1 ? Achievements[week - 1] : new Achievement();
            return $"Teacher: {TeacherCurator};\t Achievements: {achievement}";
        }
    }
    
}