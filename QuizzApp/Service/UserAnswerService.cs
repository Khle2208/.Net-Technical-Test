using System;
using QuizzApp.Models;
using QuizzApp.Repository;

namespace QuizzApp.Service
{
	public class UserAnswerService
	{
        private readonly UserAnswerRepository _userAnswerRepository;

        public UserAnswerService(UserAnswerRepository userAnswerRepository)
        {
            _userAnswerRepository = userAnswerRepository;
        }

        public async Task<List<UserAnswer>> GetAllUserAnswersAsync()
        {
            return await _userAnswerRepository.GetAllAsync();
        }

        public async Task<UserAnswer?> GetUserAnswerByIdAsync(int id)
        {
            return await _userAnswerRepository.GetByIdAsync(id);
        }

        public async Task<List<UserAnswer>> GetUserAnswersByQuizResultIdAsync(int quizResultId)
        {
            return await _userAnswerRepository.GetByQuizResultIdAsync(quizResultId);
        }

        public async Task AddUserAnswerAsync(UserAnswer userAnswer)
        {
            await _userAnswerRepository.AddAsync(userAnswer);
        }

        public async Task UpdateUserAnswerAsync(UserAnswer userAnswer)
        {
            await _userAnswerRepository.UpdateAsync(userAnswer);
        }

        public async Task DeleteUserAnswerAsync(int id)
        {
            await _userAnswerRepository.DeleteAsync(id);
        }
    }
}

