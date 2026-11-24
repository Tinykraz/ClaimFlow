
using System.ComponentModel.DataAnnotations;
using ClaimFlow.API.Enums;

namespace ClaimFlow.API.DTOs;

public class UpdateClaimStatusRequest
{
    [Required]
    public ClaimStatus? Status { get; set; }
}
