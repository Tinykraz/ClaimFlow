using ClaimFlow.API.Enums;
namespace ClaimFlow.API.Models;

public class Claim
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string ClaimNumber { get; set; } = string.Empty;

    public string ClaimantName { get; set; } = string.Empty;

    public string ClaimantEmail { get; set; } = string.Empty;

    public string IncidentDescription { get; set; } = string.Empty;

    public DateTime IncidentDate { get; set; }

    public decimal EstimatedLoss { get; set; }

    public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
