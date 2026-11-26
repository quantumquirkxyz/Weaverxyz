# [Sub-Spec][M01-SS01] Solution and Dependency Boundaries

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS01
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Implementation → Verification
- **Status:** Triage
- **Priority:** Critical
- **Risk:** High
- **Area:** Core / Infrastructure
- **Repo Scope:** Cross-cutting
- **Effort:** L
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss01-boundaries-v1`

## Capability and outcome

Establish a reproducible Visual Studio solution whose production and test projects enforce Weaverxyz's architecture as executable rules. A clean Windows environment, Visual Studio, and CI must restore, build, test, and report comparable results.

## Scope

- Create `PipelineOrchestrator.sln`.
- Create production projects:
  - `PipelineOrchestrator.UI`
  - `PipelineOrchestrator.Core`
  - `PipelineOrchestrator.Data`
- Create test projects:
  - `PipelineOrchestrator.Core.Tests`
  - `PipelineOrchestrator.Data.IntegrationTests`
  - `PipelineOrchestrator.UI.ManualTests`
  - `PipelineOrchestrator.Contracts.Tests`
  - `PipelineOrchestrator.ArchitectureTests`
- Enforce dependencies:
  - `UI → Core`
  - `Data → Core`
  - `Core → BCL and own contracts only`
  - test projects reference only the assemblies they validate
  - no production circular dependencies
  - UI has no direct Npgsql, SQL, or concrete repository access
- Add a UI composition root/factory that connects `Data` implementations to `Core` abstractions.
- Fix SDK/toolchain and package configuration using `global.json`, `Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`, and documented package-lock strategy.
- Enable nullable reference types, implicit usings, analyzers, warnings-as-errors, deterministic builds, Source Link, and Debug/Release parity.
- Keep WinForms Forms as Designer-compatible partial classes with business logic outside code-behind.
- Add architecture/dependency enforcement to CI and produce evidence reports.

## Exclusions

This Sub-Spec does not implement domain behavior, PostgreSQL schema, pipeline execution, advanced connectors, AgentCall, or the complete UI. It provides the boundaries and tooling those Sub-Specs require.

## Dependency rules

| Consumer | Allowed dependency | Forbidden dependency |
|---|---|---|
| `PipelineOrchestrator.UI` | `Core` | Direct Npgsql, SQL, Data repositories |
| `PipelineOrchestrator.Core` | BCL, own contracts | UI, Data, Npgsql, Windows Forms |
| `PipelineOrchestrator.Data` | `Core`, Npgsql | UI |
| `Core.Tests` | Core | UI, Data unless explicitly fixture-only |
| `Data.IntegrationTests` | Data, Core, PostgreSQL fixture | UI |
| `Contracts.Tests` | Core contracts/schemas | UI implementation |
| `ArchitectureTests` | Assemblies under test | Production dependency additions |

## Toolchain baseline

- C# 12 and .NET 8.
- Visual Studio 2022 Community with Windows Forms Designer.
- Pinned .NET SDK through `global.json`.
- Shared build properties and targets.
- Central package version management.
- Nullable reference types enabled.
- Analyzers enabled and warnings treated as errors according to the quality profile.
- Deterministic builds and Source Link enabled.
- Local and CI restore/build/test commands documented and equivalent.

## Windows Forms boundary

The UI project remains editable in Visual Studio Designer. Forms use `partial` classes and isolate generated Designer code. Event handlers delegate to application services or presenters; business rules remain in Core. UI validation provides immediate feedback, while Core owns authoritative validation.

## Architecture verification

Architecture tests and CI checks must verify:

- allowed project references;
- forbidden namespace and assembly references;
- absence of cycles;
- Core independence from Data and UI;
- UI isolation from Npgsql and SQL;
- test boundary correctness;
- deterministic build configuration;
- required nullable/analyzer settings.

## Definition of Ready

- Parent Spec M01 is accepted or explicitly approved for decomposition.
- This Sub-Spec boundary and exclusions are approved.
- Dependency rules and toolchain baseline are documented.
- Required Project metadata, risks, quality gates, and evidence are assigned.
- No unresolved architecture conflict exists.

## Definition of Done

- All production and test projects exist and restore.
- Allowed dependency graph passes; cycles and forbidden references are absent.
- `Core` has no `Data`, UI, Npgsql, or Windows Forms dependency.
- UI composition root connects implementations without concrete repository access in views.
- WinForms Designer opens the intended Forms successfully.
- Clean environment and CI reproduce local build/test results.
- Debug and Release builds are validated.
- Analyzers, nullable checks, architecture tests, and required quality gates pass.
- Documentation, ADR references, Project metadata, and evidence report are synchronized.

## Acceptance criteria

1. A clean environment can restore and build the solution without undocumented local state.
2. The dependency graph exactly matches the allowed rules.
3. A deliberate forbidden reference causes the architecture gate to fail.
4. A deliberate dependency cycle causes the architecture gate to fail.
5. Core tests run without Windows Forms, Npgsql, or a live PostgreSQL dependency.
6. Data integration tests can reference Core contracts and Data implementations without UI.
7. The Windows Forms Designer can open and save a Form without moving business logic into generated code.
8. CI and local commands produce comparable build and test evidence.
9. The evidence report links results to this Sub-Spec, M01, ADRs, and the Project item.

## Expected evidence

- Solution/project reference graph
- Architecture-test output
- Forbidden-reference negative test output
- Cycle-detection negative test output
- Clean-environment build log
- Debug/Release build logs
- Analyzer and nullable report
- WinForms Designer smoke-test record
- CI run link
- Updated documentation and ADR references
