using System;
using QuizzApp.Models;
using QuizzApp.Repository;

namespace QuizzApp.Service
{
	public class AnswerOptionService
	{
        private readonly AnswerOptionRepository _answerOptionRepository;

        public AnswerOptionService(AnswerOptionRepository answerOptionRepository)
        {
            _answerOptionRepository = answerOptionRepository;
        }

        public async Task<List<AnswerOption>> GetAllAnswerOptionsAsync()
        {
            return await _answerOptionRepository.GetAllAsync();
        }

        public async Task<AnswerOption?> GetAnswerOptionByIdAsync(int id)
        {
            return await _answerOptionRepository.GetByIdAsync(id);
        }

        public async Task<List<AnswerOption>> GetAnswerOptionsByQuestionIdAsync(int questionId)
        {
            return await _answerOptionRepository.GetByQuestionIdAsync(questionId);
        }

        public async Task AddAnswerOptionAsync(AnswerOption answerOption)
        {
            await _answerOptionRepository.AddAsync(answerOption);
        }

        public async Task UpdateAnswerOptionAsync(AnswerOption answerOption)
        {
            await _answerOptionRepository.UpdateAsync(answerOption);
        }

        public async Task DeleteAnswerOptionAsync(int id)
        {
            await _answerOptionRepository.DeleteAsync(id);
        }
    }
}

