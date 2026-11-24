using ClaimFlow.API.Enums;
using ClaimFlow.API.Models;

namespace ClaimFlow.API.Services;

public class ClaimService
{
    private readonly List<Claim> _claims = new();

    public List<Claim> GetAllClaims()
    {
        return _claims;
    }

    public Claim? GetClaimById(Guid id)
    {
        return _claims.FirstOrDefault(claim => claim.Id == id);
    }

    public Claim CreateClaim(Claim claim)
    {
        
        claim.Id = Guid.NewGuid();
        claim.ClaimNumber = $"CLM-{DateTime.UtcNow:yyyyMMdd}-{_claims.Count + 1:D4}";
        claim.Status = ClaimStatus.Submitted;
        claim.CreatedAt = DateTime.UtcNow;

        _claims.Add(claim);

        return claim;
    }
    
public bool UpdateClaimStatus(Guid id, ClaimStatus newStatus)
{
    var claim = GetClaimById(id);

    if (claim == null)
    {
        return false;
    }

    claim.Status = newStatus;

    return true;
}

}
