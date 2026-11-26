# M02 Coverage Matrix

## Parent Spec

`[Parent Spec][M02] Domain Model and Contracts`

## Sub-Spec coverage

| Sub-Spec | Primary concern | Required outcome | Depends on | Downstream consumers |
|---|---|---|---|---|
| M02-SS01 | Pipeline DAG and subpipelines | Immutable versioned graph and boundaries | M01-SS02 | SS02, SS03, M03, M06 |
| M02-SS02 | Step capability contracts | Complete Step policies and schemas | M01-SS02, SS01 | SS04, SS05, M04, M05, M09 |
| M02-SS03 | DataPacket, schemas, lineage | Governed data envelope and lineage | M01-SS02, SS01 | SS02, SS05, M04, M05, M08 |
| M02-SS04 | Capability Registry | Extensible and historical capability resolution | M01-SS02, SS02 | M04, M05, M06, M09 |
| M02-SS05 | Errors/events/compatibility | Typed evolution and consumer-safe events | M01-SS02, SS02–SS04 | M03–M09 |
| M02-SS06 | Verification and quality gates | Reproducible contract evidence | SS01–SS05 | M03–M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Immutable versioned Pipeline DAG | SS01 | DAG invariant and reproduction report |
| Typed Step capability contract | SS02 | Contract/schema and policy tests |
| Tabular/document DataPacket | SS03 | C#/JSON Schema parity and payload tests |
| Lineage and sensitivity | SS03 | Lineage/redaction evidence |
| Extensible historical registry | SS04 | Discovery and resolution report |
| Typed errors and immutable events | SS05 | Consumer and causality tests |
| Compatibility and deprecation | SS05 | Compatibility matrix and migration report |
| Domain-wide quality gates | SS06 | Checksummed evidence manifest |

## Boundary review

- M01 owns infrastructure seams and foundational execution/persistence/configuration boundaries.
- M02 owns functional domain vocabulary and contract governance.
- M03 owns product-facing Pipeline authoring/version workflows; it consumes M02 DAG contracts rather than redefining them.
- No uncovered M02 requirement identified.
- Numeric limits, compatibility windows, and concrete libraries remain Ticket-level inputs before implementation readiness.
