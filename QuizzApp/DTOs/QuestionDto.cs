using System;
using QuizzApp.Models;

namespace QuizzApp.DTOs
{
	public class QuestionDto
	{
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<AnswerOptionDto> Options { get; set; } = new();
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        
    }
}

