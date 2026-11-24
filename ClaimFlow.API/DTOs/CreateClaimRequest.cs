
using System.ComponentModel.DataAnnotations;

namespace ClaimFlow.API.DTOs;

public class CreateClaimRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string ClaimantName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string ClaimantEmail { get; set; } = string.Empty;

    [Required]
    [StringLength(2000, MinimumLength = 10)]
    public string IncidentDescription { get; set; } = string.Empty;

    [Required]
    public DateTime? IncidentDate { get; set; }

    [Range(0.01, 100000000)]
    public decimal EstimatedLoss { get; set; }
}
