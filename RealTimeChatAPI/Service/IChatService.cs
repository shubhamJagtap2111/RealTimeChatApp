using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Service
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync();
        Task SendMessageAsync(string sender, string message);
    }
}
