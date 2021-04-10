using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanat
{
    public class Achievement
    {
        public int Week { get; set; }
        public string Group { get; set; }
        public List<double> Marks { get; } = new List<double>();

        public List<Achievement> CreateAchievements(int week, List<string> groups)
        {
            List<Achievement> achievements = new List<Achievement>();
            if (!IsForgotten)
            {
                foreach (var group in groups)
                {

                    Achievement achievement = new Achievement() { Week = week, Group = group };
                    for (int i = 0; i < 5; i++)
                    {
                        achievement.Marks.Add(Math.Round(Rnd.Random.NextDouble() * 5.88, 1));
                    }

                    achievements.Add(achievement);
                }
            }
            else
            {
                foreach (var group in groups)
                {

                    Achievement achievement = new Achievement() { Week = week, Group = group };
                    achievements.Add(achievement);
                }
            }

            return achievements;
        }

        private bool IsForgotten
        {
            get
            {
                var rnd = Rnd.Random.Next(10) % 3;
                return rnd != 0;
            }
        }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Week: {Week};\t Group: {Group}\t Marks: ");
            for (int i = 0; i < Marks.Count; i++)
            {
                str.Append($"{Marks[i]} | ");
            }

            return str.ToString();
        }
    }
}
