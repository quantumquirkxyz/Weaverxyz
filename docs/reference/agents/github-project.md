# GitHub Project Governance

## Purpose

The Weaverxyz repository uses one repository-level GitHub Project V2 as the operational planning surface. This document defines the normalized field model, authority boundaries, lifecycle, automation, evidence, and rollback requirements.

## Authority model

| Concern | Authority |
|---|---|
| Planning fields | Project V2 |
| Requirements and evidence | Issue / Pull Request body and comments |
| Routing | Allowlisted labels |
| Dependencies and development linkage | Native GitHub relationships |
| Architecture | ADRs |
| Domain vocabulary | `CONTEXT.md` |
| Configuration source | `.github/project/project-manifest.yml` |

## Required metadata

Every claimable issue must have: native issue type, `Priority`, `Risk`, `Status`, `Work Type`, `Area`, `Repo Scope`, `Phase`, `Effort`, owner, target date or justified omission, dependency state, Definition of Ready evidence, and a test/documentation plan.

## Definition of Ready

An item may enter `Ready for Agent` or `Ready for Human` only when the problem, objective, scope, exclusions, domain context, acceptance criteria, dependencies, risks, priority, effort, type, area, phase, owner, test plan, affected documentation, and roadmap relation are complete.

## Definition of Done

An item may enter `Done` only after acceptance criteria are verified; implementation is merged; required unit, integration, contract, performance, security, or migration checks pass; review is approved; documentation and ADRs are synchronized; evidence is attached; and issue, PR, and Project metadata agree.

## State precedence

1. Explicit governance conflict or failed quality gate: `Blocked`.
2. Merged PR with all required gates passed: `Done`.
3. PR open and review requested: `Review`.
4. Implementation branch active: `In Progress`.
5. Unmet dependencies: `Blocked`.
6. Complete Definition of Ready: `Ready for Agent` or `Ready for Human`.
7. Otherwise: `Triage`.

Conflicts fail closed and require explicit resolution.

## Automation policy

Project synchronization listens to issue, label, comment, PR, review, workflow, release, schedule, and manual-approved reconciliation events. Routine state synchronization may run automatically. Configuration mutations require inventory, dry-run, approval, idempotent application, audit evidence, health check, and rollback readiness.

## Ownership

`quantumquirkxyz` is the initial operational owner. Ownership is documented by artifact and role, with backup and periodic review. No additional GitHub users or teams are inferred.
