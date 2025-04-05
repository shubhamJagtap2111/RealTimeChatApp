using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Business
{
    public interface IChatManager
    {
        Task<IEnumerable<ChatMessage>> GetMessagesAsync();
        Task SaveMessageAsync(ChatMessage message);
    }
}
