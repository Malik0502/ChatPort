using ChatPort.Common;

namespace ChatPort.Data.Contracts.Entities;

public class ChatParticipant
{
    public int ChatId { get; set; }
    public Chat Chat { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public ChatRole? Role { get; set; }
    public DateTime JoinedAt { get; set; }
}
