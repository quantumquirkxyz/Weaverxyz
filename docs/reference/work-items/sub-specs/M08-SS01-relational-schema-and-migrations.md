# [Sub-Spec][M08-SS01] Relational Schema and Migrations

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M08] PostgreSQL Persistence and Migrations`
- **Milestone:** M08 — PostgreSQL Persistence and Migrations
- **Semantic ID:** M08-SS01
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Data / Persistence
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m08-ss01-v1`

## Capability and outcome

Implement the complete PostgreSQL relational model with tables, relationships, foreign keys, uniqueness/check constraints, invariants, justified indexes, JSONB schema references, versioned checksummed forward-first migrations, expand/contract, resumable idempotent backfills, drift detection, lock/concurrency control, destructive-change approval, backup/restore plan, and application evidence.

## Dependencies

M01 persistence seam; M02–M07 contracts and records

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
- Schema, migration, checksum, drift, backfill, compatibility, lock, integrity, and destructive-change tests.
