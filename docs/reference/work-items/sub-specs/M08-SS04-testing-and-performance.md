# [Sub-Spec][M08-SS04] Testing and Performance

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M08] PostgreSQL Persistence and Migrations`
- **Milestone:** M08 — PostgreSQL Persistence and Migrations
- **Semantic ID:** M08-SS04
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Cross-cutting / QA
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m08-ss04-v1`

## Capability and outcome

Establish PostgreSQL quality gates for real integration, migrations, restore, repositories, transactions, outbox/idempotency, concurrency, JSONB, integrity, query plans, performance, retention, drift, abandoned-run recovery, security, secret protection, isolated fixtures, reproducibility, and checksummed evidence.

## Dependencies

M08-SS01 through SS03

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
- Reproducible persistence matrix, performance/security/recovery report, and Project reconciliation.
