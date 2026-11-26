# ADR-009: MVP Scope, Success Criteria, and Phase Boundaries

## Status

Accepted

## Context

Weaverxyz is both an academic Software Engineering project and a functional desktop orchestrator. The MVP must be meaningful without becoming an unbounded distributed platform.

## Decision

The MVP includes: Visual Studio-editable Windows Forms pipeline editor; capability-based sources, transforms, validators, AgentCall, sinks, and subpipelines; PostgreSQL persistence; versioned DAG definitions; preflight validation; sequential execution; mandatory rollback/compensation; retries and recovery; live monitoring; detailed logs; execution comparison; metrics; redacted snapshots; multi-environment configuration; and complete Project/documentation governance.

Initial exclusions are multi-user collaboration, distributed/remote execution, high availability, external scheduling, queues/event buses, cloud deployment, and native cross-platform UI. Any excluded capability requires new scope, ADR, risk analysis, Project fields, and updated success criteria.

Success requires evidence for functional end-to-end execution, architectural boundaries, pattern application, tests, contracts, security, accessibility, performance, reproducibility, documentation, and GitHub Project operation.

## Consequences

- The MVP is broad but bounded by explicit quality gates and phases.
- Feature completeness cannot override architecture or evidence requirements.
- Future platform capabilities remain possible without being silently committed.
