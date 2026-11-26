# M07 GitHub Publication Plan

## Scope

Publish one repository Milestone, one Parent Spec Issue, and four native Sub-Spec Issues after local validation, provider preflight, dry-run, and explicit approval. Tickets remain deferred.

## Planned identifiers

- Milestone: `M07 — Windows Forms UI and Accessibility`
- Parent Spec: `[Parent Spec][M07] Windows Forms UI and Accessibility`
- Sub-Specs: `[Sub-Spec][M07-SS01]` through `[Sub-Spec][M07-SS04]`

## Operation

`publish-m07-windows-forms-accessibility-v1`

## Mutation order

1. Reconcile Milestone.
2. Create/reconcile Parent Spec and add it to Project #30.
3. Apply native Issue Type, milestone, labels, assignee, and Project fields.
4. Create/reconcile four Sub-Specs.
5. Add native parent/sub-issue relationships.
6. Post structured English engineering comments.
7. Reconcile Project fields and health checks.
8. Record audit evidence; do not create Tickets.

## Idempotency and rollback

Use semantic IDs and native IDs. Do not intentionally duplicate issues, items, relationships, labels, milestones, or comments. Capture state before mutation and correct metadata/relationships before considering closure.
