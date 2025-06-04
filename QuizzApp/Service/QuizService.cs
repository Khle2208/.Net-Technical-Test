
using System;
using QuizzApp.Models;
using QuizzApp.Repository;
namespace QuizzApp.Service
{
	public class QuizService
	{
        private readonly QuizRepository _quizRepository;

        public QuizService(QuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _quizRepository.GetAllAsync();
        }

        public async Task<Quiz?> GetQuizByIdAsync(int id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            await _quizRepository.AddAsync(quiz);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            await _quizRepository.UpdateAsync(quiz);
        }

        public async Task DeleteQuizAsync(int id)
        {
            await _quizRepository.DeleteAsync(id);
        }
    }
}

