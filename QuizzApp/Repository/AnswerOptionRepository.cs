using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Models;

namespace QuizzApp.Repository
{
	public class AnswerOptionRepository
	{
        private readonly QuizDbContext _context;

        public AnswerOptionRepository(QuizDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<AnswerOption>> GetAllAsync()
        {
            return await _context.AnswerOptions
                .Include(a => a.Question)
                .ToListAsync();
        }

        
        public async Task<AnswerOption?> GetByIdAsync(int id)
        {
            return await _context.AnswerOptions
                .Include(a => a.Question)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        
        public async Task<List<AnswerOption>> GetByQuestionIdAsync(int questionId)
        {
            return await _context.AnswerOptions
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        
        public async Task AddAsync(AnswerOption answerOption)
        {
            await _context.AnswerOptions.AddAsync(answerOption);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(AnswerOption answerOption)
        {
            _context.AnswerOptions.Update(answerOption);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var answerOption = await _context.AnswerOptions.FindAsync(id);
            if (answerOption != null)
            {
                _context.AnswerOptions.Remove(answerOption);
                await _context.SaveChangesAsync();
            }
        }
    }
}

