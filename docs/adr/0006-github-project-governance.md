# ADR-006: GitHub Project Governance and Automation

## Status

Accepted

## Context

Weaverxyz requires a repository-level GitHub Project V2 to coordinate requirements, implementation, verification, security, documentation, releases, and maintenance. A simple board is insufficient: the project needs complete engineering metadata, reproducible configuration, auditable automation, and explicit failure handling.

## Decision

Use one repository-level GitHub Project for `quantumquirkxyz/Weaverxyz` with declarative, versioned configuration. Project V2 is the operational planning surface; issue/PR records provide evidence and relationships; labels provide routing compatibility.

The Project will provide normalized fields for `Status`, `Work Type`, `Type`, `Priority`, `Risk`, `Area`, `Repo Scope`, `Phase`, `Effort`, `Owner`, `Reviewer`, `QA State`, `Security State`, `Documentation State`, `Dependency State`, `Iteration`, `Release Train`, `Milestone`, `Start Date`, `Target Date`, and `Completed Date`.

The lifecycle uses Board, Table, Roadmap, Intake/Triage, Ready, Execution, Blocked, Review/QA, Roadmap, Release Readiness, Security, Documentation Debt, and Completed views. Actions synchronize routine state changes; configuration mutations require dry-run and human approval.

State is derived by a documented precedence matrix. Conflicts fail closed, preserve the last valid state, create a governance alert, and require explicit resolution. The Project configuration is idempotent, auditable, reconciled on schedule, and protected by a rollback plan.

## Consequences

- Planning and delivery become visible and traceable from issue to release.
- Automation reduces manual synchronization but introduces workflow and permission complexity.
- Broad permissions are limited to Project automation workflows; build, test, security, and release workflows remain separately scoped.
- GitHub-native capabilities and Project V2 identifiers must be inventoried and preserved.

## Alternatives considered

- Manual board management: rejected because it is not reproducible or auditable.
- Labels-only tracking: rejected because labels cannot represent the full planning model.
- Multiple Projects: rejected because one repository-level source reduces fragmentation.
