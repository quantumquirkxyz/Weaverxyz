# [Ticket][M01-T04] Deliver PostgreSQL persistence for the vertical slice

## Work Item Contract

- **Work Type:** Ticket
- **Native Issue Type:** Task
- **Parent Sub-Spec:** #5
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-T04
- **Owner:** `quantumquirkxyz`
- **Phase:** Implementation → Verification
- **Status:** Ready for agent
- **Priority:** Critical
- **Risk:** High
- **Area:** Persistence
- **Repo Scope:** Cross-cutting
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `ticket-weaverxyz-m01-t04-v1`

## What it delivers

Deliver the initial PostgreSQL schema/migrations, repositories, validated JSONB, execution persistence, outbox/idempotency records, and integration evidence.

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

M01-T02, M01-T03
