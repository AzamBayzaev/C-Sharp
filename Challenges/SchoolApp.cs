using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.CHALLENGE
{
    public class StudentScore
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
    }
    internal class SchoolApp
    {
        public class StudentStatistics
        {
            private List<StudentScore> _scores;

            public StudentStatistics(List<StudentScore> scores)
            {
                _scores = scores;
            }

            public void PrintSubjectStatistics()
            {
                if (!_scores.Any())
                {
                    Console.WriteLine("Нет данных о студентах!");
                    return;
                }

                var grouped = _scores.GroupBy(s => s.Subject)
                                     .Select(g => new
                                     {
                                         Subject = g.Key,
                                         PassedCount = g.Count(s => s.Score >= 60),
                                         FailedCount = g.Count(s => s.Score < 60),
                                         AverageScore = g.Average(s => s.Score),
                                         MaxScore = g.Max(s => s.Score),
                                         MinScore = g.Min(s => s.Score)
                                     })
                                     .OrderByDescending(g => g.AverageScore);

                Console.WriteLine("Статистика по предметам:");
                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10} |", "Предмет", "Сдали", "Не сдали", "Средний");
                Console.WriteLine(new string('-', 55));

                foreach (var group in grouped)
                {
                    Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-10:F2} |",
                        group.Subject,
                        group.PassedCount,
                        group.FailedCount,
                        group.AverageScore);
                }
            }

            public void PrintStudentScores(string studentName)
            {
                var studentScores = _scores.Where(s => s.StudentName == studentName);
                if (studentScores.Any())
                {
                    Console.WriteLine($"Оценки студента {studentName}:");
                    foreach (var score in studentScores)
                    {
                        Console.WriteLine($"  {score.Subject}: {score.Score}");
                    }
                }
                else
                {
                    Console.WriteLine("Студент не найден!");
                }
            }
        }
    }
}
