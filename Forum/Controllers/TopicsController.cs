using BussinessLogic.Intefraces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebForum_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService topicService;

        public TopicsController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            var topics = topicService.GetTopics();
            return Ok(topics);
        }
    }
}
