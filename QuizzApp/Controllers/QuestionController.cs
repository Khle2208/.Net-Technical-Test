//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using QuizzApp.Models;
//using QuizzApp.Services;
//using QuizzApp.Data;

//namespace QuizApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class QuestionController : Controller
//    {
//        private readonly QuizDbContext _context;

//        public QuestionController(QuizDbContext context)
//        {
//            _context = context;
//        }


//        [HttpGet("questions")]
//        public async Task<IActionResult> GetQuestions()
//        {

//            var questions = await _context.Questions
//                .Include(q => q.Options)
//                .ToListAsync();

//            return Ok(ConvertToDto.ToQuestionDto(questions));
//        }


//        public async Task<IActionResult> CheckAnswer([FromBody] UserAnswer request)
//        {
//            var question = await _context.Questions
//                .Include(q => q.Options)
//                .FirstOrDefaultAsync(q => q.Id == request.QuestionId);

//            if (question == null)
//                return NotFound("Question not found");

//            var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
//            if (correctOption == null)
//                return StatusCode(500, "Correct option not found in question");

//            bool isCorrect = request.SelectedOptionId == correctOption.Id;

//            var response = new CheckAnswer
//            {
//                IsCorrect = isCorrect,
//                CorrectOptionId = correctOption.Id,
//                CorrectOptionText = correctOption.Text
//            };

//            return Ok(response);
//        }


//        [HttpPost("submit")]
//        public async Task<IActionResult> SubmitAnswers([FromBody] List<UserAnswer> answers)
//        {
//            var questions = await _context.Questions.Include(q => q.Options).ToListAsync();

//            int correctCount = 0;
//            foreach (var answer in answers)
//            {
//                var question = questions.FirstOrDefault(q => q.Id == answer.QuestionId);
//                if (question != null)
//                {
//                    var selectedOption = question.Options.FirstOrDefault(o => o.Id == answer.SelectedOptionId);
//                    if (selectedOption != null && selectedOption.IsCorrect)
//                    {
//                        correctCount++;
//                    }
//                }
//            }

//            var result = new QuizResult
//            {
//                TotalQuestions = questions.Count,
//                CorrectAnswers = correctCount,
//                TimeTaken = TimeSpan.FromMinutes(2),
//                IsPassed = correctCount >= questions.Count * 0.6
//            };

//            return Ok(result);
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using QuizzApp.Models;
using QuizzApp.Service;
using QuizzApp.Services;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        // Lấy tất cả câu hỏi
        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(ConvertToDto.ToQuestionDto(questions));
        }

        // Kiểm tra đáp án của 1 câu hỏi
        [HttpPost("check-answer")]
        public async Task<IActionResult> CheckAnswer([FromBody] UserAnswer request)
        {
            var result = await _questionService.CheckAnswerAsync(request);
            if (result == null)
                return NotFound("Question or correct option not found");

            return Ok(result);
        }

        // Nộp bài và tính kết quả tổng thể
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswers([FromBody] List<UserAnswer> answers)
        {
            var quizResult = await _questionService.CalculateQuizResultAsync(answers);
            return Ok(quizResult);
        }
    }
}
