using System;
using QuizzApp.Models;
using QuizzApp.Repository;

namespace QuizzApp.Service
{
	public class QuestionService
	{
        private readonly QuestionRepository _questionRepository;

        public QuestionService(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllAsync();
        }

        public async Task<Question?> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetByIdAsync(id);
        }

        public async Task<List<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _questionRepository.GetByQuizIdAsync(quizId);
        }

        public async Task AddQuestionAsync(Question question)
        {
            await _questionRepository.AddAsync(question);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _questionRepository.UpdateAsync(question);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionRepository.DeleteAsync(id);
        }


        public async Task<CheckAnswer?> CheckAnswerAsync(UserAnswer request)
        {
            var question = await _questionRepository.GetByIdAsync(request.QuestionId);
            if (question == null)
                return null;

            var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
            if (correctOption == null)
                return null;

            bool isCorrect = request.SelectedOptionId == correctOption.Id;

            return new CheckAnswer
            {
                IsCorrect = isCorrect,
                CorrectOptionId = correctOption.Id,
                CorrectOptionText = correctOption.Text
            };
        }

        public async Task<QuizResult> CalculateQuizResultAsync(List<UserAnswer> answers)
        {
            var allQuestions = await _questionRepository.GetAllAsync();

            int correctCount = 0;
            foreach (var answer in answers)
            {
                var question = allQuestions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (question != null)
                {
                    var selectedOption = question.Options.FirstOrDefault(o => o.Id == answer.SelectedOptionId);
                    if (selectedOption != null && selectedOption.IsCorrect)
                    {
                        correctCount++;
                    }
                }
            }

            return new QuizResult
            {
                TotalQuestions = answers.Count,
                CorrectAnswers = correctCount,
                TimeTaken = TimeSpan.FromMinutes(2),
                IsPassed = correctCount >= answers.Count * 0.6
            };
        }
    }
}

