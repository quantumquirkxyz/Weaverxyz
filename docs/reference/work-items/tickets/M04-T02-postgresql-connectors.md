# [Ticket][M04-T02] Deliver governed PostgreSQL source and sink connectors

## Work Item Contract

- **Work Type:** Ticket
- **Native Issue Type:** Task
- **Parent Sub-Spec:** #28
- **Milestone:** M04 — Source and Sink Connectors
- **Semantic ID:** M04-T02
- **Owner:** `quantumquirkxyz`
- **Phase:** Implementation → Verification
- **Status:** Ready for agent
- **Priority:** High
- **Risk:** Critical
- **Area:** Data
- **Repo Scope:** PipelineOrchestrator.Data
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `ticket-weaverxyz-m04-t02-v1`

## What it delivers

Deliver PostgresSource/PostgresSink with secret provider, TLS/allowlists, parameterized access, batching, transactions, staging/upsert, idempotency, compensation, query plans, and safe diagnostics.

## Acceptance criteria

1. The connector behavior follows approved M02–M04 contracts and safety boundaries.
2. Positive, negative, security, resilience, recovery, and deterministic tests cover the slice.
3. External effects are allowlisted, bounded, redacted, idempotent, and recoverable.
4. Evidence links implementation, tests, documentation, and Project metadata.

## Validation

- Relevant connector contract, integration, security, fault, performance, and recovery gates pass.
- Evidence is reproducible and checksummed.

## Blocked by

M03-T06
