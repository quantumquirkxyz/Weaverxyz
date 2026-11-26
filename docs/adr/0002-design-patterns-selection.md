# ADR-002: Design Patterns — Command, Composite, Builder, Observer, Repository, Strategy

## Status

Accepted

## Context

Weaverxyz must demonstrate fundamental OOP design patterns applied naturally because the domain demands them, not because an instructor requires them. The pipeline domain (ordered steps, nested pipelines, step execution with rollback, UI notifications, data-access abstraction, swappable transformations) maps directly to specific patterns.

The project serves two objectives: academic demonstration and functional desktop orchestrator. Without a documented pattern selection, the codebase risks inconsistent pattern usage, ad-hoc solutions, and an inability to justify pattern choices during Software Engineering evaluation.

## Decision

Apply six design patterns, each mapped to a primary class and a domain-driven reason:

| Pattern | Primary classes | Domain reason |
|---|---|---|
| Command | `StepCommand`, `AgentCallCommand` | Encapsulates each pipeline step as an executable object with `Execute()` and `Rollback()`. **Rollback is mandatory for every step.** Steps are uniform, composable, and undoable. |
| Composite | `Pipeline` contains a list of `PipelineStep` | A pipeline can contain sub-pipelines; the tree structure lets the executor treat single steps and pipelines uniformly. |
| Builder | `PipelineBuilder` | Builds the step graph from the database-stored definition, separating construction from representation. Supports an open set of step types. |
| Observer | `ProgressReporter` notifies the UI | Decouples the execution engine from the presentation layer; the UI subscribes to progress events without the engine knowing about Windows Forms. |
| Repository | `PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository` | Abstracts PostgreSQL access behind collection-like interfaces; the domain does not depend on SQL or Npgsql directly. |
| Strategy | `ITransformStrategy` + concrete implementations | Swaps data-transformation algorithms (filter rows, change column types, calculate fields, call AI agent) without changing the step executor. |

## Step execution semantics

- Every `StepCommand` implements `Execute()` and `Rollback()`. Rollback is mandatory, not optional.
- When a step fails, `ErrorHandler.Handle()` rolls back **all previously completed steps in reverse order (LIFO)**, then stops execution and logs the error.
- Step types are an open set: new types can be added by implementing new `StepCommand` subclasses without modifying the `steps` table schema.

## Consequences

### Positive

- Each pattern solves a domain problem that arises naturally in a pipeline orchestrator.
- Command + Composite enable uniform step execution and rollback.
- Observer enables real-time UI updates without coupling the engine to Windows Forms.
- Repository enables unit testing of business logic with in-memory repositories.
- Strategy enables adding new transformation types without modifying the executor (Open/Closed Principle).

### Negative / Trade-offs

- Pattern indirection adds boilerplate and a learning curve for new contributors.
- The Composite pattern requires careful handling of recursive pipeline structures to avoid infinite loops.
- Strategy requires defining a stable `ITransformStrategy` interface upfront.
- Mandatory rollback requires every step to define a meaningful undo operation, even for steps with side effects that cannot be fully reversed.

## Alternatives Considered

- **No patterns, procedural code**: Rejected — fails to demonstrate OOP and does not meet the Software Engineering evaluation criterion for design pattern application.
- **MVVM / MVC**: Rejected — these are UI patterns, not domain patterns; they do not address step encapsulation, pipeline composition, or data-access abstraction.
- **Dependency Injection container**: Deferred — for a desktop demonstrator, manual composition in `PipelineBuilder` is sufficient; a DI container can be introduced in a follow-up if the graph grows.

## References

- `CONTEXT.md` — Local vocabulary for all pattern classes listed above.
- `docs/reference/agents/domain.md` — Design patterns table with pattern, class, and reason.
