# M01 GitHub Publication Plan

## Scope

Published one repository-level Milestone, one Parent Spec Issue, and six canonical native Sub-Spec Issues. Do not publish Tickets until each Sub-Spec is accepted and its Ticket decomposition has passed review.

## Planned identifiers

- Milestone: `M01 — Foundation and Architecture`
- Parent Spec: `[Parent Spec][M01] Foundation and Architecture`
- Sub-Specs: `[Sub-Spec][M01-SS01]` through `[Sub-Spec][M01-SS06]`

## Required preflight

1. Verify repository identity and GitHub authentication.
2. Verify issue types, milestones, labels, Projects, parent/sub-issue, and dependency capabilities.
3. Verify Project ID and field/view IDs; never infer identifiers.
4. Validate every draft and its source digest.
5. Validate the dependency graph and coverage matrix.
6. Generate a dry-run argv/API mutation plan.
7. Obtain explicit approval for remote mutation. **Completed 2026-11-25.**

## Mutation order and result

1. Milestone `M01` created as repository milestone #1.
2. Parent Spec published as Issue #1.
3. Six canonical Sub-Spec Issues published as #2–#5, #7, and #8.
4. Native parent/sub-issue relationships reconciled.
5. Project V2 #30 and governed fields reconciled.
6. Initial English engineering comments posted.
7. Accidental duplicate Issues #6 and #9–#11 closed as not planned; duplicate Project item removed.
8. Post-mutation health checks completed.

## Idempotency

Operation ID: `publish-m01-foundation-architecture-v1`. Re-running must reconcile by semantic ID and native IDs, never intentionally duplicate Issues, labels, relationships, comments, milestones, or Project items.

## Rollback

Do not delete Issues as a first response. Disable automation, capture state, reconcile incorrect fields/relationships, and use the Project rollback runbook. Issue closure or archival requires explicit approval.
