
using ClaimFlow.API.DTOs;
using ClaimFlow.API.Models;
using ClaimFlow.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClaimFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly ClaimService _claimService;
    private readonly ClaimStatusService _claimStatusService;

    public ClaimsController(
    ClaimService claimService,
    ClaimStatusService claimStatusService)
{
    _claimService = claimService;
    _claimStatusService = claimStatusService;
}

    [HttpGet]
    public ActionResult<List<Claim>> GetAllClaims()
    {
        return Ok(_claimService.GetAllClaims());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Claim> GetClaimById(Guid id)
    {
        var claim = _claimService.GetClaimById(id);

        if (claim == null)
        {
            return NotFound(new { Message = "Claim not found." });
        }

        return Ok(claim);
    }

    [HttpPost]
    public ActionResult<Claim> CreateClaim(CreateClaimRequest request)
    {
        var claim = new Claim
        {
            ClaimantName = request.ClaimantName,
            ClaimantEmail = request.ClaimantEmail,
            IncidentDescription = request.IncidentDescription,
            IncidentDate = request.IncidentDate!.Value,
            EstimatedLoss = request.EstimatedLoss
        };

        var createdClaim = _claimService.CreateClaim(claim);

        return CreatedAtAction(
            nameof(GetClaimById),
            new { id = createdClaim.Id },
            createdClaim
        );
    }

[HttpPatch("{id:guid}/status")]
public ActionResult UpdateClaimStatus(
    Guid id,
    UpdateClaimStatusRequest request)
{
    var claim = _claimService.GetClaimById(id);

    if (claim == null)
    {
        return NotFound(new { Message = "Claim not found." });
    }

    if (!_claimStatusService.CanTransition(
        claim.Status,
        request.Status!.Value))
    {
        return BadRequest(new
        {
            Message = $"Cannot change claim status from {claim.Status} to {request.Status}."
        });
    }

    _claimService.UpdateClaimStatus(id, request.Status.Value);

    return Ok(new
    {
        Message = "Claim status updated successfully.",
        ClaimId = id,
        NewStatus = request.Status
    });
}

[HttpGet("{id:guid}/history")]
public ActionResult<List<ClaimStatusHistory>> GetClaimStatusHistory(Guid id)
{
    var claim = _claimService.GetClaimById(id);

    if (claim == null)
    {
        return NotFound(new { Message = "Claim not found." });
    }

    var history = _claimService.GetClaimStatusHistory(id);

    return Ok(history);
}

}
