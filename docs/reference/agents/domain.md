# Domain Docs

How the engineering skills should consume this repo's domain documentation when exploring the codebase.

## Before exploring, read these

- **`CONTEXT.md`** at the repo root, or
- **`CONTEXT-MAP.md`** at the repo root if it exists — it points at one `CONTEXT.md` per context. Read each one relevant to the topic.
- **`docs/adr/`** — read ADRs that touch the area you're about to work in. In multi-context repos, also check `src/<context>/docs/adr/` for context-scoped decisions.

If any of these files don't exist, **proceed silently**. Don't flag their absence; don't suggest creating them upfront. The `/domain-modeling` skill (reached via `/grill-with-docs` and `/codebase-design`) creates them lazily when terms or decisions actually get resolved.

## Weaverxyz domain

Weaverxyz is a desktop Data Pipeline Orchestrator in C#/.NET 8 with a four-layer architecture:

```
Presentation (Windows Forms)
    ↓
Business Logic (POO + design patterns)
    ↓
Execution Engine (orchestration + error handling)
    ↓
Persistence (PostgreSQL + Npgsql + Repository)
```

Key domain concepts — use these exact terms in issue titles, refactor proposals, hypotheses, and test names (defined in `CONTEXT.md`):

- `Pipeline`, `Step`, `StepCommand`, `PipelineBuilder`, `PipelineRunner`, `StepExecutor`, `ErrorHandler`, `ProgressReporter`, `AgentConnector`, `TransformStrategy`, `ExecutionRun`, `StepLog`, `StepConfig`, `DataSource`, `Sink`.

Project layout (Visual Studio solution):

```
PipelineOrchestrator.sln
├── PipelineOrchestrator.UI      — Windows Forms views and events
├── PipelineOrchestrator.Core    — domain classes, design patterns, business logic
└── PipelineOrchestrator.Data    — repositories, Postgres connection, SQL queries
```

Design patterns and their primary classes:

| Pattern | Primary classes | Reason |
|---|---|---|
| Command | `StepCommand`, `AgentCallCommand` | Encapsulates each step as an executable object with `Execute()` and `Rollback()`. |
| Composite | `Pipeline` contains a list of `PipelineStep` | A pipeline can contain sub-pipelines. |
| Builder | `PipelineBuilder` | Builds the step graph from the definition stored in the database. |
| Observer | `ProgressReporter` notifies the UI | Decouples the execution engine from the presentation layer. |
| Repository | `PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository` | Abstracts access to PostgreSQL. |
| Strategy | `ITransformStrategy` + concrete implementations | Swaps transformation algorithms without changing the executor. |

## File structure

Single-context repo (most repos):

```
/├── CONTEXT.md
├── docs/adr/
│   ├── 0001-event-sourced-orders.md
│   └── 0002-postgres-for-write-model.md
└── src/
```

Multi-context repo (presence of `CONTEXT-MAP.md` at the root):

```
/├── CONTEXT-MAP.md
├── docs/adr/                          ← system-wide decisions
└── src/
    ├── ordering/
    │   ├── CONTEXT.md
    │   └── docs/adr/                  ← context-specific decisions
    └── billing/
        ├── CONTEXT.md
        └── docs/adr/
```

## Use the glossary's vocabulary

When your output names a domain concept (in an issue title, a refactor proposal, a hypothesis, a test name), use the term as defined in `CONTEXT.md`. Don't drift to synonyms the glossary explicitly avoids.

If the concept you need isn't in the glossary yet, that's a signal — either you're inventing language the project doesn't use (reconsider) or there's a real gap (note it for `/domain-modeling`).

## Flag ADR conflicts

If your output contradicts an existing ADR, surface it explicitly rather than silently overriding:

> _Contradicts ADR-0007 (event-sourced orders) — but worth reopening because…_
