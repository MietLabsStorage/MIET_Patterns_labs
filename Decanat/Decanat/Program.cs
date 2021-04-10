using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Teach1"),
                new Teacher("Teach2"),
                new Teacher("Teach3")
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
                new Cathedra("Cth2", new List<Teacher>()
                {
                    teachers[1], teachers[2]
                })
            };

            AchievementState achievementsStats = AchievementState.Instance();

            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("d1", cathedras[0], teachers[0]){Groups = new List<string>(){"G1", "G2"}},
                new Discipline("d2", cathedras[0], teachers[1]){Groups = new List<string>(){"G3", "G2"}},
                new Discipline("d3", cathedras[1], teachers[1]){Groups = new List<string>(){"G4", "G3"}},
                new Discipline("d4", cathedras[1], teachers[2]){Groups = new List<string>(){"G1", "G4"}}
            };

            achievementsStats.Disciplines.AddRange(disciplines);

            //achievementsStats.AddObserver(Decanat.Instance());
            StudyWeek.Instance().AddObserver(Decanat.Instance());
            foreach (var cathedra in cathedras)
            {
                Decanat.Instance().AddObserver(cathedra);
            }


            StudyWeek.Instance().NewWeek();
            while (!StudyWeek.Instance().IsSession)
            {
                //show info about current week achievements
                Console.WriteLine(achievementsStats.Info(StudyWeek.Instance().Num));
                //show info message for current week for all cathedras
                Console.WriteLine($"Bad teaqchers on {StudyWeek.Instance().Num}th week:");
                foreach (var cathedra in cathedras)
                {
                    Console.WriteLine(cathedra.MesInfo(StudyWeek.Instance().Num));
                }
                Console.WriteLine();

                //new week begin
                StudyWeek.Instance().NewWeek();

            }

            Console.ReadKey();
        }
    }
}
