using ChatPort.Common;
using ChatPort.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatPort.Data.Configurations;

public class ChatParticipantConfiguration : IEntityTypeConfiguration<ChatParticipant>
{
    public void Configure(EntityTypeBuilder<ChatParticipant> builder)
    {
        builder.ToTable("chat_participants");

        builder.HasKey(cp => new { cp.ChatId, cp.UserId })
            .HasName("pk_chat_participants");

        builder.Property(cp => cp.ChatId)
            .HasColumnName("chat_id");

        builder.Property(cp => cp.UserId)
            .HasColumnName("user_id");

        builder.Property(cp => cp.Role)
            .HasColumnName("role")
            .HasConversion<int>()
            .HasDefaultValue(ChatRole.Member)
            .IsRequired();

        builder.Property(cp => cp.JoinedAt)
            .HasColumnName("joined_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(cp => cp.Chat)
            .WithMany(c => c.Participants)
            .HasForeignKey(cp => cp.ChatId)
            .HasConstraintName("fk_chat_participants_chat_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.User)
            .WithMany(u => u.Participants)
            .HasForeignKey(cp => cp.UserId)
            .HasConstraintName("fk_chat_participants_user_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}