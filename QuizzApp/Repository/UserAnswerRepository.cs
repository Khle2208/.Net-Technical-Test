using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Models;

namespace QuizzApp.Repository
{
	public class UserAnswerRepository
	{
        private readonly QuizDbContext _context;

        public UserAnswerRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserAnswer>> GetAllAsync()
        {
            return await _context.UserAnswers
                .Include(ua => ua.Answer)
                .Include(ua => ua.Result)
                .ToListAsync();
        }

        public async Task<UserAnswer?> GetByIdAsync(int id)
        {
            return await _context.UserAnswers
                .Include(ua => ua.Answer)
                .Include(ua => ua.Result)
                .FirstOrDefaultAsync(ua => ua.UserAnswerId == id);
        }

        public async Task<List<UserAnswer>> GetByQuizResultIdAsync(int quizResultId)
        {
            return await _context.UserAnswers
                .Where(ua => ua.QuizResultId == quizResultId)
                .Include(ua => ua.Answer)
                .Include(ua => ua.Result)
                .ToListAsync();
        }

        public async Task AddAsync(UserAnswer userAnswer)
        {
            await _context.UserAnswers.AddAsync(userAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserAnswer userAnswer)
        {
            _context.UserAnswers.Update(userAnswer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userAnswer = await _context.UserAnswers.FindAsync(id);
            if (userAnswer != null)
            {
                _context.UserAnswers.Remove(userAnswer);
                await _context.SaveChangesAsync();
            }
        }
    }
}

