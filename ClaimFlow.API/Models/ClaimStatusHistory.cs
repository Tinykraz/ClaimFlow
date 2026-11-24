
using ClaimFlow.API.Enums;

namespace ClaimFlow.API.Models;

public class ClaimStatusHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ClaimId { get; set; }

    public ClaimStatus? PreviousStatus { get; set; }

    public ClaimStatus NewStatus { get; set; }

    public DateTime ChangedAtUtc { get; set; } = DateTime.UtcNow;

    public string ChangedBy { get; set; } = "System";
}
