# [Sub-Spec][M04-SS02] PostgreSQL Connectors

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M04] Source and Sink Connectors`
- **Milestone:** M04 — Source and Sink Connectors
- **Semantic ID:** M04-SS02
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Data / Persistence
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m04-ss02-v1`

## Capability and outcome

Implement PostgresSource and PostgresSink with ISecretProvider, TLS, host/database/schema/table allowlists, permissions, parameterized queries, streaming/batching, limits, transactions, staging, upsert/idempotency, compensation, timeout/cancellation, safe retry, redaction, audit, query plans, performance, and recovery verification.

## Dependencies

M02 contracts; M03 published definitions; M01 persistence

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
- Real PostgreSQL integration, SQL security, transaction, query-plan, performance, idempotency, and recovery tests.
