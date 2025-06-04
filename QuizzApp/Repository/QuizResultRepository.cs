using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Models;

namespace QuizzApp.Repository
{
	public class QuizResultRepository
	{
        private readonly QuizDbContext _context;

            public QuizResultRepository(QuizDbContext context)
            {
                _context = context;
            }

            public async Task<List<QuizResult>> GetAllAsync()
            {
                return await _context.QuizResults
                    .Include(q => q.User)
                    .Include(q => q.UserAnswers)
                    .ToListAsync();
            }

            public async Task<QuizResult?> GetByIdAsync(int id)
            {
                return await _context.QuizResults
                    .Include(q => q.User)
                    .Include(q => q.UserAnswers)
                    .FirstOrDefaultAsync(q => q.QuizResultid == id);
            }

            public async Task<List<QuizResult>> GetByUserIdAsync(int userId)
            {
                return await _context.QuizResults
                    .Where(q => q.UserId == userId)
                    .Include(q => q.User)
                    .Include(q => q.UserAnswers)
                    .ToListAsync();
            }

            public async Task AddAsync(QuizResult quizResult)
            {
                await _context.QuizResults.AddAsync(quizResult);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(QuizResult quizResult)
            {
                _context.QuizResults.Update(quizResult);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var quizResult = await _context.QuizResults.FindAsync(id);
                if (quizResult != null)
                {
                    _context.QuizResults.Remove(quizResult);
                    await _context.SaveChangesAsync();
                }
            }
        }
}

