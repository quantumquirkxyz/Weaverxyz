# [Ticket][M01-T05] Deliver governed execution and observability foundation

## Work Item Contract

- **Work Type:** Ticket
- **Native Issue Type:** Task
- **Parent Sub-Spec:** #7
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-T05
- **Owner:** `quantumquirkxyz`
- **Phase:** Implementation → Verification
- **Status:** Ready for agent
- **Priority:** Critical
- **Risk:** High
- **Area:** Orchestrator
- **Repo Scope:** Cross-cutting
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `ticket-weaverxyz-m01-t05-v1`

## What it delivers

Deliver DAG scheduling, formal execution states, StepExecutor, retry, LIFO compensation, cancellation, recovery, budgets, correlated events, and diagnostics.

## Acceptance criteria

1. The vertical behavior is implemented through the approved M01 contracts and architecture boundaries.
2. Positive, negative, security, and deterministic tests cover the declared slice.
3. No secrets or forbidden dependencies are introduced.
4. Evidence links the implementation, tests, documentation, and Project item.

## Validation

- Restore/build/test commands are reproducible.
- Relevant architecture, contract, integration, security, resilience, accessibility, or performance gates pass.
- Evidence is checksummed and attached to the implementation handoff.

## Blocked by

M01-T02, M01-T03, M01-T04
