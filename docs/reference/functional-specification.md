# Weaverxyz Functional Specification

## Product intent

Weaverxyz is a desktop Data Pipeline Orchestrator for two equal audiences: a student/developer who learns and extends the architecture, and a technical operator who designs, executes, monitors, diagnoses, and compares pipelines through Windows Forms.

## Primary user journey

1. Create or open a Pipeline.
2. Add capability-based Steps in the visual editor.
3. Configure source, transformation, validation, AgentCall, sink, or SubPipeline behavior.
4. Validate the DAG, contracts, configuration, resources, security, and dependencies.
5. Save an immutable Pipeline version with schema version, author, timestamp, changelog, and definition hash.
6. Execute the selected version.
7. Observe push events and 500 ms aggregate refreshes.
8. Inspect redacted StepLogs, metrics, snapshots, rollback, and errors.
9. Compare executions and export diagnostics.
10. Modify the Pipeline and repeat.

## Capability catalog

- **Sources:** `FileSource`, `PostgresSource`, `HttpSource`.
- **Transforms:** filter, map, type conversion, aggregate, join, and custom strategies.
- **Validators:** schema, quality, business-rule, and security-policy validation.
- **Enrichment:** `AgentCall` and future external enrichers.
- **Sinks:** `FileSink`, `PostgresSink`, `ReportSink`.
- **Control flow:** `SubPipeline` and future policy-controlled parallel branches.

New capabilities use common contracts and registration; they do not require changing the core `steps` schema.

## Functional invariants

- The pipeline graph is acyclic.
- Every Step has versioned input/output contracts.
- Every StepCommand has `Execute()` and `Rollback()`.
- Failed execution stops after LIFO rollback/compensation.
- Every ExecutionRun references one immutable Pipeline version and hash.
- Secrets never enter Pipeline configuration, source control, or StepLog payloads.
- Payload snapshots are classified, minimized, redacted, and retained by policy.
