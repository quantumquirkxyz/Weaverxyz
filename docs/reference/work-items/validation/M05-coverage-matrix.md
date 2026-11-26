# M05 Coverage Matrix

## Parent Spec

`[Parent Spec][M05] Transformation and Validation Engine`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M05-SS01 | Transformations | Versioned strategy/catalog and deterministic transforms | M02, M03, M04 | SS03, M06, M07 |
| M05-SS02 | Validators | Governed quality/security rules and outcomes | M02, M04, SS01 | SS03, M06, M08 |
| M05-SS03 | Processing engine | Adaptive safe data processing | SS01, SS02, M01, M02 | M06, M07, M08 |
| M05-SS04 | Testing | Cross-engine quality gates and evidence | SS01–SS03 | M06–M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Versioned TransformStrategy/catalog | SS01 | Registry and contract report |
| Initial transformation set | SS01 | Golden/determinism output |
| Governed validator set | SS02 | Rule and quality report |
| Fail-fast/collect-all/quarantine | SS02 | Quality policy evidence |
| Streaming/batching/backpressure | SS03 | Processing and budget report |
| Checkpoints, replay, determinism | SS03 | Replay/fault evidence |
| Lineage, redaction, metrics | SS01–SS03 | Observability report |
| Domain-wide quality gates | SS04 | Checksummed evidence manifest |

## Boundary review

- M02 owns domain/DataPacket/capability contracts.
- M03 owns Pipeline authoring/publication.
- M04 owns external connectors and transport safety.
- M05 owns in-process transforms, validators, adaptive processing, and data-quality evidence.
- M06 owns execution-level retry, rollback, and recovery orchestration.
- No uncovered M05 requirement identified.
