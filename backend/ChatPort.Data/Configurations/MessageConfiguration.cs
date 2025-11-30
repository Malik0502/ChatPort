using ChatPort.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatPort.Data.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");

        builder.HasKey(m => m.MessageId)
            .HasName("pk_messages");

        builder.Property(m => m.MessageId)
            .HasColumnName("message_id")
            .ValueGeneratedOnAdd();

        builder.Property(m => m.MessageUuid)
            .HasColumnName("message_uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired();

        builder.Property(m => m.ChatId)
            .HasColumnName("chat_id");

        builder.Property(m => m.SenderId)
            .HasColumnName("sender_id");

        builder.Property(m => m.Content)
            .HasColumnName("content")
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(m => m.ReplyToMessageId)
            .HasColumnName("reply_to_message_id");

        builder.HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId)
            .HasConstraintName("fk_messages_chat_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Sender)
            .WithMany(u => u.MessagesSent)
            .HasForeignKey(m => m.SenderId)
            .HasConstraintName("fk_messages_sender_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.ReplyTo)
            .WithMany()
            .HasForeignKey(m => m.ReplyToMessageId)
            .HasConstraintName("fk_messages_reply_to_message_id")
            .OnDelete(DeleteBehavior.SetNull);
    }
}