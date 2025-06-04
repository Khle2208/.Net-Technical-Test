using System;
using QuizzApp.Models;
using QuizzApp.Repository;

namespace QuizzApp.Service
{
	public class QuizResultService
	{
        private readonly QuizResultRepository _quizResultRepository;

        public QuizResultService(QuizResultRepository quizResultRepository)
        {
            _quizResultRepository = quizResultRepository;
        }

        public async Task<List<QuizResult>> GetAllQuizResultsAsync()
        {
            return await _quizResultRepository.GetAllAsync();
        }

        public async Task<QuizResult?> GetQuizResultByIdAsync(int id)
        {
            return await _quizResultRepository.GetByIdAsync(id);
        }

        public async Task<List<QuizResult>> GetQuizResultsByUserIdAsync(int userId)
        {
            return await _quizResultRepository.GetByUserIdAsync(userId);
        }

        public async Task AddQuizResultAsync(QuizResult quizResult)
        {
            await _quizResultRepository.AddAsync(quizResult);
        }

        public async Task UpdateQuizResultAsync(QuizResult quizResult)
        {
            await _quizResultRepository.UpdateAsync(quizResult);
        }

        public async Task DeleteQuizResultAsync(int id)
        {
            await _quizResultRepository.DeleteAsync(id);
        }
    }
}

