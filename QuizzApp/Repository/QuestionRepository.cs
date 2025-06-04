using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Models;

namespace QuizzApp.Repository
{
    public class QuestionRepository
    {
        private readonly QuizDbContext _context;

        public QuestionRepository(QuizDbContext context)
        {
            _context = context;
        }


        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Include(q => q.Quiz)
                .ToListAsync();
        }


        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Options)
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(q => q.Id == id);
        }


        public async Task<List<Question>> GetByQuizIdAsync(int quizId)
        {
            return await _context.Questions
                .Where(q => q.QuizId == quizId)
                .Include(q => q.Options)
                .ToListAsync();
        }


        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
}

