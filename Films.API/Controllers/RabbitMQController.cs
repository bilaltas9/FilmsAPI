using Films.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Films.API.Controllers
{
    public class RabbitMQController : BaseController
    {
        private IRabbitMqService _rabbitMqService;
        public RabbitMQController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        [HttpGet("SendMessage", Name = "SendMessage")]
        public IActionResult SendMessage(string queMessage)
        {
            _rabbitMqService.SendMessageToQueue(queMessage);
            return Ok();
        }
        [HttpPost("DeclareQue", Name = "DeclareQue")]
        public IActionResult DeclareQue()
        {
            _rabbitMqService.DeclareQue();
            return Ok();
        }
    }
}
