using QuizzApp.Models;
using QuizzApp.DTOs;

namespace QuizzApp.Services
{
    public static class ConvertToDto
    {
        public static QuestionDto ToQuestionDto(Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                Content = question.Content,
                QuizId = question.QuizId,
                // Không map Quiz để tránh vòng tham chiếu JSON
                Options = question.Options.Select(o => new AnswerOptionDto
                {
                    Id = o.Id,
                    Text = o.Text,
                    IsCorrect = o.IsCorrect
                }).ToList()
            };
        }
        public static List<QuestionDto> ToQuestionDto(List<Question> questions)
        {
            return questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Content = q.Content,
                QuizId = q.QuizId,
                Options = q.Options.Select(o => new AnswerOptionDto
                {
                    Id = o.Id,
                    Text = o.Text,
                    IsCorrect = o.IsCorrect
                }).ToList()
            }).ToList();
        }

    }
}
