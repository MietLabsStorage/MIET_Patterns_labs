using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    public class Cathedra : IObserver
    {
        public List<Teacher> Teachers { get; } = new List<Teacher>();
        private Dictionary<int, List<Teacher>> BadTeachers { get; } = new Dictionary<int, List<Teacher>>();
        public string Name { get; }

        public Cathedra(string name, List<Teacher> teachers)
        {
            Name = name;
            Teachers.AddRange(teachers);
        }

        public void Update()
        {
            if (Decanat.Instance().Forgotters.ContainsKey(this.Name)) {
                foreach (var teacher in Decanat.Instance().Forgotters[this.Name])
                {
                    if (BadTeachers.ContainsKey(StudyWeek.Instance().Num))
                    {
                        BadTeachers[StudyWeek.Instance().Num].Add(teacher);
                    }
                    else
                    {
                        BadTeachers.Add(StudyWeek.Instance().Num, new List<Teacher>());
                        BadTeachers[StudyWeek.Instance().Num].Add(teacher);
                    }
                }
            }
            else
            {
                BadTeachers.Add(StudyWeek.Instance().Num, new List<Teacher>());
            }
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
            StringBuilder str = new StringBuilder($"Cathedra: {Name} || Week {week}: ");
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

        public override string ToString()
        {
            return this.Name;
        }

    }
}
