using System;
namespace QuizzApp.Models
{
    public class User
    {
        public int UserId { set; get; }
        public String? name { set; get; }
        public List<QuizResult> QuizResults { get; set; } = new();
    }
}

