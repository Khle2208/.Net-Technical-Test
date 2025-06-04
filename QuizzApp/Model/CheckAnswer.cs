using System;
namespace QuizzApp.Models
{
	public class CheckAnswer
	{
        public bool IsCorrect { get; set; }
        public int CorrectOptionId { get; set; }
        public string? CorrectOptionText { get; set; }
    }
}

