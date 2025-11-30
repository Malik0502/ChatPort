namespace ChatPort.Data.Contracts.Entities;

public class Message
{
    public int MessageId { get; set; }
    public Guid MessageUuid { get; set; }

    public int ChatId { get; set; }
    public Chat Chat { get; set; } = null!;

    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public int? ReplyToMessageId { get; set; }
    public Message? ReplyTo { get; set; }

    public ICollection<MessageStatus> Statuses { get; set; } = new List<MessageStatus>();
}
