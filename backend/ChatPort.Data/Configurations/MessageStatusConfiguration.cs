using ChatPort.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatPort.Data.Configurations;

public class MessageStatusConfiguration : IEntityTypeConfiguration<MessageStatus>
{
    public void Configure(EntityTypeBuilder<MessageStatus> builder)
    {
        builder.ToTable("message_statuses");

        builder.HasKey(ms => new { ms.MessageId, ms.UserId })
            .HasName("pk_message_statuses");

        builder.Property(ms => ms.MessageId)
            .HasColumnName("message_id");

        builder.Property(ms => ms.UserId)
            .HasColumnName("user_id");

        builder.Property(ms => ms.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(ms => ms.ReadAt)
            .HasColumnName("read_at");

        builder.HasOne(ms => ms.Message)
            .WithMany(m => m.Statuses)
            .HasForeignKey(ms => ms.MessageId)
            .HasConstraintName("fk_message_statuses_message_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ms => ms.User)
            .WithMany(u => u.MessageStatuses)
            .HasForeignKey(ms => ms.UserId)
            .HasConstraintName("fk_message_statuses_user_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}