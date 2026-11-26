# M07 Coverage Matrix

## Parent Spec

`[Parent Spec][M07] Windows Forms UI and Accessibility`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M07-SS01 | UI shell/screens | Governed operator shell and navigation | M01, M02–M06 | SS02–SS04 |
| M07-SS02 | Editor/configuration | Designer-compatible authoring and preflight UI | M02, M03, M04, M05 | SS03, M08 |
| M07-SS03 | Monitoring/diagnostics | Runtime state, events, recovery, history, diagnostics | M06, M08 | SS04, M09 |
| M07-SS04 | Accessibility/testing | Inclusive UI and complete quality evidence | SS01–SS03 | M08, M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Shell and navigation | SS01 | Screen/state/navigation report |
| DAG editor and configuration | SS02 | Designer/editor/preflight report |
| Runtime monitoring and recovery | SS03 | Event/state/history/diagnostic report |
| Accessibility and inclusive interaction | SS04 | Accessibility tree and manual QA evidence |
| UI/Core and Designer governance | SS01, SS02, SS04 | Architecture and Designer report |
| E2E and visual quality gates | SS04 | Reproducible checksummed manifest |

## Boundary review

- M06 owns runtime semantics; M07 displays and controls them through contracts/events.
- M08 owns persistence; M07 consumes repository/application contracts.
- M07 owns presentation, interaction, accessibility, and UI QA.
- No business rules, SQL, or Npgsql belong in UI.
- No uncovered M07 requirement identified.
