using Microsoft.EntityFrameworkCore;
using RealTimeChatAPI.Data;
using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Repositories
{
    public class ChatRepository:IChatRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ChatMessage>> GetMessagesAsync()
        {
            return await _context.ChatMessages.OrderBy(m => m.Timestamp).ToListAsync();
        }
        public async Task AddMessageAsync(ChatMessage message)
        {
            await _context.ChatMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
