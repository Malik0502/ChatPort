namespace ChatPort.Data.Contracts.Entities;

public class Chat
{
    public int ChatId { get; set; }
    public Guid ChatUuid { get; set; }

    public bool IsGroup { get; set; }
    public string? GroupName { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<ChatParticipant> Participants { get; set; } = new List<ChatParticipant>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
