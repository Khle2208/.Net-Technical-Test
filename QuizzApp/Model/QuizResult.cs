using System;
namespace QuizzApp.Models
{
    public class QuizResult
    {
        public int QuizResultid { get; set; }
        public int UserId { set; get; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public bool IsPassed { get; set; }
        public List<UserAnswer> UserAnswers { set; get; } = new();
        public User? User { get; set; }
    }
}

