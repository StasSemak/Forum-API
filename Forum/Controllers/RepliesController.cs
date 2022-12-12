using BussinessLogic.DTOs;
using BussinessLogic.Intefraces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebForum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly IReplyService replyService;

        public RepliesController(IReplyService replyService)
        {
            this.replyService = replyService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ReplyDto reply)
        {
            if (!ModelState.IsValid) return BadRequest();

            await replyService.AddReplyAsync(reply);
            return Ok();
        }

        [HttpGet("question/{id}")]
        public IActionResult GetByQuestion([FromRoute] int id)
        {
            var replies = replyService.GetRepliesByQuestionId(id);
            return Ok(replies);
        }
    }
}
