using System;
using System.Collections.Generic;

namespace Decanat
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Teacher1"),
                new Teacher("Teacher2"),
                new Teacher("Teacher3")
            };

            foreach (var teacher in teachers)
            {
                StudyWeek.Instance().AddObserver(teacher);
            }

            List<Cathedra> cathedras = new List<Cathedra>()
            {
                new Cathedra("Cth1", new List<Teacher>()
                {
                    teachers[0], teachers[1]
                }),
                new Cathedra("cth2", new List<Teacher>()
                {
                    teachers[1], teachers[2]
                })
            };
            
            AchievementState achievementsStats = AchievementState.Instance();

            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("d1", teachers[0]){Groups = new List<string>(){"G1", "G2"}},
                new Discipline("d2", teachers[1]){Groups = new List<string>(){"G3", "G2"}},
                new Discipline("d3", teachers[1]){Groups = new List<string>(){"G4", "G3"}},
                new Discipline("d4", teachers[2]){Groups = new List<string>(){"G1", "G4"}}
            };

            achievementsStats.Disciplines.AddRange(disciplines);
            
            achievementsStats.AddObserver(Decanat.Instance());
            foreach (var cathedra in cathedras)
            {
                Decanat.Instance().AddObserver(cathedra);
            }

            while (!StudyWeek.Instance().IsSession)
            {
                //new week begin
                StudyWeek.Instance().NewWeek();
                //show info about current week achievements
                Console.WriteLine(achievementsStats.Info(StudyWeek.Instance().Num));
                //show info message for current week for all cathedras
                foreach (var cathedra in cathedras)
                {
                    Console.WriteLine(cathedra.MesInfo(StudyWeek.Instance().Num));
                }
            }
        }
    }
}