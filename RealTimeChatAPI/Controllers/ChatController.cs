using Microsoft.AspNetCore.Mvc;
using RealTimeChatAPI.Service;

namespace RealTimeChatAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var messages = await _chatService.GetChatHistoryAsync();
            return Ok(messages);
        }

    }
}
