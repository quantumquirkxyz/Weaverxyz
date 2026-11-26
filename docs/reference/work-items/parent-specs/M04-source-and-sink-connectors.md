# [Parent Spec][M04] Source and Sink Connectors

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Feature
- **Milestone:** M04 — Source and Sink Connectors
- **Semantic ID:** M04
- **Owner:** `quantumquirkxyz`
- **Phase:** Requirements → Architecture → Design → Implementation → Verification
- **Status:** Draft
- **Priority:** High
- **Risk:** Critical
- **Repo Scope:** `PipelineOrchestrator.Core`, `PipelineOrchestrator.Data`
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m04-source-sink-connectors-v1`

## Objective

Deliver the initial governed connector catalog for file, PostgreSQL, HTTP, and report sources/sinks while preserving M02 contracts, M03 published Pipeline definitions, and M01 execution, configuration, persistence, security, and observability boundaries.

## Boundary with earlier milestones

M01 provides infrastructure and execution seams. M02 owns capability and DataPacket contracts. M03 owns Pipeline authoring and publication lifecycle. M04 owns connector implementations, connector-specific configuration, external-system safety, transport limits, transaction/compensation behavior, and connector verification.

## Initial catalog

- `FileSource`
- `FileSink`
- `PostgresSource`
- `PostgresSink`
- `HttpSource`
- `ReportSink`

Each capability is registered through the M02 Capability Registry and exposes versioned schemas, configuration, security, resilience, resource, idempotency, compensation, and observability metadata.

## Common connector contract

Connectors expose validated configuration, lifecycle, `Connect`, `Read`/`Write`, `Validate`, and `Dispose` behavior with typed results/errors. Contracts include streaming/batching, backpressure, cancellation, timeout, retry, circuit breaker, idempotency, transactions/compensation, resource budgets, sensitivity/redaction, health checks, metrics, and audit events.

## File policy

File connectors use path/root allowlists, path traversal prevention, explicit encoding/delimiter/header rules, CSV/JSON schemas, size/row limits, streaming, atomic writes, staging/commit, checksums, idempotency, cleanup/rollback, permissions, locking, redaction, and secret prohibition.

## PostgreSQL policy

PostgreSQL connectors use `ISecretProvider`, TLS, host/database/schema/table allowlists, parameterized queries, permission boundaries, streaming/batching, row/size limits, transactions, staging tables, upsert/idempotency, compensation, timeout/cancellation, safe retry, redacted observability, query plans, and performance evidence.

## HTTP policy

`HttpSource` enforces HTTPS and host allowlists, SSRF protection, safe DNS resolution, metadata/link-local blocking, secret-provider authentication, header/payload redaction, response/time/memory limits, pagination/streaming, safe retry with backoff/jitter, circuit breaker, rate limits, cancellation, schema validation, idempotency, and fault-injection tests.

## Report policy

`ReportSink` uses versioned formats, validated templates and input schemas, sensitivity/redaction, size limits, atomic writes, manifests/checksums, idempotency, staging/commit, rollback/cleanup, output allowlists, audit trail, observability, and accessibility validation for visual output.

## Dependencies and consumers

- M02 capabilities, DataPacket, schemas, errors, events, security, and resilience contracts.
- M03 published Pipeline definitions and capability dependencies.
- M05 consumes connector outputs and schemas for transforms/validators.
- M06 consumes connector retry, idempotency, compensation, and recovery metadata.
- M07 consumes connector configuration and monitoring state.
- M08 persists connector execution evidence and snapshots.
- M09 may consume HTTP and Agent-related security seams.

## Definition of Ready

- M02 and M03 contracts are accepted and available.
- Connector catalog, common contract, external-system policies, security boundaries, tests, and evidence are documented.
- Test fixtures and safe external-system environments are assigned.
- No unresolved connector ownership or security conflict blocks decomposition.

## Definition of Done

- All initial capabilities are registered and versioned.
- Common connector contract and per-connector configuration schemas are implemented.
- File, PostgreSQL, HTTP, and Report connectors pass functional and negative verification.
- Streaming/batching, limits, backpressure, timeout, cancellation, retries, circuit breakers, idempotency, transactions, compensation, and cleanup are evidenced.
- Path traversal, SSRF, SQL injection, secret exposure, permission, redaction, and audit gates pass.
- Integration, fault-injection, performance, query-plan, and reproducibility tests pass.
- Documentation, ADRs, Project metadata, and evidence manifest are synchronized.

## Acceptance criteria

1. Each initial connector resolves through the Capability Registry with versioned metadata.
2. Invalid configuration, schemas, policies, credentials, limits, and destinations fail closed.
3. File operations prevent traversal and provide atomic, idempotent, recoverable writes.
4. PostgreSQL operations use safe credentials, parameterized access, transactions, limits, and recovery.
5. HTTP operations enforce SSRF/TLS/host policies and safe resilience behavior.
6. Reports are redacted, checksummed, reproducible, and written only to approved destinations.
7. Connector events, metrics, health, errors, and snapshots are correlated and redacted.
8. Contract, integration, security, fault, performance, and reproducibility tests pass.

## Expected evidence

- Connector catalog and registry report
- Common/per-connector contract and schema manifest
- File security and atomic-write evidence
- PostgreSQL integration, transaction, query-plan, and performance evidence
- HTTP SSRF/security/resilience evidence
- Report redaction, integrity, and accessibility evidence
- Fault-injection, recovery, and reproducibility reports
- Documentation, ADR, Project, and traceability links
