using ChatPort.Common;

namespace ChatPort.Data.Contracts.Entities;

public class MessageStatus
{
    public int MessageId { get; set; }
    public Message Message { get; set; } = default!;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public MessageDeliveryStatus Status { get; set; }
    public DateTime? ReadAt { get; set; }
}