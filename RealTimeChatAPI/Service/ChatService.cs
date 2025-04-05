using RealTimeChatAPI.Business;
using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Service
{
    public class ChatService : IChatService
    {
        private readonly IChatManager _manager;

        public ChatService(IChatManager manager)
        {
            _manager = manager;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync()
            => await _manager.GetMessagesAsync();

        public async Task SendMessageAsync(string sender, string message)
        {
            var chatMessage = new ChatMessage
            {
                Sender = sender,
                Message = message,
            };
            await _manager.SaveMessageAsync(chatMessage);
        }
    }
}
