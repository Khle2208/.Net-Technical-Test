using System;
using Microsoft.EntityFrameworkCore;
using QuizzApp.Models;


namespace QuizzApp.Data
{
	public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<Question> Questions => Set<Question>();
        public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
        public DbSet<Quiz> Quizzes => Set<Quiz>();
        public DbSet<QuizResult> QuizResults => Set<QuizResult>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserAnswer> UserAnswers => Set<UserAnswer>();
    }
}

