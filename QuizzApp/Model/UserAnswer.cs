using System;
namespace QuizzApp.Models
{
	public class UserAnswer
	{
        public int UserAnswerId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedOptionId { get; set; }
        public int QuizResultId { get; set; }
        public AnswerOption? Answer { get; set; }
        public QuizResult? Result { get; set; }
    }
}

