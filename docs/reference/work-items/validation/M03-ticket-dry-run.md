# M03 Ticket Decomposition Dry-Run

Status: **READY FOR GRANULARITY APPROVAL**

Operation: `to-tickets-weaverxyz-m03-v1`

## Proposed vertical Tickets

| ID | Title | Blocked by | Delivery |
|---|---|---|---|
| M03-T01 | Deliver Pipeline authoring and visual DAG editing | M02-T06 (#72) | Typed visual/programmatic DAG authoring, subpipelines, schemas, contracts, policies, snapshots, undo/redo, and actionable editor state. |
| M03-T02 | Deliver incremental validation and publication preflight | M03-T01 | Structural, contract, security, resource, compatibility, and fail-closed publication validation with actionable diagnostics. |
| M03-T03 | Deliver immutable version lifecycle and approvals | M03-T02 | Draft-to-published lifecycle, immutable hashes, review/approval, deprecation, archival, publication, rollback, and audit. |
| M03-T04 | Deliver semantic diff, impact, and compatibility analysis | M03-T01, M03-T02 | Structural/contract/security/operational diffs, breaking classification, impact, migration planning, and rollback posture. |
| M03-T05 | Deliver optimistic concurrency, snapshots, and merge assistance | M03-T01, M03-T02 | ETags/version checks, conflict detection, autosave snapshots, recovery, semantic merge assistance, and audit. |
| M03-T06 | Prove governed import/export and quality gates | M03-T03, M03-T04, M03-T05 | Versioned safe packages, integrity manifests, redaction/secret-reference checks, compatibility, fault, security, and reproduction evidence. |

## Waves

- Wave 0: M03-T01
- Wave 1: M03-T02
- Wave 2: M03-T03, M03-T04, M03-T05
- Wave 3: M03-T06

## Approval questions

1. Is six Tickets the right granularity?
2. Are the blocking edges genuine and minimal?
3. Should any Ticket be split or merged before publication?

No GitHub Ticket Issues or Project items were created by this dry-run.
