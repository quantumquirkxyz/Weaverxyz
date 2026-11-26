# Weaverxyz Context

## Repository

- **Name:** Weaverxyz
- **Purpose:** Weaverxyz is a desktop Data Pipeline Orchestrator built from scratch in C#/.NET 8. It demonstrates core orchestration principles (scheduling, sequencing, error handling, observability) and applies fundamental OOP design patterns — Command, Composite, Builder, Observer, Repository, Strategy — naturally demanded by the domain. The project serves two objectives: academic demonstration of Software Engineering principles, and a functional desktop orchestrator that actually works.
- **Skills bundle:** `.agents/skills/` is canonical; `.claude/skills/` is the compatibility view.

## Solution structure

```
PipelineOrchestrator.sln
├── PipelineOrchestrator.UI   — Windows Forms (views + events only), editable in Visual Studio designer
├── PipelineOrchestrator.Core — domain classes, design patterns, business logic
└── PipelineOrchestrator.Data — repositories, Postgres connection, SQL queries
```

**Dependency direction:** `UI → Core → Data`. `Core` defines repository interfaces; `Data` implements them. `UI` depends only on `Core` and resolves repository implementations at runtime (Dependency Inversion).

## Local vocabulary

Use these terms exactly as defined; do not drift to synonyms.

| Term | Meaning |
|---|---|
| `Pipeline` | Ordered sequence of steps from source to sink. May contain sub-pipelines (Composite). |
| `Step` | One unit of work in a pipeline (DataSource / Transform / AgentCall / Sink). Open set of types. |
| `StepCommand` | Command-pattern object encapsulating a step with `Execute()` and `Rollback()`. Rollback is mandatory for every step. |
| `PipelineBuilder` | Builds the step graph from the definition stored in the database. |
| `PipelineRunner` | Orchestrator engine: loads definition, instantiates commands, runs them in sequence. |
| `StepExecutor` | Runs a single step; dispatches by `step_type`. |
| `ErrorHandler` | Handles step failure: rolls back all completed steps in reverse order (LIFO), then stops and logs the error. |
| `ProgressReporter` | Observer that notifies the UI of step status in real time. |
| `AgentConnector` | HTTP client that calls an external AI agent via `HttpClient` (Claude, Hermes/OpenClaw, or any REST endpoint). |
| `TransformStrategy` | Strategy for data-transformation algorithms, swappable without changing the executor. |
| `ExecutionRun` | One execution of a pipeline; persisted in Postgres with status, timestamps, `duration_ms`. |
| `StepLog` | Detailed log of one step within one execution run (input/output snapshots as JSONB). |
| `StepConfig` | Configuration of one step (JSONB), agnostic to the agent/backend. Credentials never stored here. |
| `DataSource` | Origin of data (CSV file, Postgres table, URL). |
| `Sink` | Destination of data (Postgres table, output file, report). |

## Layers

1. **Presentation layer** — Windows Forms / Visual Studio 2022 Community. Pipeline editor, live monitor, log viewer, configuration. Hybrid updates: `ProgressReporter` pushes step-level events via Observer; `Timer` polls aggregate state every 500 ms.
2. **Business logic layer** — POO classes and design patterns (`PipelineBuilder`, `StepCommand`, `AgentConnector`, `TransformStrategy`). Pure domain logic, no UI or data-access references.
3. **Execution layer** — Orchestration, sequencing, and error handling (`PipelineRunner`, `StepExecutor`, `ErrorHandler`, `ProgressReporter`).
4. **Persistence layer** — PostgreSQL via Npgsql and the Repository pattern. JSONB in `step_configs` and `step_logs`; Postgres triggers compute `duration_ms` on `finished_at`.

## AI Agents

The `AgentCall` step type represents a call to an external AI agent. `StepExecutor` issues an HTTP request via `HttpClient` to the agent's REST API (Anthropic Claude, a local agent such as Hermes/OpenClaw on `localhost`, or any JSON-in/JSON-out endpoint). Agent configuration (endpoint URL, model, prompt template, parameters) lives in the `config` JSONB column of `step_configs`. API keys and tokens are stored outside the application in a `.env` file (excluded from git) or another secret store, injected at runtime. The orchestrator is agent-agnostic.

## Persistence

Five tables: `pipelines`, `steps`, `step_configs`, `execution_runs`, `step_logs`. Common fields are typed; step-specific configuration lives in JSONB. Repository interfaces are defined in `Core` and implemented in `Data`.

## Testing strategy

- Unit tests for `Core` (in-memory/mock repositories, no Postgres required).
- Integration tests for `Data` (real PostgreSQL instance).
- Manual UI tests (Windows Forms).

## Working conventions

- Read `.agents/AGENTS.md` and the relevant skill before using a workflow.
- Use `docs/reference/agents/` for agent workflow and work-item guidance.
- Record architectural decisions under `docs/reference/adr/` when the project establishes them.
- Validate the bundle with the commands in `docs/how-to/adoption.md`.
- Apply Software Engineering principles: modularity, separation of concerns, testability, maintainability, traceability, Dependency Inversion, Open/Closed Principle.

## GitHub Project governance

Weaverxyz uses one repository-level GitHub Project V2. The versioned configuration is `.github/project/project-manifest.yml`; field authority is defined in `.github/project/authority-matrix.yml`. Project V2 is authoritative for planning fields, issues and pull requests for requirements/evidence/relationships, and labels for routing compatibility.

The Project includes normalized fields for status, work type, type, priority, risk, area, repository scope, phase, effort, owner, reviewer, QA state, security state, documentation state, dependency state, iteration, release train, milestone, start date, target date, and completed date. It uses governed Intake, Ready, Execution, Review/QA, Roadmap, Release, Security, Documentation Debt, and Completed views.

Routine synchronization is automated by `.github/workflows/project-governance.yml`. Configuration mutations require inventory, dry-run, human approval, idempotent application, audit evidence, health checks, and rollback readiness. Conflicts fail closed.

## Documentation governance

All repository documentation is written in English. `README.md` serves onboarding; `docs/how-to/` contains procedures; `docs/reference/` contains contracts and governance; `docs/theory/` contains technical theory; `docs/adr/` contains durable decisions; `docs/runbooks/` contains operations; and `docs/architecture/` contains diagram-as-code sources. Ownership is role-based, with `quantumquirkxyz` as the initial operational owner and backup.

## Product objectives and scope

Weaverxyz is a hybrid system: it must be a functional desktop orchestrator and an academically defensible Software Engineering project. Architecture, traceability, and evidence take precedence over shortcuts when objectives conflict.

The MVP includes a Visual Studio-editable Windows Forms editor; capability-based sources, transforms, validators, AgentCall, sinks, and subpipelines; PostgreSQL persistence; immutable versioned DAG definitions; complete preflight validation; sequential topological execution; mandatory rollback/compensation; retry/resilience policies; recovery; live monitoring; structured logs; execution comparison; metrics; redacted snapshots; and multi-environment configuration.

The canonical Pipeline model is a DAG. Sequential execution is the initial strategy; future parallelism is allowed only for independent nodes that satisfy resource, ordering, idempotency, and security policies. Every Step declares versioned input/output contracts. Data travels in a polymorphic `DataPacket` supporting tabular and document data with schema, origin, size, sensitivity, correlation, and redaction metadata.

Every StepCommand implements `Execute()` and `Rollback()`. Each Step declares reversibility, compensation behavior, evidence, and residual risk. Non-compensable Steps require explicit approval. Retry policies use error classification, exponential backoff with jitter, idempotency keys, timeouts, circuit breakers, rate limits, and diagnostics. ExecutionRun persistence is incremental and references an immutable Pipeline version and definition hash.

The initial scope excludes multi-user collaboration, distributed or remote execution, high availability, external scheduling, queues/event buses, cloud deployment, and native cross-platform UI. Future inclusion requires new scope, ADR, risk analysis, Project metadata, and success criteria.

## Work item hierarchy

The roadmap is organized as one root Parent Spec per Milestone, with Sub-Specs as native GitHub sub-issues of the Parent Spec and Tickets as native GitHub sub-issues of each Sub-Spec:

```text
Milestone → Parent Spec → Sub-Spec → Ticket
```

The 10 initial milestones are defined in `docs/reference/work-items/hierarchy-governance.md`. Parent Specs are created first with contracts and roadmaps; each Parent Spec is refined before its Sub-Specs and Tickets are generated. Native GitHub relationships are authoritative, while semantic IDs and body metadata are validated redundantly.

All issue comments are written in English using `docs/reference/work-items/comment-contract.md`. Closure is descendant-aware: Tickets require evidence before closure, Sub-Specs require their required Tickets, and Parent Specs require their required Sub-Specs and milestone evidence.
