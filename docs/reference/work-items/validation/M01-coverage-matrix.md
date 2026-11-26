# M01 Coverage Matrix

## Parent Spec

`[Parent Spec][M01] Foundation and Architecture`

## Sub-Spec coverage

| Sub-Spec | Primary concern | Required outcome | Depends on | Downstream consumers |
|---|---|---|---|---|
| M01-SS01 | Solution and dependency boundaries | Reproducible solution and enforced architecture | None | All M01 Sub-Specs |
| M01-SS02 | Domain contracts and capability registry | Versioned domain kernel and extensibility | M01-SS01 | SS03, SS04, SS05, SS06 |
| M01-SS03 | Configuration and environments | Secure, reproducible effective configuration | SS01, SS02 | SS04, SS05, SS06 |
| M01-SS04 | Persistence and migrations | Durable PostgreSQL foundation | SS01, SS02, SS03 | SS05, SS06 |
| M01-SS05 | Execution and observability | Governed DAG execution and recovery | SS01, SS02, SS03, SS04 | SS06 |
| M01-SS06 | End-to-end slice and gates | Release-candidate integration evidence | SS01–SS05 | M02 |

## Requirement coverage

| Requirement | Source | Verifying Sub-Spec | Evidence |
|---|---|---|---|
| Three-project dependency boundaries | ADR-001, ADR-005 | SS01 | Architecture report |
| Reproducible toolchain | M01 Parent Spec | SS01 | Clean build logs |
| Versioned DAG and contracts | ADR-007 | SS02 | Contract/property tests |
| Capability extensibility | ADR-002, ADR-007 | SS02 | Registry report |
| Secure configuration | ADR-004, M01 Parent Spec | SS03 | Schema/secret/drift tests |
| PostgreSQL persistence | ADR-005 | SS04 | Migration/integration report |
| Incremental execution persistence | ADR-008 | SS04/SS05 | Recovery report |
| Governed execution | ADR-008 | SS05 | State/resilience tests |
| UI integration | ADR-003 | SS01/SS06 | Windows Forms QA |
| End-to-end functionality | ADR-009 | SS06 | Artifact manifest |
| Security and redaction | ADR-004, M01 Parent Spec | SS03–SS06 | Security evidence |
| M01 release readiness | ADR-009 | SS06 | Release package |

## Gap assessment

- No uncovered M01 requirement identified.
- Numeric thresholds (performance, payload, retention, RPO/RTO) remain implementation inputs and must be assigned before the affected Ticket enters Ready.
- Concrete library/tool selections remain implementation decisions and must not silently alter the contracts.
