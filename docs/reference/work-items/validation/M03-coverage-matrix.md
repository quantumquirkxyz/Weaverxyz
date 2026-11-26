# M03 Coverage Matrix

## Parent Spec

`[Parent Spec][M03] Pipeline Definition and Versioning`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M03-SS01 | Pipeline authoring | Visual/programmatic DAG authoring and recoverable drafts | M02 contracts | SS02, SS05, M07 |
| M03-SS02 | Validation/preflight | Fail-closed publication readiness | SS01, M02 contracts | SS03–SS06, M04–M09 |
| M03-SS03 | Version lifecycle | Immutable states, approvals, publication, rollback | SS01, SS02 | SS04–SS06, M06, M08 |
| M03-SS04 | Semantic diff/compatibility | Impact and migration classification | SS01, SS02, SS03, M02 compatibility | SS03, SS06, M04–M09 |
| M03-SS05 | Concurrency/merge | Conflict-safe drafts and snapshots | SS01, SS03 | SS06, M07, M08 |
| M03-SS06 | Import/export/gates | Portable safe packages and release evidence | SS01–SS05 | M04–M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Visual and programmatic authoring | SS01 | Authoring and validation trace |
| Incremental publication preflight | SS02 | Positive/negative preflight report |
| Immutable version lifecycle | SS03 | State transition and audit report |
| Semantic diff and impact | SS04 | Diff, compatibility, migration report |
| Conflict-safe editing | SS05 | Concurrency and merge report |
| Safe package exchange | SS06 | Manifest, integrity, security report |
| M03 quality gates | SS06 | Checksummed evidence manifest |

## Boundary review

- M02 owns functional domain contracts, DAG vocabulary, capability metadata, and compatibility primitives.
- M03 owns authoring workflows, lifecycle governance, semantic change analysis, concurrency, and package exchange.
- M03 does not redefine M02 DAG or Step contracts.
- M04 consumes published definitions and connector capability references; it does not own authoring lifecycle.
- No uncovered M03 requirement identified.
