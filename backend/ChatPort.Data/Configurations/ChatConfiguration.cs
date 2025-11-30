using ChatPort.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatPort.Data.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.ToTable("chats");

        builder.HasKey(c => c.ChatId)
            .HasName("pk_chats");

        builder.Property(c => c.ChatId)
            .HasColumnName("chat_id")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.ChatUuid)
            .HasColumnName("chat_uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();

        builder.Property(c => c.IsGroup)
            .HasColumnName("is_group")
            .IsRequired();

        builder.Property(c => c.GroupName)
            .HasColumnName("group_name")
            .HasMaxLength(200);

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}