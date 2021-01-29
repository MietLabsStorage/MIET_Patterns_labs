using System.Collections.Generic;
using Decanat.Properties;
using System;

namespace Decanat
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StudyWeek studyWeek = StudyWeek.Instance();

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Teacher1"),
                new Teacher("Teacher2"),
                new Teacher("Teacher3")
            };

            foreach (var teacher in teachers)
            {
                studyWeek.AddObserver(teacher);
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
            
            AchievementsStats achievementsStats = AchievementsStats.Instance();

            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("d1", teachers[0]),
                new Discipline("d2", teachers[1]),
                new Discipline("d3", teachers[1]),
                new Discipline("d4", teachers[2])
            };

            achievementsStats.Disciplines.AddRange(disciplines);
            
            Decanat decanat = new Decanat();
            achievementsStats.AddObserver(decanat);
            foreach (var cathedra in cathedras)
            {
                decanat.AddObserver(cathedra);
            }

            while (!studyWeek.IsSession)
            {
                //new week begin
                studyWeek.NewWeek();
                //show info about current week achievements
                Console.WriteLine(achievementsStats.Info(studyWeek.CurrentNum));
                //show info message for current week for all cathedras
                foreach (var cathedra in cathedras)
                {
                    Console.WriteLine(cathedra.MesInfo(studyWeek.CurrentNum));
                }
            }
        }
    }
}