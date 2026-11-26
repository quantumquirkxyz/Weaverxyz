# [Parent Spec][M07] Windows Forms UI and Accessibility

## Work Item Contract

- **Work Type:** Parent Spec
- **Native Issue Type:** Feature
- **Milestone:** M07 — Windows Forms UI and Accessibility
- **Semantic ID:** M07
- **Owner:** `quantumquirkxyz`
- **Phase:** Requirements → Architecture → Design → Implementation → Verification
- **Status:** Draft
- **Priority:** High
- **Risk:** High
- **Repo Scope:** `PipelineOrchestrator.UI`
- **Release Train:** MVP
- **Operation ID:** `parent-spec-weaverxyz-m07-windows-forms-accessibility-v1`

## Objective

Deliver a Designer-compatible Windows Forms application that supports Pipeline authoring, validation, configuration, execution monitoring, recovery, diagnostics, history, and accessible operation while preserving strict UI/Core boundaries.

## Boundary with earlier milestones

M01 establishes UI composition and dependency boundaries. M02–M06 provide domain, authoring, connector, transformation, and runtime contracts/events. M07 owns the Windows Forms shell, screens, interaction state, accessibility, event-to-view synchronization, and manual/UI verification. Business rules, SQL, and orchestration remain outside UI.

## Operator shell

The application includes Pipeline workspace, visual DAG editor, Step/configuration inspector, environment/configuration view, validation/preflight panel, execution monitor, cancellation/shutdown controls, logs and redacted snapshots, execution history/comparison, recovery/reconciliation view, diagnostics/evidence export, settings, and accessibility preferences.

## UI state and events

`ProgressReporter` events and aggregate state synchronize the UI with versioned correlation IDs, thread-safe updates, bounded polling, explicit transient states, out-of-order event handling, reconnection/recovery, and non-blocking UI work. States include empty/loading, draft/editing, validation failed, ready/published, running, retrying, cancellation requested, rolling back, compensation failed, cancelled/timed out, recovery required/recovered/failed, completed/failed, stale/conflict, offline/unavailable, and permission denied.

## Accessibility

The UI provides keyboard-complete navigation, visible focus, accessible names/labels, contrast and themes, DPI/font scaling, non-color state communication, actionable errors, reduced motion, screen-reader compatibility, documented shortcuts, accessibility tree checks, and reproducible manual evidence aligned with WCAG/Windows UI expectations.

## Designer and architecture

Forms remain `partial` and Designer-open/save compatible. Generated code is isolated. Code-behind contains no business rules. Composition root and presenters/application services connect UI to Core. UI has no SQL/Npgsql/concrete repository access. Architecture tests and CI detect forbidden dependencies.

## Dependencies and consumers

- M02 domain/events and validation contracts.
- M03 authoring/version lifecycle contracts.
- M04 connector configuration and health.
- M05 validation and metrics.
- M06 runtime states/events/recovery/diagnostics.
- M08 persistence-backed history and evidence.
- M09 AgentCall configuration/status and redaction.

## Definition of Ready

- M01–M06 contracts and required events are accepted.
- Screens, navigation, state model, accessibility criteria, Designer rules, QA fixtures, and evidence expectations are documented.
- Windows QA environment and representative datasets are assigned.
- No unresolved UI/Core or accessibility ownership conflict blocks decomposition.

## Definition of Done

- Operator shell and primary screens work.
- DAG editor, configuration, preflight, execution, retry, cancellation, rollback, recovery, logs, history, comparison, and diagnostics work.
- Designer open/save and UI/Core architecture gates pass.
- Keyboard, focus, labels, contrast, DPI, screen reader, reduced motion, and non-color states are verified.
- Event synchronization, offline/conflict/error states, redaction, and visual regression are evidenced.
- Manual QA is reproducible and complete.
- Documentation, ADRs, Project metadata, and evidence manifest are synchronized.

## Acceptance criteria

1. An operator can design, validate, configure, execute, monitor, recover, compare, and diagnose a Pipeline from Windows Forms.
2. UI never bypasses Core contracts or accesses SQL/Npgsql directly.
3. Runtime events and aggregate state remain correlated and thread-safe.
4. Invalid, stale, offline, permission, and recovery states are actionable and not color-only.
5. Designer open/save works without moving business logic into generated code.
6. Keyboard, focus, scaling, contrast, screen-reader, reduced-motion, and accessibility-tree checks pass.
7. Manual QA and visual evidence reproduce expected behavior.

## Expected evidence

- Screen/navigation/state diagrams
- Designer open/save record
- Architecture dependency report
- Accessibility tree and manual QA checklist
- Keyboard/focus/contrast/DPI/screen-reader evidence
- E2E execution/recovery/redaction evidence
- Visual regression and offline/conflict reports
- Documentation, ADR, Project, and traceability links
