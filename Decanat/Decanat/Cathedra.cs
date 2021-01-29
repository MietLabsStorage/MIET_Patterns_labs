using System;
using System.Collections.Generic;
using System.Text;
using Decanat.Properties;

namespace Decanat
{
    public class Cathedra: IObserver
    {
        public List<Teacher> Teachers { get; } = new List<Teacher>();
        private Dictionary<int, List<Teacher>> BadTeachers { get; } = new Dictionary<int, List<Teacher>>();
        public string Name { get; }

        public Cathedra(string name, List<Teacher> teachers)
        {
            Name = name;
            Teachers.AddRange(teachers);
        }

        public void Update(object o)
        {

            if (BadTeachers.ContainsKey(StudyWeek.Num))
            {
                BadTeachers[StudyWeek.Num].Add(o as Teacher);
            }
            else
            {
                BadTeachers.Add(StudyWeek.Num, new List<Teacher>());
            }
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
            StringBuilder str = new StringBuilder($"Week {week}: ");
            if (BadTeachers[week].Count == 0)
            {
                str.Append("all ok");
            }
            else
            {
                foreach (var teacher in BadTeachers[week])
                {
                    str.Append($"{teacher.Fio}; ");
                }
            }

            return str.ToString();
        }
    }
}