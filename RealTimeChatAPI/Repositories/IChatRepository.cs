using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Repositories
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetMessagesAsync();
        Task AddMessageAsync(ChatMessage message);
    }
}
