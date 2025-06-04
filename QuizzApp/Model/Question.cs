using System;
namespace QuizzApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public List<AnswerOption> Options { get; set; } = new();
    }
}

