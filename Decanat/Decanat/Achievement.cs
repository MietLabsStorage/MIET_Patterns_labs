using System;
using System.Collections.Generic;
using System.Text;

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

                    Achievement achievement = new Achievement {Week = week, Group = group};
                    for (int i = 0; i < 10; i++)
                    {
                        achievement.Marks.Add(new Random().NextDouble() * 5.88);
                    }

                    achievements.Add(achievement);
                }
            }

            return achievements;
        }

        private bool IsForgotten
        {
            get
            {
                var rnd = new Random().Next(10) % 3;
                return rnd != 0;
            }
        }
    

        public override string ToString()
        {
            StringBuilder str = new StringBuilder($"Week: {Week};\t Group: {Group}\t Marks: ");
            for (int i = 1; i <= Marks.Count; i++)
            {
                str.Append($"{Marks[i]}");
            }

            return str.ToString();
        }
    }
}