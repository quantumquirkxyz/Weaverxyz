# CI Evidence — Weaverxyz

## Purpose

Describes the build and test evidence produced by the `Quality Gates` CI workflow
(`.github/workflows/quality-gates.yml`) and how it maps to the governing work items.

## Governed work items

| Item | Reference |
|------|-----------|
| Sub-Spec | `[Sub-Spec][M01-SS01] Solution and Dependency Boundaries` — GitHub Issue #2 |
| Milestone | M01 — Foundation and Architecture |
| Parent Spec | `[Parent Spec][M01] Foundation and Architecture` |
| Project | Weaverxyz MVP (GitHub Project V2, `project:mvp`) |
| ADRs | `docs/adr/0001-layered-four-tier-architecture.md`, `docs/adr/0003-technology-stack.md`, `docs/adr/0006-github-project-governance.md` |

## Evidence produced per run

The workflow runs on every `push` to `main` and every `pull_request`. For each
`configuration` in the matrix (`Debug`, `Release`) it publishes:

1. `dotnet restore PipelineOrchestrator.sln` — restore output (clean-environment restore, AC #1).
2. `dotnet build ... --configuration <Debug\|Release>` — build output with
   `TreatWarningsAsErrors`, `AnalysisLevel latest`, nullable enabled, deterministic builds
   (AC #8, Debug/Release parity).
3. `dotnet test ... --logger trx` — test results for all test projects:
   - `PipelineOrchestrator.Core.Tests`
   - `PipelineOrchestrator.Contracts.Tests`
   - `PipelineOrchestrator.ArchitectureTests`
   - `PipelineOrchestrator.Data.IntegrationTests`
4. `actions/upload-artifact` — `test-results-<configuration>.trx` artifacts retained as run evidence.

## Architecture enforcement in CI

`PipelineOrchestrator.ArchitectureTests` executes as part of `dotnet test` and verifies:

- allowed project references (`UI → Core`, `Data → Core`, Core has none);
- absence of dependency cycles;
- forbidden-reference rejection (UI does not reference Data/Npgsql/SQL);
- deterministic and nullable build properties in `Directory.Build.props`;
- absence of embedded credentials in source.

A deliberate forbidden reference or cycle causes the gate to fail (AC #3, #4).

## Local vs CI parity

Local equivalent commands:

```bash
dotnet restore PipelineOrchestrator.sln
dotnet build PipelineOrchestrator.sln --configuration Debug
dotnet build PipelineOrchestrator.sln --configuration Release
dotnet test PipelineOrchestrator.sln --configuration Debug
dotnet test PipelineOrchestrator.sln --configuration Release
```

CI runs the identical restore/build/test sequence for both `Debug` and `Release`, so
local and CI evidence are comparable (AC #8).

## Retention

Test-result artifacts (`*.trx`) are uploaded per workflow run and serve as the
evidence report linked to Sub-Spec #2, M01, the ADRs above, and the MVP project item.
