
using ClaimFlow.API.Enums;

namespace ClaimFlow.API.Services;

public class ClaimStatusService
{
    private readonly Dictionary<ClaimStatus, ClaimStatus[]> _allowedTransitions = new()
    {
        [ClaimStatus.Submitted] =
        [
            ClaimStatus.UnderReview
        ],

        [ClaimStatus.UnderReview] =
        [
            ClaimStatus.AdditionalInformationRequired,
            ClaimStatus.Assessment
        ],

        [ClaimStatus.AdditionalInformationRequired] =
        [
            ClaimStatus.UnderReview
        ],

        [ClaimStatus.Assessment] =
        [
            ClaimStatus.Approved,
            ClaimStatus.Rejected
        ],

        [ClaimStatus.Approved] =
        [
            ClaimStatus.Settled
        ],

        [ClaimStatus.Rejected] = [],
        [ClaimStatus.Settled] = []
    };

    public bool CanTransition(
        ClaimStatus currentStatus,
        ClaimStatus newStatus)
    {
        return _allowedTransitions.TryGetValue(
            currentStatus,
            out var allowedStatuses
        ) && allowedStatuses.Contains(newStatus);
    }
}
