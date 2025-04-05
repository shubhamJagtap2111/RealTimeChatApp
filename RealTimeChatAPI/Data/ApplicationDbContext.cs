using Microsoft.EntityFrameworkCore;
using RealTimeChatAPI.Model;

namespace RealTimeChatAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
