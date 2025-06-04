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

        
        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(ConvertToDto.ToQuestionDto(questions));
        }

        
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
