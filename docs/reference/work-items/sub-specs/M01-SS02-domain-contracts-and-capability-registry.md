# [Sub-Spec][M01-SS02] Domain Contracts and Capability Registry

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS02
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Design → Implementation → Verification
- **Status:** Triage
- **Priority:** Critical
- **Risk:** High
- **Area:** Core
- **Repo Scope:** `PipelineOrchestrator.Core`
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss02-domain-contracts-v1`

## Capability and outcome

Establish the extensible, versioned domain kernel that defines Pipelines, Steps, DataPackets, contracts, errors, events, capabilities, resilience policies, sensitivity, compensation, and compatibility rules. Later milestones must be able to add capabilities without modifying the central `steps` schema or turning `StepExecutor` into a switch statement.

## Scope

- Define `Pipeline` as a versioned Composite containing Step nodes and dependency edges.
- Enforce DAG identity, reachability, acyclicity, topological validity, version, metadata, and definition hash.
- Define `Step` as a capability contract with stable identity, type, capability, implementation version, contract version, schemas, reversibility, compensation, idempotency, retry policy, operational limits, sensitivity, and observability metadata.
- Define polymorphic `DataPacket` for tabular and document data.
- Define dual contracts: C# types for compile-time execution and versioned JSON Schema for runtime/persistence/integration validation.
- Define `StepCommand` with mandatory `Execute()` and `Rollback()`.
- Define structured `Result<T>` and domain errors.
- Define versioned immutable progress/domain events.
- Define capability registry and registration metadata.
- Register initial categories and capabilities.
- Define schema compatibility, semantic versioning, migration, adapter, and deprecation rules.
- Define sensitivity classification and redaction metadata.
- Define idempotency and compensation contracts.

## Domain model

### Pipeline

`Pipeline` is a Composite and immutable versioned definition containing Step nodes, dependency edges, contracts, metadata, schema version, author, timestamp, changelog, and definition hash. It must be acyclic and reachable according to validation rules.

### Step

Each Step declares:

- stable `stepId`;
- `stepType` and capability category;
- implementation version;
- contract version;
- input and output schemas;
- reversibility level;
- compensation action and evidence;
- idempotency strategy;
- retry/timeout policy;
- resource limits;
- sensitivity classification;
- observability metadata.

### DataPacket

`DataPacket` is the transport envelope for tabular and document values. It includes `packetId`, `correlationId`, payload, schema, schema version, origin, producer Step, timestamp, size/row count, sensitivity, redaction metadata, content hash, lineage, cancellation context, and transport limits.

### Results and errors

Expected outcomes use `Result<T>`. Structured domain errors include code, category, severity, retryability, causal chain, correlation IDs, compensation requirement, safe UI message, and serializable StepLog representation. Exceptions are reserved for unexpected technical failures.

## Capability Registry

Each capability registers metadata, version, contracts, policies, security requirements, reversibility, compensation, retry behavior, resource limits, and a factory for its StepCommand. `StepExecutor` resolves capabilities through the registry and does not contain a central type switch.

Initial categories and capabilities:

- Sources: `FileSource`, `PostgresSource`, `HttpSource`.
- Transforms: `FilterTransform`, `MapTransform`, `TypeConversionTransform`, `AggregateTransform`, `JoinTransform`.
- Validators: `SchemaValidator`, `QualityValidator`, `SecurityPolicyValidator`.
- Enrichment: `AgentCall`.
- Sinks: `FileSink`, `PostgresSink`, `ReportSink`.
- Control flow: `SubPipeline`.

## Versioning and compatibility

A Pipeline fixes capability, implementation version, and contract version. The registry retains retired versions needed to reproduce historical runs. Contract evolution uses semantic versioning, backward/forward compatibility rules, adapters, migrations, deprecation windows, compatibility tests, and a breaking-change matrix. Incompatible changes require an ADR and explicit approval.

## Validation invariants

- IDs and versions are present and stable.
- DAG is acyclic, reachable, and topologically valid.
- Every capability is registered and compatible.
- Input/output schemas are compatible across edges.
- Security, sensitivity, redaction, reversibility, compensation, idempotency, retry, timeout, and resource policies are complete.
- Configuration references are resolvable.
- SubPipeline boundaries do not create cycles or invalid contract edges.

## Events

`IProgressReporter` publishes immutable versioned events containing `eventId`, `eventType`, `schemaVersion`, `correlationId`, `executionId`, `pipelineVersionId`, `stepId`, prior/new state, timestamps, metrics, redaction metadata, and causal relationship. UI, persistence, metrics, and diagnostics consume the same contract.

## Definition of Ready

- Parent Spec and M01-SS02 boundary are accepted.
- Domain vocabulary is aligned with `CONTEXT.md`.
- Contract ownership, compatibility policy, registry categories, security rules, and test strategy are explicit.
- Required Project metadata and dependencies are assigned.
- No unresolved domain boundary conflict blocks implementation.

## Definition of Done

- C# contracts and JSON Schemas are versioned.
- Pipeline DAG, Step, DataPacket, Result/error, event, resilience, sensitivity, idempotency, and compensation contracts exist.
- Capability Registry is extensible and all initial capabilities are registered.
- Full validation invariants are executable.
- Compatibility, migration, adapter, deprecation, and breaking-change rules are documented.
- Positive, negative, property-based, compatibility, registry, serialization, redaction, idempotency, compensation, error, and event tests pass.
- ADRs, CONTEXT, diagrams, documentation index, Project metadata, and evidence report are synchronized.
- Evidence is published in the native GitHub Sub-Spec Issue when created.

## Acceptance criteria

1. A Pipeline can represent a versioned acyclic graph with SubPipelines.
2. A Step declares capability, implementation, contract, policy, and observability metadata.
3. A DataPacket supports tabular and document payloads with lineage and sensitivity metadata.
4. C# and JSON Schema contracts validate the same representative values.
5. A new registered capability can be resolved without modifying `StepExecutor`.
6. Registry version resolution reproduces a historical implementation and contract.
7. Invalid graphs, incompatible schemas, missing policies, and unregistered capabilities fail before execution.
8. Domain errors are typed, classified, correlated, and safe for UI/log serialization.
9. Progress events are immutable, versioned, and consumable by multiple observers.
10. Contract, property-based, compatibility, negative, redaction, idempotency, and compensation tests pass.

## Expected evidence

- Domain model and contract diagrams
- C# contract and JSON Schema files
- Registry discovery and version-resolution reports
- Validation negative-test output
- Property-based invariant results
- Compatibility/migration matrix
- Event schema and consumer test results
- Redaction/sensitivity test evidence
- Documentation, ADR, and Project traceability links
