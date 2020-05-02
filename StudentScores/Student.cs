using System.Collections.Generic;
namespace StudentScores
{
    public class Student
    {
        public string Name { get; set; }
        public List<double> Scores { get; set; } = new List<double>();

        public Student(string name, List<double> scores)
        {
            Name = name;
            Scores = scores;
        }

        public Student(Student student)
        {
            Name = student.Name;
            Scores = new List<double>(student.Scores);
        }

        public double ScoreTotal
        {
            get
            {
                var total = 0.0;
                foreach (double score in Scores)
                {
                    total += score;
                }
                return total;
            }
        }

        public double ScoreAverage
        {
            get
            {
                var average = 0.0;
                if (ScoreTotal > 0)
                {
                    average = ScoreTotal / Scores.Count;
                }
                return average;
            }
        }

        public string GetScoresString(bool spacing)
        {
            var scoresString = string.Empty;
            foreach (double score in Scores)
            {
                if (spacing)
                {
                    scoresString += " " + StudentDB.Separator.ToString() + " " + score;
                }
                else
                {
                    scoresString += StudentDB.Separator.ToString() + score;
                }
            }
            return scoresString;
        }

        public override string ToString() => Name + GetScoresString(false);
    }
}