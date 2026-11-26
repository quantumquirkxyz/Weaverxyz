# M10 Coverage Matrix

## Parent Spec

`[Parent Spec][M10] Observability, Verification, Documentation, and Release`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M10-SS01 | Observability/SLOs | Correlated telemetry, SLOs, alerts, dashboards, and runbooks | M01–M09 seams | SS02–SS04, operations |
| M10-SS02 | Verification/gates | Release-blocking functional, security, performance, resilience, and accessibility verification | M01–M09 tests/evidence | SS04, release |
| M10-SS03 | Documentation/traceability | Owned, fresh, versioned documentation and requirement-to-evidence traceability | M01–M09 artifacts | SS04, operators, users |
| M10-SS04 | Release/operations | Reproducible delivery, rollback, incidents, deprecation, and continuous improvement | SS01–SS03, M01–M09 | Operations and acceptance |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Structured logs, metrics, traces, health | SS01 | Telemetry and health report |
| SLI/SLO, error budgets, alerts | SS01 | SLO/alert/burn-rate catalogue |
| Functional and contract verification | SS02 | Quality-gate matrix |
| Security, privacy, secrets, supply chain | SS02 | Security/SBOM/provenance report |
| Performance, resilience, recovery, accessibility | SS02 | Performance/resilience/accessibility evidence |
| Documentation and ADR governance | SS03 | Documentation inventory and ADR review |
| Requirement-to-code-test-evidence traceability | SS03 | Traceability matrix |
| Reproducible builds and release | SS04 | Artifact/release manifest |
| Rollback, incident response, deprecation | SS04 | Operational readiness/runbook evidence |
| Capacity, cost, error-budget learning | SS04 | Capacity/cost/postmortem report |

## Boundary review

- M09 owns AgentCall-specific evidence and security policy; M10 owns cross-cutting verification, telemetry, documentation, and release gates.
- M08 owns durable audit/evidence persistence; M10 governs evidence completeness and release use.
- M10 consumes product behavior and does not redefine domain, UI, persistence, or AgentCall semantics.
- No uncovered M10 requirement identified.
