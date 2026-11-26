# ADR-007: DAG Execution and Versioned Data Contracts

## Status

Accepted

## Context

Weaverxyz must support a complete MVP with sources, transformations, AgentCall, sinks, subpipelines, history, metrics, and multi-environment configuration. A flat ordered list cannot represent explicit dependencies, subpipelines, or future parallelism safely.

## Decision

The canonical pipeline model is a directed acyclic graph (DAG). Sequential execution is the initial execution strategy and is a valid topological traversal of the DAG. Future parallel execution may run independent nodes when resource, ordering, idempotency, and security policies permit it.

Every Step declares versioned input and output contracts. `PipelineBuilder` and preflight validation verify graph acyclicity, reachability, contract compatibility, configuration, credentials, permissions, connector availability, resource budgets, and security policy before execution.

Data moves through a polymorphic `DataPacket` that supports tabular and document data and carries schema version, origin, size, sensitivity, correlation, and redaction metadata.

## Consequences

- The domain supports future parallelism without changing the fundamental model.
- Contract validation prevents incompatible pipelines from starting.
- Acyclicity and topological order become explicit invariants.
- `DataPacket` requires runtime validation and size/sensitivity controls.
