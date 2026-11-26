# ADR-003: Technology Stack — C# 12, .NET 8, Windows Forms, PostgreSQL, Npgsql

## Status

Accepted

## Context

Weaverxyz is a desktop Data Pipeline Orchestrator built from scratch to demonstrate orchestration principles and OOP design patterns. The technology stack must support: (a) a desktop GUI with real-time status updates, editable in Visual Studio designer, (b) a PostgreSQL persistence layer with JSONB for flexible step configuration, (c) C# 12 language features for modern OOP, and (d) a Visual Studio 2022 Community development experience accessible for academic evaluation.

Without a pinned stack, dependency drift and inconsistent tooling would undermine reproducibility and evaluation.

## Decision

Adopt the following stack:

| Component | Choice | Rationale |
|---|---|---|
| Language | C# 12 | Modern OOP features, primary constructors, collection expressions, strongly aligned with .NET 8. |
| Framework | .NET 8 | LTS support, cross-platform, strong Windows Forms support on Windows. |
| GUI | Windows Forms | Native desktop UI, editable in Visual Studio 2022 designer. `Panel` + `Graphics` for pipeline node drawing, `Timer` for 500 ms polling, `RichTextBox` for colored logs, `TabControl` for design/execution views, `DataGridView` for execution history. Hybrid updates: `ProgressReporter` pushes step-level events; Timer polls aggregate state every 500 ms. |
| IDE | Visual Studio 2022 Community | Free, full .NET 8 support, Windows Forms designer, accessible for academic use. |
| Database | PostgreSQL | Robust open-source RDBMS, JSONB support for flexible `step_configs` and `step_logs`, triggers for `duration_ms` computation. |
| Data access | Npgsql | Official PostgreSQL driver for .NET, installed via NuGet (`Install-Package Npgsql`). |
| Solution structure | 3 projects | `PipelineOrchestrator.UI` (views + events), `PipelineOrchestrator.Core` (domain + patterns), `PipelineOrchestrator.Data` (repositories + SQL). |

## Consequences

### Positive

- .NET 8 LTS provides long-term support and stability.
- Windows Forms delivers the required desktop GUI capabilities (live updates, status colors, visual graphs) and is editable in Visual Studio designer.
- PostgreSQL JSONB allows flexible per-step configuration without rigid schemas — matching real-world pipeline variability.
- Three-project separation enforces layer boundaries at the assembly level.
- Npgsql is the official, well-maintained PostgreSQL driver for .NET.

### Negative / Trade-offs

- Windows Forms is Windows-only; the desktop GUI does not run on Linux/macOS without a compatibility layer.
- .NET 8 requires a modern runtime; older environments cannot run the application.
- Three projects add solution complexity compared to a single project, but enforce architectural boundaries.

## Alternatives Considered

- **WPF / Avalonia**: Rejected — Windows Forms is simpler, more accessible for academic evaluation, and sufficient for the required UI controls. Also editable in Visual Studio designer.
- **SQL Server / SQLite**: Rejected — PostgreSQL was chosen for JSONB support and its prevalence in production data pipelines.
- **Entity Framework Core**: Deferred — the Repository pattern with raw SQL via Npgsql keeps data access explicit and testable; EF can be introduced later if schema complexity grows.

## References

- `CONTEXT.md` — Stack section: C# 12, .NET 8, Visual Studio 2022, Windows Forms, PostgreSQL, Npgsql.
- `docs/reference/agents/domain.md` — Layer descriptions and repository class names.
