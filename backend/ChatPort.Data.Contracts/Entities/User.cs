using System.ComponentModel.DataAnnotations.Schema;

namespace ChatPort.Data.Contracts.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public Guid UserUuid { get; set; }

    public string Provider { get; set; } = null!;

    public string ProviderUserId { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<ChatParticipant> Participants { get; set; } = new List<ChatParticipant>();

    public ICollection<Message> MessagesSent { get; set; } = new List<Message>();

    public ICollection<MessageStatus> MessageStatuses = new List<MessageStatus>();


}