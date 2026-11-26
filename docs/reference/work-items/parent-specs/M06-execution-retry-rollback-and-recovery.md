# [Parent Spec][M06] Execution, Retry, Rollback, and Recovery

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Feature
- **Milestone:** M06 — Execution, Retry, Rollback, and Recovery
- **Semantic ID:** M06
- **Owner:** `quantumquirkxyz`
- **Phase:** Requirements → Architecture → Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Repo Scope:** `PipelineOrchestrator.Core`, `PipelineOrchestrator.Data`
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m06-execution-retry-recovery-v1`

## Objective

Deliver the governed execution runtime that schedules validated Pipeline DAGs, enforces formal state machines and operational budgets, performs safe retries and LIFO compensation, handles cancellation and shutdown, recovers abandoned executions, and emits complete auditable evidence.

## Boundary with earlier milestones

M01 provides foundational execution and persistence seams. M02 owns domain contracts, errors, events, idempotency, and compensation metadata. M03 owns published Pipeline definitions. M04 owns connectors. M05 owns transformation and validation outcomes. M06 owns runtime orchestration, retry decisions, rollback execution, shutdown, recovery, reconciliation, and runtime evidence.

## Scheduler

The scheduler traverses validated DAGs with a ready queue, dependency counts, deterministic ordering, priority, cancellation, backpressure, resource budgets, starvation detection, and future-safe concurrency boundaries. Initial execution remains sequential unless dependency, idempotency, resource, ordering, and security policies permit future parallelism.

## State machines

`ExecutionRun` and `StepLog` use versioned formal state machines with allowed transitions, invariants, entry/exit events, atomicity, causality, compensation states, recovery states, abandonment detection, and audited rejection of invalid transitions.

Expected states include `Pending`, `Ready`, `Running`, `Retrying`, `Completed`, `Failed`, `RollingBack`, `RolledBack`, `CompensationFailed`, `Cancelled`, `TimedOut`, `Interrupted`, `RecoveryRequired`, `Recovered`, and `RecoveryFailed`.

## Retry and compensation

Retry uses typed error classification, allowlists, attempt and total budgets, exponential backoff with jitter, idempotency keys, circuit breakers, rate limits, timeout, cancellation, per-attempt diagnostics, and final auditable decisions. Compensation snapshots completed commands and executes strict LIFO with policy, timeout, safe retry, idempotency, evidence, residual-risk records, and fail-closed escalation.

## Cancellation and recovery

Cancellation propagates cooperatively; no new Steps start, cleanup/compensation is bounded, durable state is persisted, outbox work is reconciled, and uncertain effects are marked for recovery. Heartbeat/timeout detection reconstructs abandoned runs from events and logs, classifies completed/uncertain/pending Steps, verifies idempotency, performs safe cleanup or compensation, requires approval for uncertain effects, prevents duplicates, and exports diagnostics.

## Operational governance

Budgets cover Step/Pipeline timeout, total runtime, memory, DataPacket size/rows, concurrency, external calls, AgentCall tokens/cost, rate limits, backpressure, disk, and queue capacity. Events carry versions, correlation, causality, state transitions, timing, retry/compensation context, resource metrics, sensitivity/redaction, and diagnostic references. Metrics, health, audit, snapshots, and exports are redacted and reproducible.

## Dependencies and consumers

- M02 domain, error, event, idempotency, compensation, and capability contracts.
- M03 published immutable Pipeline versions.
- M04 connector policies and effects.
- M05 transformation/validation outcomes and quality decisions.
- M07 consumes runtime state/events for UI monitoring.
- M08 persists execution state, events, recovery records, and evidence.
- M09 consumes AgentCall retry, cost, security, and recovery policies.

## Definition of Ready

- M02–M05 contracts and required implementations are accepted.
- Scheduler, states, retry, compensation, cancellation, recovery, budgets, observability, security, tests, and evidence are documented.
- Recovery fixtures, fault injection, and external-effect test doubles are assigned.
- No unresolved ownership or runtime semantics conflict blocks decomposition.

## Definition of Done

- Valid DAGs execute through a governed scheduler.
- Formal state machines reject invalid transitions and preserve causality.
- Retry decisions are typed, idempotent, bounded, resilient, and auditable.
- Rollback/compensation is strict LIFO, timeout-bound, evidence-producing, and fail-closed on failure.
- Cancellation/shutdown and abandoned-run recovery persist safe durable state.
- Budgets, backpressure, metrics, health, audit, redaction, and diagnostics work.
- PostgreSQL and connector integration, fault injection, replay, resilience, security, and recovery tests pass.
- Documentation, ADRs, Project metadata, and evidence manifest are synchronized.

## Acceptance criteria

1. A valid DAG executes deterministically and respects dependencies and budgets.
2. Invalid state transitions are rejected, persisted, and audited.
3. Retry occurs only for allowlisted safe effects and stops at policy budgets.
4. Step failure triggers strict LIFO compensation without hiding the original failure.
5. Cancellation prevents new work and persists a recoverable state.
6. Abandoned runs are reconstructed without duplicate effects.
7. Resource violations fail closed with correlated diagnostics.
8. Events, metrics, health, snapshots, and audit records are versioned and redacted.
9. Fault injection and deterministic replay reproduce expected outcomes.

## Expected evidence

- Scheduler/DAG execution traces
- State transition matrix and negative tests
- Retry/backoff/circuit-breaker report
- Compensation and residual-risk evidence
- Cancellation/shutdown report
- Budget/backpressure report
- Abandoned-run recovery and reconciliation report
- Event causality, metrics, health, redaction, and diagnostics output
- Fault-injection, replay, PostgreSQL, and connector integration results
- Documentation, ADR, Project, and traceability links
