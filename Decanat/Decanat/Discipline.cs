using System.Collections.Generic;
using System.Text;
using Decanat.Properties;

namespace Decanat
{
    public class Discipline
    {
        /// <summary>
        /// list of achievements
        /// </summary>
        public List<Achievement> Achievements { get; set; } = new List<Achievement>();
        
        /// <summary>
        /// teacher
        /// </summary>
        public Teacher TeacherCurator { get; }
        
        /// <summary>
        /// list of groups
        /// </summary>
        public List<string> Groups { get; set; } = new List<string>();

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; }
        public Discipline(string name, Teacher teacherCurator)
        {
            Name = name;
            TeacherCurator = teacherCurator;
        }
        
        public string MesInfo()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 1; i <= StudyWeek.Num; i++)
            {
                str.Append($"{MesInfo(i)}\n");
            }

            return str.ToString();
        }
        
        public string MesInfo(int week)
        {
            return $"Teacher: {TeacherCurator};\t Achievements: {Achievements[week-1].ToString()}";
        }
    }
}