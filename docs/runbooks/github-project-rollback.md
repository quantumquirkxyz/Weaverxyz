# GitHub Project Rollback Runbook

## Trigger

Use this runbook when Project reconciliation creates incorrect fields, views, labels, statuses, relationships, or dates; when a conflict is detected; or when an automation run cannot prove idempotence.

## Procedure

1. Disable the affected Project automation workflow using an approved change.
2. Record the `operationId`, run ID, actor, timestamp, configuration hash, and observed mutation.
3. Export the current Project, fields, views, items, labels, milestones, and relationships.
4. Compare the export with the last known-good manifest and audit record.
5. Apply only the smallest reversible correction; never delete data as a first response.
6. Re-run reconciliation in dry-run mode.
7. Obtain approval for the corrective mutation.
8. Apply the correction idempotently and verify the health checks.
9. Re-enable automation only after the conflict is resolved and evidence is attached to the governance issue.

## Stop conditions

Stop and escalate if identifiers are missing, permissions are contradictory, a field has conflicting ownership, a destructive mutation is proposed, or the expected state cannot be reconstructed.
