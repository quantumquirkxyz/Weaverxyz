# [Sub-Spec][M06-SS01] Scheduler and Execution States

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M06] Execution, Retry, Rollback, and Recovery`
- **Milestone:** M06 — Execution, Retry, Rollback, and Recovery
- **Semantic ID:** M06-SS01
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Core / Orchestrator
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m06-ss01-v1`

## Capability and outcome

Implement governed DAG scheduling and formal ExecutionRun/StepLog state machines with topological traversal, ready queue, dependency counts, deterministic ordering, priority, backpressure, starvation detection, concurrency boundaries, timeout/cancellation, budgets, atomic transitions, causality, recovery/compensation states, invalid-transition rejection, audit, and future-safe parallelism.

## Dependencies

M01 execution seams; M02 contracts; M03 published definitions; M05 outcomes

## Scope boundaries

This Sub-Spec consumes M01–M05 contracts and implementations. It owns the declared runtime scheduling, resilience, rollback/recovery, or verification seam and must not redefine Pipeline authoring, connector behavior, transformation logic, or domain contracts.

## Definition of Ready

- M06 Parent Spec and this boundary are accepted.
- Dependencies, fault fixtures, external-effect doubles, security controls, ownership, budgets, and evidence expectations are resolved.
- Implementation choices required for Tickets are explicit.

## Definition of Done

- The declared capability or quality gate is implemented, versioned, validated, observable, and auditable.
- Positive, negative, security, redaction, resilience, determinism, recovery, and performance tests pass.
- Evidence is reproducible and checksummed.
- ADRs, documentation, Project metadata, and native relationships are synchronized.
- The Sub-Spec is explicitly accepted before Tickets are generated.

## Acceptance criteria

1. Declared runtime behavior follows typed versioned contracts and policy.
2. Invalid, unsafe, ambiguous, duplicate-prone, or over-budget behavior fails closed.
3. Effects, state, events, diagnostics, and recovery decisions are correlated and auditable.
4. Fault and uncertainty scenarios preserve original failure context and residual risk.
5. Required tests produce deterministic results and an artifact manifest.

## Expected evidence

- Runtime state and policy diagrams
- Contract and configuration manifest
- Positive/negative/resilience test output
- Recovery, redaction, security, and performance evidence
- Replay/fault/chaos results
- Reproducibility and checksummed evidence manifest
- Documentation, ADR, Project, and traceability links
- Scheduler, property-based, state-machine, transition, determinism, budget, and cancellation tests.
