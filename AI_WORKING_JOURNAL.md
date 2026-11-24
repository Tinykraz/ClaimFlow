
# ClaimFlow - AI Working Journal

## Project Overview

ClaimFlow is a prototype claims management system developed
for a full-stack developer graduate assessment.

The application aims to support claimants, claims staff,
and managers in managing insurance claims.

## Technology Stack

- Backend: C# and ASP.NET Core Web API
- Frontend: Angular (planned)
- Database: PostgreSQL (planned)
- Messaging: Apache Kafka (planned)
- Version Control: Git

## Development Log

### Session 1 - Backend Foundation

**Work completed:**
- Created the ASP.NET Core Web API project.
- Created the Claim model.
- Implemented ClaimService.
- Implemented endpoints to create and retrieve claims.
- Added request validation using Data Annotations.
- Tested API endpoints using PowerShell.

**AI assistance:**
- Explained ASP.NET Core project structure.
- Assisted with model, DTO, service, and controller implementation.
- Explained HTTP methods and API validation.

### Session 2 - Claim Status Workflow

**Work completed:**
- Created ClaimStatus enum.
- Implemented ClaimStatusService.
- Defined permitted claim status transitions.
- Added PATCH endpoint for updating claim status.
- Tested valid and invalid status transitions.

**AI assistance:**
- Explained enums and dependency injection.
- Helped implement status transition rules.
- Guided API testing using PowerShell.

### Session 3 - Version Control

**Work completed:**
- Initialized Git repository.
- Created initial project commit.
- Added .gitignore.
- Removed generated bin and obj files from Git tracking.
- Created cleanup commit.

**AI assistance:**
- Explained Git initialization and commits.
- Guided repository cleanup.

## Architecture Decisions

- Started with a modular backend structure.
- Used DTOs to separate API input from domain models.
- Used an enum to represent claim statuses.
- Centralized status transition rules in a service.
- Started with in-memory storage for rapid prototyping.
- Database persistence will be implemented later.

## Current Limitations

- Claims are stored in memory.
- No authentication or authorization yet.
- No database persistence yet.
- No frontend yet.
- No Kafka integration yet.

## Next Steps

1. Implement claim status history.
2. Improve API responses.
3. Integrate PostgreSQL.
4. Implement claimant and staff workflows.
5. Develop Angular frontend.
6. Add manager dashboard.
7. Evaluate Kafka integration.
8. Add automated tests.
