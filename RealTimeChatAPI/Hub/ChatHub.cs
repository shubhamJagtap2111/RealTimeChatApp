using Microsoft.AspNetCore.SignalR;
using RealTimeChatAPI.Service;

namespace RealTimeChatAPI.Hubs
{
    public class ChatHub : Hub 
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {
            await _chatService.SendMessageAsync(user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}