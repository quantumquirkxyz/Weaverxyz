# M08 Provider Preflight and Publication Dry-Run

## Status

**READY FOR APPROVAL**

## Provider evidence

- Repository: `quantumquirkxyz/Weaverxyz`
- Permission: `ADMIN`
- Default branch: `main`
- Project: `Weaverxyz Engineering Delivery` (#30)
- Project linked to repository: verified
- Required Area options include `Data`, `Persistence`, `QA`, and `Cross-cutting`
- Existing Milestones: M01–M07
- Native parent/sub-issue mutations: available from prior publications
- Project field updates: available from prior publications

## Planned operation

`publish-m08-postgresql-persistence-v1`

1. Create/reconcile Milestone `M08 — PostgreSQL Persistence and Migrations`.
2. Create/reconcile Parent Spec and add it to Project #30.
3. Apply native Issue Type, milestone, labels, assignee, and Project fields.
4. Create/reconcile four Sub-Spec Issues.
5. Add native parent/sub-issue relationships.
6. Post structured English engineering comments.
7. Run post-publication health checks.
8. Defer Tickets until Sub-Spec acceptance.

## Dry-run mapping

| Item | Area | Dependency |
|---|---|---|
| M08 | Persistence | M01–M07 accepted contracts |
| M08-SS01 | Persistence | M01–M07 records |
| M08-SS02 | Persistence | SS01, M01, M02 |
| M08-SS03 | Data | SS01, SS02, M06 |
| M08-SS04 | QA | SS01–SS03 |

## Approval gate

Provider preflight passed. Remote publication remains pending explicit approval.
