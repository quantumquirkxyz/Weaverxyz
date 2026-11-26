# [Ticket][M04-T03] Deliver governed HTTP and report connectors

## Work Item Contract

- **Work Type:** Ticket
- **Native Issue Type:** Task
- **Parent Sub-Spec:** #29
- **Milestone:** M04 — Source and Sink Connectors
- **Semantic ID:** M04-T03
- **Owner:** `quantumquirkxyz`
- **Phase:** Implementation → Verification
- **Status:** Ready for agent
- **Priority:** High
- **Risk:** Critical
- **Area:** Data
- **Repo Scope:** PipelineOrchestrator.Data
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `ticket-weaverxyz-m04-t03-v1`

## What it delivers

Deliver HttpSource and ReportSink with SSRF/TLS/host controls, limits, pagination, safe retry, circuit breaker, redaction, validated templates, checksums, atomic output, and accessibility evidence.

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
