# Weaverxyz Agent Skills

This file holds repository-specific guidance and routing for agents working in Weaverxyz.

Weaverxyz is a desktop Data Pipeline Orchestrator built in C#/.NET 8 (Visual Studio 2022, Windows Forms, PostgreSQL). It applies Command, Composite, Builder, Observer, Repository, and Strategy patterns across three projects: `PipelineOrchestrator.UI`, `PipelineOrchestrator.Core`, and `PipelineOrchestrator.Data`.

## Agent skills

### Issue tracker

Issues are tracked in GitHub Issues (`quantumquirkxyz/Weaverxyz`) via the `gh` CLI. All GitHub-native fields and Project V2 fields are tracked through the governed authority model. See `docs/reference/agents/issue-tracker.md` and `docs/reference/agents/github-project.md`.

### Triage labels

Expanded taxonomy covers type, priority, status, area, effort, and project routing. Project V2 is authoritative for planning fields; labels remain routing compatibility. See `docs/reference/agents/triage-labels.md`.

### Domain docs

Single-context layout: root `CONTEXT.md` plus `docs/adr/`. See `docs/reference/agents/domain.md`.

### Engineering rules

Use Definition of Ready before claiming work and Definition of Done before completion. Preserve traceability from issue to ADR/design, implementation, tests, PR, release, and evidence. Fail closed on governance conflicts. All repository documentation must be written in English.
