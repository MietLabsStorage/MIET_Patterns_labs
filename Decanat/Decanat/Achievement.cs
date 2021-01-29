using System;
using System.Collections.Generic;
using System.Text;
using Decanat.Properties;

namespace Decanat
{
    public class Achievement
    {
        /// <summary>
        /// num of week
        /// </summary>
        public int Week { get; set; }
        
        /// <summary>
        /// group
        /// </summary>
        public string Group { get; set; }
        
        /// <summary>
        /// marks
        /// </summary>
        public List<double> Marks { get; set; } = new List<double>();

        /// <summary>
        /// create new achievement
        /// </summary>
        /// <param name="week"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
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

        private bool IsForgotten => new Random().Next(10) % 3 != 0;

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