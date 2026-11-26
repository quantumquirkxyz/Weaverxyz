# M02 GitHub Publication Plan

## Scope

Publish one repository Milestone, one root Parent Spec Issue, and six native Sub-Spec Issues only after local validation and explicit approval. Do not publish Tickets before each Sub-Spec is accepted.

## Planned identifiers

- Milestone: `M02 — Domain Model and Contracts`
- Parent Spec: `[Parent Spec][M02] Domain Model and Contracts`
- Sub-Specs: `[Sub-Spec][M02-SS01]` through `[Sub-Spec][M02-SS06]`

## Required preflight

1. Verify repository identity, authentication, and permissions.
2. Reconcile existing Milestone, Project, labels, Issue Types, and native relationship capabilities.
3. Validate M02 drafts, source digests, coverage, and dependency graph.
4. Confirm Project #30 is linked to `quantumquirkxyz/Weaverxyz`.
5. Generate a dry-run mutation plan using semantic IDs.
6. Obtain explicit approval for M02 remote mutation.

## Mutation order

1. Reconcile Milestone idempotently.
2. Create or reconcile the M02 Parent Spec.
3. Add it to Project #30 and apply governed fields.
4. Reconcile six Sub-Spec Issues with Feature type, labels, milestone, assignee, and Project fields.
5. Add native Parent/Sub-Issue relationships.
6. Post structured English engineering comments.
7. Reconcile Project fields and health checks.
8. Record audit evidence and defer Tickets until Sub-Spec acceptance.

## Idempotency

Operation ID: `publish-m02-domain-model-contracts-v1`. Reconciliation uses semantic IDs and native issue IDs; reruns must not intentionally duplicate Milestones, Issues, Project items, relationships, labels, or comments.

## Rollback

Capture state before mutation. Correct fields and relationships before considering closure. Do not delete Issues as a first response. Accidental duplicates require explicit duplicate closure comments and Project-item cleanup.
