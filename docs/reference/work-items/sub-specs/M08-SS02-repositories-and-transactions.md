# [Sub-Spec][M08-SS02] Repositories and Transactions

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M08] PostgreSQL Persistence and Migrations`
- **Milestone:** M08 — PostgreSQL Persistence and Migrations
- **Semantic ID:** M08-SS02
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Data / Persistence
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m08-ss02-v1`

## Capability and outcome

Implement Core interfaces and Data aggregate repositories with short transactions, optimistic concurrency, idempotency, safe pagination/filters, cancellation/timeouts, outbox/audit, redaction, typed errors, incremental execution persistence, recovery records, and SQL/Npgsql isolation.

## Dependencies

M08-SS01; M01 persistence; M02 contracts

## Scope boundaries

This Sub-Spec consumes M01–M07 contracts and persistence consumers. It owns the declared schema, repository, recovery, or verification seam and must not move SQL/Npgsql outside Data or redefine domain/runtime policy.

## Definition of Ready

- M08 Parent Spec and this boundary are accepted.
- PostgreSQL test/restore environments, security controls, ownership, retention, numeric limits, and evidence expectations are resolved.
- Implementation choices required for Tickets are explicit.

## Definition of Done

- The declared capability or quality gate is implemented, versioned, validated, observable, and auditable.
- Positive, negative, integrity, security, redaction, concurrency, recovery, restore, and performance tests pass.
- Evidence is reproducible and checksummed.
- ADRs, documentation, Project metadata, and native relationships are synchronized.
- The Sub-Spec is explicitly accepted before Tickets are generated.

## Acceptance criteria

1. Declared persistence behavior follows versioned schemas, migration, repository, or recovery contracts.
2. Invalid, incompatible, drifted, unsafe, secret-bearing, or over-budget operations fail closed.
3. Data integrity, transaction, idempotency, recovery, retention, and audit behavior is reproducible.
4. Query plans and restore/recovery outcomes are evidenced against controlled fixtures.
5. Required tests produce deterministic results and an artifact manifest.

## Expected evidence

- ERD, migration, repository, or recovery diagrams
- Schema/checksum/JSONB manifest
- Integration, restore, integrity, and performance output
- Security/redaction/retention evidence
- Reproducibility and checksummed evidence manifest
- Documentation, ADR, Project, and traceability links
- Repository contract, transaction, concurrency, outbox, idempotency, recovery, and redaction tests.
