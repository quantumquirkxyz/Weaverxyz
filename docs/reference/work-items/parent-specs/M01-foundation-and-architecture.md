# [Parent Spec][M01] Foundation and Architecture

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Epic
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Implementation → Verification
- **Status:** Triage
- **Priority:** Critical
- **Risk:** High
- **Repo Scope:** Cross-cutting (`PipelineOrchestrator.UI`, `PipelineOrchestrator.Core`, `PipelineOrchestrator.Data`)
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m01-foundation-architecture-v1`

## Objective

Establish a functional, testable, observable, and reproducible architectural foundation for Weaverxyz, including a complete desktop vertical slice from Windows Forms through Core execution to PostgreSQL persistence.

M01 must prove that the solution boundaries, contracts, configuration, persistence, execution, UI, observability, testing, and recovery model work together before later milestones add product capabilities.

## Users and outcomes

### Student/developer

Can inspect and extend a three-project C#/.NET solution using explicit contracts, patterns, ADRs, tests, and traceability.

### Technical operator

Can use the Windows Forms application to create or load a versioned pipeline, validate it, execute it, observe progress, inspect redacted evidence, and diagnose failure.

## Scope

- Create `PipelineOrchestrator.sln` with `UI`, `Core`, and `Data` projects.
- Enforce dependency direction: `UI → Core`; `Data → Core`; `Core` does not reference `Data`.
- Establish composition root/factory in the UI entry point.
- Define versioned domain contracts and schemas.
- Define extensible capability registry for sources, transforms, validators, sinks, and subpipelines.
- Implement controlled polymorphic `DataPacket`.
- Implement governed environment configuration.
- Implement PostgreSQL schema, versioned migrations, triggers, repositories, and recovery metadata.
- Implement sequential topological execution of a DAG.
- Implement mandatory `Execute()`/`Rollback()` contract with compensation metadata.
- Implement retry classification, idempotency keys, timeout, circuit breaker, and diagnostics foundations.
- Implement structured observability and redacted snapshots.
- Implement the Windows Forms vertical slice.
- Implement the M01 quality-gate and resilience-test foundation.

## Exclusions

M01 does not deliver the full advanced feature set of M02–M10. It does not include multi-user collaboration, distributed or remote execution, high availability, external scheduling, queues/event buses, cloud deployment, native cross-platform UI, or production-grade parallel execution.

## Sub-Spec roadmap

| ID | Sub-Spec | Outcome |
|---|---|---|
| M01-SS01 | Solution and Dependency Boundaries | Reproducible solution with enforced project boundaries and composition root |
| M01-SS02 | Domain Contracts and Capability Registry | Versioned contracts, `DataPacket`, Step capabilities, and validation interfaces |
| M01-SS03 | Configuration and Environment Management | Versioned configuration schemas, overlays, precedence, validation, and secret injection |
| M01-SS04 | Persistence Foundation and Migrations | PostgreSQL schema, migrations, repositories, versioning, snapshots, and recovery metadata |
| M01-SS05 | Execution and Observability Foundation | DAG validation/execution, rollback/compensation, resilience, events, metrics, and diagnostics |
| M01-SS06 | End-to-End Vertical Slice and Quality Gates | Windows Forms to PostgreSQL slice with full resilience matrix and evidence |

## Architecture

```text
PipelineOrchestrator.UI
        ↓ depends on Core
PipelineOrchestrator.Core
        ↑ implemented by Data
PipelineOrchestrator.Data
        ↓
PostgreSQL
```

The UI uses Windows Forms Designer and a composition root. Core owns domain interfaces and business invariants. Data implements persistence abstractions and SQL/Npgsql concerns. No UI view or code-behind accesses concrete repositories directly.

## Core contracts

M01 establishes versioned contracts for `Pipeline`, `Step`, `StepCommand`, `DataPacket`, `StepContract`, `ExecutionRun`, `StepLog`, `IProgressReporter`, `IRollbackPolicy`, retry policy, capability registration, configuration, sensitivity, and diagnostics.

## Persistence

M01 persists Pipeline versions, definition hashes, contracts, execution runs, step transitions, redacted snapshots, idempotency keys, recovery state, and duration metadata. Persistence is incremental and recoverable.

## Vertical slice

The slice is a complete desktop path:

1. Windows Forms creates or loads a Pipeline.
2. Core validates the DAG, contracts, configuration, resources, and security policy.
3. `PipelineBuilder` constructs registered Step commands.
4. `PipelineRunner` executes a sequential topological traversal.
5. `ProgressReporter` publishes step events; the UI Timer refreshes aggregate state every 500 ms.
6. Data persists `ExecutionRun` and `StepLog` records incrementally.
7. Failure triggers LIFO rollback/compensation and records evidence.
8. Recovery/reconciliation handles an interrupted execution.

The catalog includes `FileSource`, `PostgresSource`, `FilterTransform`, `MapTransform`, `FileSink`, and `PostgresSink`, all behind extensible contracts.

## Required resilience scenarios

- Valid successful execution
- Invalid contract
- Cyclic DAG
- Invalid configuration
- Missing credential
- Unavailable source
- Transform failure
- Sink failure
- Successful rollback
- Failed rollback
- Cancellation
- Timeout
- Retryable error
- Non-retryable error
- Abandoned execution
- Recovery/reconciliation
- Redacted snapshot
- Configuration conflict

## Definition of Ready

- Parent Spec contract is complete.
- Six Sub-Spec boundaries and dependencies are documented.
- ADRs and CONTEXT vocabulary are linked.
- Required Project metadata is assigned.
- Risks, security, testing, documentation, and evidence plans are explicit.
- No unresolved architecture conflict blocks decomposition.

## Definition of Done

- All six Sub-Specs satisfy their DoD.
- Required Tickets are closed with evidence.
- Solution builds reproducibly.
- Contracts, schemas, and migrations validate.
- Vertical slice passes the complete resilience matrix.
- UI/Core/Data dependency boundaries are verified.
- Quality gates, security checks, documentation, and traceability pass.
- GitHub Project metadata and native relationships are synchronized.
- Release note and rollback plan exist.
- No hidden dependencies, unresolved conflicts, or expired exceptions remain.

## Acceptance criteria

1. A developer can clone the repository, configure the documented environment, and build the solution.
2. The UI can create/load and execute a versioned pipeline using the M01 catalog.
3. The execution engine validates the DAG and contracts before side effects.
4. `ExecutionRun` and `StepLog` records are incrementally persisted and recoverable.
5. Step events and aggregate state are visible in the UI.
6. Failure, rollback, cancellation, timeout, retries, and abandoned-run recovery are evidenced.
7. Secrets and sensitive payloads are not persisted or exposed.
8. All required quality gates and documentation checks pass.

## Evidence expected

- Build and dependency graph output
- Contract/schema validation output
- Migration and PostgreSQL integration results
- Unit, integration, contract, and resilience test results
- UI smoke-test evidence
- Security and secret-scan evidence
- Observability/diagnostic export
- Architecture diagrams and ADR links
- GitHub Project metadata and relationship reconciliation report
- Release note and rollback plan
