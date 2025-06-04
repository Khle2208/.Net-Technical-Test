using System;
namespace QuizzApp.Models
{
    public class Quiz
    {
        public int QuizId { set; get; }
        public String? Title { set; get; }
        public List<Question> Questions { get; set; } = new();
    }
}

