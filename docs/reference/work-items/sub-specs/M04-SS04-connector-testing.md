# [Sub-Spec][M04-SS04] Connector Testing

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M04] Source and Sink Connectors`
- **Milestone:** M04 — Source and Sink Connectors
- **Semantic ID:** M04-SS04
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Cross-cutting / QA
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m04-ss04-v1`

## Capability and outcome

Establish common connector contract tests and complete quality gates across filesystem, PostgreSQL, HTTP, and report connectors, including serialization, idempotency, transactions, resilience, cancellation, backpressure, resource budgets, fault injection, security, redaction, performance, recovery, reproducibility, and evidence manifests.

## Dependencies

M04-SS01 through SS03

## Scope boundaries

This Sub-Spec consumes M02 capability/DataPacket contracts, M03 published definitions, and M01 infrastructure seams. It owns the declared connector or verification seam and must not redefine domain contracts, Pipeline lifecycle, or execution infrastructure.

## Definition of Ready

- M04 Parent Spec and this boundary are accepted.
- Dependencies, external fixtures, security controls, ownership, and evidence expectations are resolved.
- Numeric limits and implementation choices required for Tickets are explicit.

## Definition of Done

- The declared connector or quality gate is implemented, versioned, validated, and observable.
- Positive, negative, security, redaction, resilience, and recovery tests pass.
- Evidence is reproducible and checksummed.
- ADRs, documentation, Project metadata, and native relationships are synchronized.
- The Sub-Spec is explicitly accepted before Tickets are generated.

## Acceptance criteria

1. The declared connector capability or test contract resolves through the Capability Registry.
2. Invalid configuration, schemas, credentials, destinations, limits, and policies fail closed.
3. External effects respect idempotency, timeout, cancellation, compensation, and redaction rules.
4. Security-specific threats and recovery behavior are evidenced.
5. Required tests produce deterministic results and an artifact manifest.

## Expected evidence

- Connector contract and configuration schema
- Integration and fixture results
- Security/redaction/resilience evidence
- Performance and recovery report
- Reproducibility and checksummed evidence manifest
- Documentation, ADR, Project, and traceability links
- Checksummed test matrix, security/performance/recovery report, reproducibility evidence, and Project reconciliation.
