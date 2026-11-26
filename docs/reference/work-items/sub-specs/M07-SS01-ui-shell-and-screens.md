# [Sub-Spec][M07-SS01] UI Shell and Screens

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M07] Windows Forms UI and Accessibility`
- **Milestone:** M07 — Windows Forms UI and Accessibility
- **Semantic ID:** M07-SS01
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** High
- **Risk:** High
- **Area:** UI
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m07-ss01-v1`

## Capability and outcome

Implement the governed Windows Forms shell with navigation, Pipeline workspace, Step inspector, environment/configuration view, validation/preflight panel, execution monitor, cancellation/shutdown controls, logs/redacted snapshots, history/comparison, recovery/reconciliation, diagnostics/evidence export, settings, accessibility preferences, persisted navigation, and UI/Core boundary tests.

## Dependencies

M01 UI boundary; M02–M06 contracts/events

## Scope boundaries

This Sub-Spec consumes M01–M06 contracts and events. It owns the declared UI shell, authoring UI, monitoring, diagnostic, accessibility, or verification seam and must not move business rules, SQL, or execution semantics into the UI.

## Definition of Ready

- M07 Parent Spec and this boundary are accepted.
- Windows QA environment, accessibility fixtures, ownership, dependencies, security, and evidence expectations are resolved.
- Implementation choices required for Tickets are explicit.

## Definition of Done

- The declared capability or quality gate is implemented, Designer-compatible, accessible, validated, and observable.
- Positive, negative, accessibility, security, redaction, resilience, and visual tests pass.
- Evidence is reproducible and checksummed.
- ADRs, documentation, Project metadata, and native relationships are synchronized.
- The Sub-Spec is explicitly accepted before Tickets are generated.

## Acceptance criteria

1. The declared UI or quality capability follows UI/Core and Designer contracts.
2. Invalid, stale, offline, conflicting, unsafe, or inaccessible states are actionable.
3. Runtime state/events remain correlated, thread-safe, redacted, and diagnosable.
4. Accessibility and visual behavior are reproducible across supported scaling and themes.
5. Required tests produce deterministic results and an artifact manifest.

## Expected evidence

- UI/state/navigation diagrams
- Designer and architecture reports
- Accessibility and visual QA results
- E2E runtime/recovery/redaction evidence
- Reproducibility and checksummed evidence manifest
- Documentation, ADR, Project, and traceability links
- Navigation, state, thread-safety, empty/loading/error/offline/conflict, and UI/Core tests.
