using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Microsoft.AspNetCore.Mvc;

namespace WebForum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;

        public QuestionsController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUser([FromRoute] string userId)
        {
            var questions = questionService.GetByUser(userId);
            
            return Ok(questions);
        }

        [HttpGet("title/{title}")]
        public IActionResult GetByTitle([FromRoute] string title)
        {
            var questions = questionService.GetByTitle(title);

            return Ok(questions);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] QuestionDto question)
        {
            if (!ModelState.IsValid) return BadRequest();

            await questionService.AddQuestionAsync(question);
            return Ok();
        }


        [HttpGet("get")]
        public IActionResult Get()
        {
            var questions = questionService.GetFiveNewest();
            return Ok(questions);
        }
    }
}
