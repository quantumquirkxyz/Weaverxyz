# ADR-001: Layered Four-Tier Architecture

## Status

Accepted

## Context

Weaverxyz is a desktop Data Pipeline Orchestrator built from scratch in C#/.NET 8. The system must coordinate the execution of ordered pipeline steps (DataSource, Transform, AgentCall, Sink) while keeping concerns separated so the project demonstrates non-trivial OOP and layered architecture — a quality criterion in Software Engineering evaluations.

The project serves two objectives simultaneously: (a) academic demonstration of Software Engineering principles, and (b) a functional desktop orchestrator that actually works. Without an explicit layering decision, the UI, business logic, orchestration engine, and data access would collapse into a single layer, making the system untestable, hard to maintain, and unable to demonstrate architectural separation.

## Decision

Adopt a four-tier layered architecture with strictly ordered communication (each layer depends only on the layer below):

1. **Presentation layer** — Windows Forms / Visual Studio 2022 Community. Views and events only. Pipeline editor, live monitor, log viewer, configuration. Polls status every 500 ms via `Timer`; draws pipeline nodes with `Panel` + `Graphics`. UI updates use a hybrid model: `ProgressReporter` pushes step-level events via Observer, and Timer polls aggregate execution-level state every 500 ms.
2. **Business logic layer** — POO classes and design patterns (`PipelineBuilder`, `StepCommand`, `AgentConnector`, `TransformStrategy`). Pure domain logic, no UI or data-access references.
3. **Execution layer** — Orchestration, sequencing, and error handling (`PipelineRunner`, `StepExecutor`, `ErrorHandler`, `ProgressReporter`). Coordinates step execution but does not know about UI controls or SQL.
4. **Persistence layer** — PostgreSQL via Npgsql and the Repository pattern (`PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository`). Uses JSONB in `step_configs` and `step_logs`; Postgres triggers compute `duration_ms` on `finished_at`.

Communication flows top-down through the layers; no layer bypasses the layer immediately below it.

## Consequences

### Positive

- Separation of concerns: UI, orchestration, and data access can be reasoned about independently.
- Testability: Business logic and execution engine can be unit-tested without Windows Forms or a live Postgres instance.
- Maintainability: Changes to one layer (e.g., swapping the UI framework) do not cascade into other layers.
- Demonstrates layered architecture, a Software Engineering quality criterion.

### Negative / Trade-offs

- Additional abstraction layers add indirection and a small amount of boilerplate.
- Strict layering means the presentation layer cannot directly query the database; it must go through the execution engine and repositories.
- Requires discipline to prevent layer violations during implementation.

## Alternatives Considered

- **Clean Architecture / Onion Architecture**: Rejected as over-engineering for a desktop demonstrator; four tiers provide sufficient separation without the complexity of use-case/interactor layers.
- **Single-layer monolith**: Rejected — violates separation of concerns and fails the Software Engineering evaluation criterion for layered architecture.
- **Three-tier (UI → Business → Data)**: Rejected — the execution engine (orchestration, sequencing, error handling) is a distinct concern that deserves its own layer between business logic and persistence.

## References

- `CONTEXT.md` — Local vocabulary: `PipelineRunner`, `StepExecutor`, `ErrorHandler`, `ProgressReporter`, `PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository`, `AgentConnector`, `TransformStrategy`.
- `docs/reference/agents/domain.md` — Domain doc consumer rules and layer diagram.
