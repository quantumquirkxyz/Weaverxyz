# ADR-005: Data Persistence — PostgreSQL with JSONB, Repository Pattern, Duration Triggers

## Status

Accepted

## Context

Weaverxyz must persist pipeline definitions, step configurations, execution history, and detailed step logs. The persistence layer must support auditing, reproduction, and comparison of previous executions. Step configurations and input/output snapshots vary per step type, so rigid schemas are impractical.

## Decision

Adopt PostgreSQL with the following schema and access pattern:

- **Database**: PostgreSQL, accessed via Npgsql.
- **Schema** (5 tables):
  - `pipelines` — `id UUID PK`, `name VARCHAR`, `description TEXT`, `created_at TIMESTAMP`.
  - `steps` — `id UUID PK`, `pipeline_id UUID FK`, `step_order INT`, `step_type VARCHAR`, `name VARCHAR`.
  - `step_configs` — `id UUID PK`, `step_id UUID FK`, `config JSONB`, `version INT`. JSONB allows flexible per-step parameters.
  - `execution_runs` — `id UUID PK`, `pipeline_id UUID FK`, `status VARCHAR`, `started_at TIMESTAMP`, `duration_ms INT`, `triggered_by VARCHAR`.
  - `step_logs` — `id UUID PK`, `run_id UUID FK`, `step_id UUID FK`, `status VARCHAR`, `input_snapshot JSONB`, `output_snapshot JSONB`, `duration_ms INT`.
- **Relationships**: `pipelines` 1:N `steps`, `pipelines` 1:N `execution_runs`, `steps` 1:1 `step_configs`, `steps` 1:N `step_logs`, `execution_runs` 1:N `step_logs`.
- **Triggers**: A Postgres trigger automatically calculates `duration_ms` on `execution_runs` when `finished_at` is updated, so C# does not perform that arithmetic.
- **Access pattern**: Repository pattern — `PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository`. All SQL encapsulated; domain depends on repository interfaces, not on Npgsql directly.
- **Dependency direction**: `Core` defines repository interfaces; `Data` implements them. `UI` depends only on `Core`. `Core` does not depend on `Data`.

## Consequences

### Positive

- JSONB in `step_configs` and `step_logs` accommodates varying step parameters without schema changes.
- Native relationships and foreign keys ensure referential integrity.
- Triggers offload `duration_ms` calculation to the database, keeping C# code focused on orchestration.
- Repository pattern enables unit testing with in-memory implementations.
- Execution history supports auditing, reproduction, and comparison.
- Dependency Inversion keeps `Core` independent of `Data`, making the domain testable without a database.

### Negative / Trade-offs

- JSONB columns lose some type safety compared to strongly typed columns; validation must occur at the application boundary.
- Database triggers are implicit logic; they must be documented and version-controlled as part of schema migrations.
- A live PostgreSQL instance is required for integration tests; unit tests use mock repositories.

## Alternatives Considered

- **SQLite**: Rejected — limited JSONB support and less representative of production data pipeline environments.
- **SQL Server**: Rejected — PostgreSQL was selected for its open-source model and JSONB maturity.
- **Strongly typed config columns per step type**: Rejected — would require schema migration for every new step type; JSONB is more flexible for a pipeline system.

## References

- `CONTEXT.md` — Persistence layer section: `PipelineRepository`, `StepRepository`, `LogRepository`, `ExecutionRepository`, JSONB, duration_ms triggers.
- Diagram 3 (database schema) in the project documentation shows `pipelines`, `steps`, `step_configs`, `execution_runs`, `step_logs` with their relationships.
