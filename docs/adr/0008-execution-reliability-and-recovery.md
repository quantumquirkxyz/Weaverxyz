# ADR-008: Execution Reliability, Compensation, and Recovery

## Status

Accepted

## Context

Pipeline steps may touch files, databases, HTTP endpoints, or external AI agents. Some effects are reversible; others require compensation. Execution must remain auditable and recoverable after errors, cancellation, or process interruption.

## Decision

Every `StepCommand` implements `Execute()` and `Rollback()`. Each Step declares reversibility, compensation action, evidence, and residual risk. A non-compensable Step requires explicit approval before execution.

Retry policies use explicit retryable-error classification, exponential backoff with jitter, idempotency keys, timeouts, circuit breakers, rate limits, and diagnostics. Failed execution rolls back completed commands in LIFO order, then stops. Rollback failures are recorded as separate high-severity events.

`ExecutionRun` is persisted incrementally. Each Step transition produces a durable `StepLog`. Runs reference the immutable Pipeline version and definition hash. Abandoned runs are detected and reconciled through an explicit recovery policy.

## Consequences

- External side effects are not falsely treated as ACID transactions.
- Recovery and auditing survive process interruption.
- Every connector must declare idempotency and compensation behavior.
- Resilience adds configuration and test complexity but prevents duplicate or invisible effects.
