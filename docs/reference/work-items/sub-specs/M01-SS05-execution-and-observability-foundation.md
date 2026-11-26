# [Sub-Spec][M01-SS05] Execution and Observability Foundation

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS05
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Design → Implementation → Verification
- **Status:** Triage
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Orchestrator / Core
- **Repo Scope:** `PipelineOrchestrator.Core`
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss05-execution-observability-v1`

## Capability and outcome

Establish the governed execution engine that validates and traverses Pipeline DAGs, executes registered StepCommands, enforces state transitions and resource budgets, performs safe retries and compensation, persists progress, recovers interrupted runs, and emits complete observable evidence.

## Scope

- Implement `PipelineRunner`, scheduler, ready queue, and topological traversal.
- Keep sequential execution as the initial strategy while preserving a controlled path to future parallelism.
- Implement formal `ExecutionRun` and `StepLog` state machines.
- Implement `StepExecutor`, typed results, errors, events, and causal correlation.
- Implement mandatory LIFO rollback/compensation.
- Implement retryable-error classification, exponential backoff with jitter, idempotency, circuit breaker, and rate limits.
- Implement cancellation tokens, timeouts, cooperative shutdown, and recovery boundaries.
- Enforce resource budgets and backpressure.
- Persist progress incrementally through repository/outbox contracts.
- Detect abandoned executions and reconcile state.
- Emit structured metrics, health signals, redacted snapshots, audit events, and exportable diagnostics.

## Scheduler

The scheduler performs topological traversal over a validated DAG. It maintains a ready queue, dependency counts, execution ordering, priority policy, resource budget, cancellation state, and backpressure. Initial execution is sequential. Future parallel execution must preserve dependency, ordering, idempotency, resource, and security policies.

## Formal state machines

`ExecutionRun` and `StepLog` states are defined by versioned contracts with allowed transitions, transition invariants, entry/exit events, timestamps, causal IDs, recovery states, and compensation states. Invalid transitions are rejected and audited.

Expected states include `Pending`, `Ready`, `Running`, `Retrying`, `Completed`, `Failed`, `RollingBack`, `RolledBack`, `CompensationFailed`, `Cancelled`, `TimedOut`, `Interrupted`, `RecoveryRequired`, `Recovered`, and `RecoveryFailed` where applicable.

## Rollback and compensation

When a Step fails, the engine stops new work and rolls back completed commands in strict LIFO order. Each Step's policy controls reversibility, compensation, timeout, retry safety, idempotency key, evidence, and residual risk. Rollback errors are isolated, recorded, and never overwrite the original failure. A compensation failure produces a fail-closed recovery state and escalation evidence.

## Retry and resilience

Retry occurs only for allowlisted retryable errors. Policies include maximum attempts, total budget, exponential backoff with jitter, idempotency keys, circuit breaker, rate limits, cancellation, timeout, and per-attempt diagnostics. Non-idempotent or non-compensable effects cannot be retried without explicit policy approval.

## Cancellation and shutdown

Cancellation propagates through tokens. The scheduler does not start new Steps after cancellation, allows safe cleanup/compensation, enforces a shutdown timeout, persists durable state, closes/reconciles outbox work, and marks uncertain effects for recovery. On restart, abandoned runs are detected from heartbeat/timeout data and reconciled from events and StepLogs.

## Resource budgets

Budgets cover Step/Pipeline timeout, total runtime, memory, DataPacket size, row count, concurrency, external calls, AgentCall tokens/cost, rate limits, disk, and queue/backpressure. Exceeding a protected budget fails closed with structured evidence.

## Observability

Every event carries event/schema version, correlation ID, execution ID, Pipeline version ID, Step ID, causal relation, previous/new state, timestamp, duration, retry/compensation context, resource metrics, sensitivity/redaction metadata, and diagnostic references. UI, persistence, metrics, health checks, audit, and diagnostic export consume shared contracts.

## Definition of Ready

- Parent Spec and M01-SS05 boundary are accepted.
- Scheduler, state machine, rollback, retry, cancellation, recovery, budget, event, and observability policies are documented.
- Repository/outbox contracts and required Project metadata are assigned.
- Failure modes, security/redaction, tests, and evidence are explicit.
- No unresolved execution semantics conflict blocks implementation.

## Definition of Done

- Scheduler validates and traverses DAGs topologically.
- Formal state machines enforce valid transitions.
- Rollback/compensation is LIFO, policy-driven, idempotent, timeout-bound, and auditable.
- Retry policy classifies errors and enforces backoff, circuit breaker, limits, and idempotency.
- Cancellation and shutdown persist safe durable states.
- Resource budgets and backpressure are enforced.
- Abandoned runs are detected, classified, recovered, or escalated safely.
- Events, metrics, health signals, redacted snapshots, audit records, and diagnostics are complete.
- Incremental persistence and outbox reconciliation work.
- Unit, property-based, state-machine, resilience, fault-injection, replay, integration, and redaction tests pass.
- Documentation, ADRs, Project metadata, and evidence report are synchronized.

## Acceptance criteria

1. A valid DAG executes in deterministic topological order.
2. A blocked dependency prevents a Step from entering the ready queue.
3. Invalid state transitions are rejected and audited.
4. A Step failure stops new work and triggers LIFO compensation.
5. Compensation failure preserves the original failure and creates a recovery state.
6. Retry occurs only for allowlisted retryable, idempotent effects.
7. Cancellation prevents new work and persists a recoverable state.
8. Resource budget violations fail closed with diagnostic evidence.
9. An abandoned run is reconstructed from events/logs without duplicate effects.
10. Observability events are correlated, versioned, redacted, persisted, and exportable.
11. Fault injection, replay, and determinism tests reproduce expected outcomes.

## Expected evidence

- Scheduler/DAG execution trace
- State-machine transition matrix and negative tests
- Rollback/compensation evidence
- Retry/backoff/circuit-breaker report
- Cancellation/shutdown report
- Resource-budget and backpressure report
- Abandoned-run recovery report
- Event causality and metrics output
- Redaction/security evidence
- Fault-injection and replay test output
- Documentation, ADR, and Project traceability links
