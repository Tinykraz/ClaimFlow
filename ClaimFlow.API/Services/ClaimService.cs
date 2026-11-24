using ClaimFlow.API.Enums;
using ClaimFlow.API.Models;

namespace ClaimFlow.API.Services;

public class ClaimService
{
    private readonly List<Claim> _claims = new();
    private readonly List<ClaimStatusHistory> _statusHistory = new();

    public List<ClaimStatusHistory> GetClaimStatusHistory(Guid claimId)
{
    return _statusHistory
        .Where(history => history.ClaimId == claimId)
        .OrderBy(history => history.ChangedAtUtc)
        .ToList();
}

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

    var previousStatus = claim.Status;

    claim.Status = newStatus;

    var history = new ClaimStatusHistory
    {
        ClaimId = claim.Id,
        PreviousStatus = previousStatus,
        NewStatus = newStatus,
        ChangedAtUtc = DateTime.UtcNow,
        ChangedBy = "System"
    };

    _statusHistory.Add(history);

    return true;
}

}
