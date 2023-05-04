using Microsoft.EntityFrameworkCore;

namespace chat_service
{
    public class ChatContext : DbContext
    {

        public ChatContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}