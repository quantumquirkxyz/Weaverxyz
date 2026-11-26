# [Parent Spec][M08] PostgreSQL Persistence and Migrations

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Feature
- **Milestone:** M08 — PostgreSQL Persistence and Migrations
- **Semantic ID:** M08
- **Owner:** `quantumquirkxyz`
- **Phase:** Requirements → Architecture → Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Repo Scope:** `PipelineOrchestrator.Data`
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m08-postgresql-persistence-v1`

## Objective

Deliver the governed PostgreSQL persistence platform for Pipeline definitions, execution state, events, configuration snapshots, recovery, audit, retention, redaction, schema evolution, backup, restore, performance, and reproducible integration evidence.

## Boundary with earlier milestones

M01 provides foundational persistence seams. M02 owns domain contracts and serialization semantics. M03 owns Pipeline version lifecycle. M04 owns connector effects. M05 owns processing outcomes. M06 owns runtime recovery policy. M07 consumes persistence/application contracts. M08 owns PostgreSQL schema, migrations, repositories, transaction boundaries, query performance, backup/restore, retention, drift, and persistence evidence.

## Relational model

The model includes `pipelines`, `pipeline_versions`, `steps`, `step_configs`, `step_contracts`, `capability_versions`, `execution_runs`, `step_logs`, `execution_events`, `idempotency_records`, `configuration_snapshots`, `recovery_records`, `schema_migrations`, `audit_events`, retention metadata, and redaction metadata. Foreign keys, unique/check constraints, invariants, indexes, and immutable-version rules are explicit.

## Migration governance

Migrations are versioned, checksum-protected, forward-first, and validated against real PostgreSQL. Expand/contract preserves compatibility. Data backfills are separate, resumable, observable, and idempotent. Drift detection compares applied checksums to the repository baseline. Destructive changes require approval, backup evidence, restore plan, and audit.

## JSONB policy

Step-specific configuration, contracts, snapshots, event payloads, and diagnostics use versioned JSONB schemas validated on write/read. Typed relational columns hold identity, status, dates, relationships, and query metadata. JSONB is bounded, hashed, classified, redacted, compatibility-aware, migration-capable, and secret-free. Indexes require a justified access pattern.

## Repository and transaction policy

Aggregate repository interfaces live in Core and implementations in Data. Operations use short transactions, optimistic concurrency, idempotency, safe pagination/filters, cancellation/timeouts, outbox/audit, redaction, typed errors, and recovery. Database transactions never span long external work and SQL/Npgsql details do not leak to UI/domain callers.

## Performance and recovery

Indexes and query plans are governed by measured access patterns. `EXPLAIN`, pagination limits, latency/throughput metrics, baselines, lock-impact review, and migration index review are mandatory. Backup/restore is reproducible and validates checksums, referential integrity, migrations, sensitive-data protection, RPO/RTO, abandoned-run recovery, outbox reconciliation, and runbook evidence.

## Dependencies and consumers

- M01 persistence seam.
- M02 schemas, contracts, events, redaction, and compatibility.
- M03 version lifecycle and published definitions.
- M04 connector/external-effect evidence.
- M05 transformation/validation evidence.
- M06 runtime state and recovery records.
- M07 UI history, logs, and diagnostics.
- M09 AgentCall configuration and security evidence.

## Definition of Ready

- M01–M07 persistence consumers and contracts are accepted.
- Relational model, JSONB, migration, repository, transaction, performance, backup, retention, security, and recovery policies are documented.
- PostgreSQL test infrastructure and restore environment are assigned.
- No unresolved data ownership or migration conflict blocks decomposition.

## Definition of Done

- Complete relational schema, constraints, invariants, and metadata exist.
- JSONB is validated, bounded, hashed, classified, redacted, compatible, and secret-free.
- Migrations have checksums, drift detection, expand/contract, backfills, and destructive-change controls.
- Repositories implement aggregate, transaction, concurrency, idempotency, pagination, redaction, and typed-error contracts.
- Outbox/audit, incremental persistence, recovery, retention, and reconciliation work.
- Indexes, query plans, performance baselines, backup/restore, RPO/RTO, and runbooks are evidenced.
- PostgreSQL integration, migration, restore, concurrency, redaction, integrity, retention, performance, drift, and recovery tests pass.
- Documentation, ADRs, Project metadata, and evidence manifest are synchronized.

## Acceptance criteria

1. A clean PostgreSQL instance applies migrations reproducibly and detects checksum drift.
2. Pipeline versions and execution records persist immutably and incrementally.
3. JSONB validation, limits, redaction, hashing, compatibility, and secret prohibition are enforced.
4. Repository operations preserve transaction, concurrency, idempotency, and recovery invariants.
5. Outbox/audit records support reconciliation without duplication.
6. Query plans, pagination, indexes, and performance baselines are evidenced.
7. Backup restore validates integrity and applies pending migrations.
8. Abandoned-run recovery, retention, redaction, RPO/RTO, and runbook evidence pass.

## Expected evidence

- ERD and migration manifest
- Applied checksum/drift report
- JSONB schema/redaction/secret-scan results
- Repository contract and integration tests
- Transaction/outbox/idempotency/concurrency evidence
- Index/query-plan/performance report
- Backup/restore/checksum and RPO/RTO evidence
- Recovery, retention, and reconciliation runbook
- Documentation, ADR, Project, and traceability links
