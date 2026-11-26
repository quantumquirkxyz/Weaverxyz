# [Parent Spec][M02] Domain Model and Contracts

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Feature
- **Milestone:** M02 — Domain Model and Contracts
- **Semantic ID:** M02
- **Owner:** `quantumquirkxyz`
- **Phase:** Requirements → Architecture → Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** High
- **Repo Scope:** `PipelineOrchestrator.Core`
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m02-domain-model-contracts-v1`

## Objective

Extend the M01 foundation with the complete functional domain model and governed contracts required to represent, validate, evolve, and reproduce Weaverxyz Pipelines and capabilities without coupling the execution engine to concrete Step types.

## Boundary with M01

M01 establishes solution boundaries, foundational contracts, configuration, persistence, execution seams, and the first vertical slice. M02 defines the functional domain vocabulary and executable contract system consumed by later connector, transformation, UI, persistence, and execution milestones. M02 must not duplicate M01 infrastructure or silently change its approved boundaries.

## Scope

- Versioned immutable Pipeline DAGs and subpipelines.
- Governed Step capability contracts.
- Polymorphic tabular/document DataPacket envelopes.
- C# and JSON Schema contract alignment.
- Capability Registry with historical resolution.
- Typed results, errors, and immutable domain events.
- Compatibility, adapters, migrations, deprecation, and breaking-change governance.
- Sensitivity, redaction, lineage, idempotency, compensation, and operational policies.
- Executable invariants and complete domain verification.

## Domain contracts

Every Pipeline and Step has stable identity, version, metadata, definition/content hash, schema references, compatibility data, and traceability. Every Step declares capability, implementation and contract versions, input/output schemas, configuration, security, sensitivity, redaction, reversibility, compensation, idempotency, retry, timeout, resource, observability, and lineage policies.

`DataPacket` supports tabular and document payloads and carries schema/version, packet and correlation identity, origin, producer, timestamp, size/row limits, sensitivity, redaction metadata, content hash, lineage, and cancellation context. Secrets are prohibited.

## Pipeline model

A Pipeline is an immutable, versioned DAG with typed nodes and edges, reachability and acyclicity invariants, topological validity, compatible edge contracts, subpipeline boundaries, authoring metadata, changelog, definition hash, and historical reproduction rules.

## Capability Registry

Capabilities are registered through typed factories and metadata rather than a central executor switch. Registry entries include implementation and contract versions, schemas, configuration requirements, security policies, reversibility, compensation, retry/idempotency rules, resource limits, observability, deprecation state, and historical resolution data.

## Errors and events

Expected outcomes use `Result<T>`. Errors have stable code, category, severity, retryability, causal chain, correlation IDs, compensation requirement, safe UI message, redacted technical detail, and StepLog serialization. Domain events are immutable and versioned, with identity, causal relationship, execution/pipeline/Step references, state transition, timestamps, metrics, sensitivity, lineage, retry, and compensation metadata.

## Compatibility governance

Contracts use semantic versioning, backward/forward compatibility matrices, adapters, migrations, deprecation windows, compatibility tests, and explicit breaking-change review. Incompatible changes require an ADR, approval, migration plan, and historical reproduction assessment.

## Security and trust

Sensitivity classification and redaction are part of the contract. Domain serialization, diagnostics, events, and test fixtures must not expose secrets. Security-relevant policies fail closed when absent, ambiguous, incompatible, or invalid.

## Dependencies and roadmap

- M01 acceptance and contract baseline.
- M03 consumes Pipeline definition and versioning contracts.
- M04 consumes capability and connector contracts.
- M05 consumes DataPacket, transform, validator, and compatibility contracts.
- M06 consumes execution policy, error, event, idempotency, and compensation contracts.
- M07 consumes domain validation and event contracts for UI behavior.
- M08 consumes persistence serialization and schema contracts.
- M09 consumes AgentCall capability, security, and redaction contracts.

## Definition of Ready

- M01 contracts and boundary decisions are accepted.
- Domain vocabulary and M02/M01 ownership boundaries are documented.
- Contract owners, compatibility policy, registry categories, security rules, dependencies, and evidence destinations are assigned.
- No unresolved domain conflict blocks decomposition.

## Definition of Done

- Versioned immutable Pipeline DAG and subpipeline contracts exist.
- Step, DataPacket, policy, lineage, compatibility, sensitivity, and redaction contracts exist.
- C# contracts and JSON Schemas validate aligned representative values.
- Capability Registry resolves extensible and historical implementations without a central type switch.
- Results, errors, and events are typed, immutable, correlated, safe, and versioned.
- Compatibility, adapters, migrations, deprecation, and breaking-change governance are documented and tested.
- Unit, property-based, contract, compatibility, registry, serialization, negative, redaction, fuzzing, idempotency, compensation, and event tests pass.
- ADRs, documentation, Project metadata, and evidence report are synchronized.

## Acceptance criteria

1. A Pipeline can be represented as a versioned immutable DAG with valid subpipeline boundaries.
2. Invalid cycles, unreachable nodes, incompatible edges, and missing policies fail before execution.
3. A Step declares complete capability, contract, security, resilience, resource, and observability metadata.
4. DataPacket supports tabular and document data with schema, lineage, sensitivity, redaction, and content hash.
5. C# and JSON Schema validation agree for positive and negative fixtures.
6. New capabilities can be registered and resolved without modifying the executor's central logic.
7. Historical capability and contract versions can be resolved for reproduction.
8. Contract evolution detects breaking changes and requires governed migration/deprecation evidence.
9. Errors and events are typed, immutable, correlated, versioned, and safe for persistence/UI consumers.
10. Property-based, compatibility, serialization, fuzzing, redaction, idempotency, compensation, and negative tests pass.

## Expected evidence

- Domain model and contract diagrams
- C# contract and JSON Schema manifest
- Registry discovery and historical resolution report
- DAG invariant and negative-test output
- Compatibility and migration matrix
- Serialization, redaction, and fuzzing results
- Error/event schema and consumer tests
- ADR and documentation traceability
- Project reconciliation and evidence manifest
