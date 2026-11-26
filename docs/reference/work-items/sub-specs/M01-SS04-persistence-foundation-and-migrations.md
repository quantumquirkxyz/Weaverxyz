# [Sub-Spec][M01-SS04] Persistence Foundation and Migrations

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS04
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Design → Implementation → Verification
- **Status:** Triage
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Data / Persistence
- **Repo Scope:** `PipelineOrchestrator.Data`
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss04-persistence-v1`

## Capability and outcome

Establish a PostgreSQL persistence foundation that supports versioned Pipelines, validated JSONB, incremental execution state, auditability, idempotency, recovery, schema evolution, and reproducible integration testing.

## Scope

Implement PostgreSQL schema, versioned migrations, Npgsql data access, repositories, transaction boundaries, outbox/audit records, JSONB policies, indexes, triggers, backup/restore verification, and recovery metadata for the M01 vertical slice.

## Relational model

The initial model includes:

- `pipelines`
- `pipeline_versions`
- `steps`
- `step_configs`
- `step_contracts`
- `capability_versions`
- `execution_runs`
- `step_logs`
- `execution_events`
- `idempotency_records`
- `configuration_snapshots`
- `recovery_records`
- `schema_migrations`
- `audit_events`
- retention and redaction metadata

Foreign keys, uniqueness, check constraints, indexes, and state invariants are explicit. `ExecutionRun` references one immutable Pipeline version and definition hash.

## JSONB policy

JSONB is used for step-specific configuration, contracts, input/output snapshots, event payloads, and structured diagnostics. Metadata required for filtering, identity, dates, status, relations, and integrity remains typed relational data.

Every JSONB value is schema-versioned and validated before write/read. JSONB has size limits, content hashes, sensitivity classification, redaction metadata, compatibility rules, and migration support. Secrets are prohibited. JSONB indexes are added only for measured access patterns.

## Migration strategy

Migrations are versioned, checksum-protected, forward-first, and validated against real PostgreSQL. Schema changes use expand/contract where compatibility requires it. Data backfills are separate, resumable, observable, and idempotent. Drift detection compares applied migrations and checksums with the repository baseline. Destructive operations require explicit approval, backup evidence, and a restore plan.

## Transaction and event boundaries

- Create `ExecutionRun` before execution.
- Persist Step transitions and `StepLog` records using short transactions.
- Do not hold a database transaction during HTTP, agent, file, or long-running external work.
- Persist events/audit through an outbox boundary.
- Use idempotency keys for retries and reconciliation.
- Detect and recover incomplete transactions or abandoned runs.
- Record rollback/compensation outcomes independently.

## Repository contracts

Repositories are aggregate-oriented and interfaces are defined in Core:

- `PipelineRepository`
- `ExecutionRepository`
- `LogRepository`
- `ConfigurationSnapshotRepository`
- `RecoveryRepository`
- `AuditRepository`

Implementations in Data provide explicit transaction boundaries, optimistic concurrency, idempotency, pagination, safe filtering, cancellation, timeouts, redaction, and typed errors. SQL and Npgsql details do not leak to UI or domain callers.

## Performance and integrity

Indexes are justified by access patterns for execution history, statuses, dates, dependencies, idempotency, and reconciliation. JSONB indexes require measured query value. Query plans are tested with `EXPLAIN`; unbounded queries and unbounded pagination are prohibited. Migration reviews include index cost and lock impact.

## Backup and recovery

Provide reproducible backup and restore procedures, checksum verification, referential-integrity checks, migration application, sensitive-data protection, and auditable evidence. Establish initial RPO/RTO targets. Recovery includes abandoned `ExecutionRun` detection, outbox reconciliation, and safe state repair.

## Definition of Ready

- Parent Spec and M01-SS04 boundary are accepted.
- Relational model, JSONB policy, migration policy, repository aggregates, recovery expectations, and security rules are documented.
- Required Project metadata, dependencies, risks, tests, and evidence are assigned.
- No unresolved data ownership or migration conflict blocks implementation.

## Definition of Done

- Complete relational schema and constraints exist.
- JSONB is schema-validated, size-limited, hashed, classified, redacted, and secret-free.
- Migrations have checksums, compatibility rules, drift detection, backfill plans, and controlled destructive-change policy.
- Aggregate repositories implement explicit transaction, concurrency, idempotency, pagination, and error contracts.
- Outbox/audit and incremental execution persistence work.
- Indexes and query plans are reviewed with baselines.
- Backup/restore and abandoned-run recovery are tested.
- RPO/RTO initial targets and runbooks exist.
- Integration, migration, restore, concurrency, performance, redaction, integrity, and recovery tests pass.
- Documentation, ADRs, Project metadata, and evidence report are synchronized.

## Acceptance criteria

1. A clean PostgreSQL instance can apply migrations reproducibly.
2. Migration checksums and drift are detected.
3. A Pipeline version and definition hash can be persisted immutably.
4. ExecutionRun and StepLog transitions persist incrementally.
5. JSONB schemas, redaction, size limits, and secret prohibition are enforced.
6. Repository operations preserve transaction and concurrency invariants.
7. Outbox events and idempotency records support retry/reconciliation.
8. Unavailable, abandoned, or partially completed executions can be detected and recovered according to policy.
9. Backup restore produces an integrity-validated database that can apply pending migrations.
10. Query-plan, performance, and pagination constraints are evidenced.

## Expected evidence

- ERD and migration manifest
- Applied migration/checksum report
- JSONB schema and redaction test output
- Repository contract and integration test output
- Transaction/outbox/idempotency evidence
- Index and query-plan review
- Backup/restore and checksum evidence
- RPO/RTO and recovery runbook
- Abandoned-run recovery result
- Documentation, ADR, and Project traceability links
