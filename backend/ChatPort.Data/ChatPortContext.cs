using ChatPort.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatPort.Data
{

    public class ChatPortContext : DbContext
    {
        public ChatPortContext(DbContextOptions<ChatPortContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<MessageStatus> MessageStatuses => Set<MessageStatus>();
        public DbSet<ChatParticipant> ChatParticipants => Set<ChatParticipant>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatPortContext).Assembly);
        }
    }
}
