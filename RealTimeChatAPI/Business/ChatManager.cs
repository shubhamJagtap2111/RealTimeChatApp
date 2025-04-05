using RealTimeChatAPI.Model;
using RealTimeChatAPI.Repositories;

namespace RealTimeChatAPI.Business;

public class ChatManager : IChatManager
{
    private readonly IChatRepository _chatRepository;

    public ChatManager(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public Task<IEnumerable<ChatMessage>> GetMessagesAsync()
    {
        return _chatRepository.GetMessagesAsync();
    }

    public Task SaveMessageAsync(ChatMessage message)
    {
        return _chatRepository.AddMessageAsync(message);
    }
}
