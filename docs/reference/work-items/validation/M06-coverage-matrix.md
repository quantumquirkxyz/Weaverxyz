# M06 Coverage Matrix

## Parent Spec

`[Parent Spec][M06] Execution, Retry, Rollback, and Recovery`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M06-SS01 | Scheduler/states | Governed DAG runtime and formal states | M01, M02, M03, M05 | SS02, SS03, M07, M08 |
| M06-SS02 | Retry/resilience | Typed bounded retry and resilience | M02, M04, M05, SS01 | SS03, M07–M09 |
| M06-SS03 | Rollback/recovery | Compensation and abandoned-run recovery | M01, M02, M04, M05, SS01–SS02 | M07, M08, M09 |
| M06-SS04 | Testing | Runtime resilience evidence and gates | SS01–SS03 | M07–M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| DAG scheduler and execution states | SS01 | Scheduler/state trace |
| Typed retry and resilience | SS02 | Retry/resilience report |
| LIFO rollback and compensation | SS03 | Compensation evidence |
| Abandoned-run recovery | SS03 | Reconstruction/reconciliation report |
| Budgets, backpressure, observability | SS01–SS03 | Runtime governance report |
| Fault injection and replay | SS04 | Resilience matrix and replay evidence |
| Security/redaction and audit | SS02–SS04 | Security/evidence report |

## Boundary review

- M05 owns transformation/validation outcomes and data-quality decisions.
- M06 owns runtime orchestration, retry, compensation, recovery, reconciliation, and runtime evidence.
- M07 consumes runtime events and states for UI monitoring; it does not redefine execution semantics.
- M08 persists M06 runtime records; it does not own recovery policy.
- No uncovered M06 requirement identified.
