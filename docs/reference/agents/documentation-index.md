# Weaverxyz Documentation Index

## Start here

- `README.md` — project orientation and onboarding.
- `CONTEXT.md` — domain vocabulary and boundaries.
- `docs/reference/agents/github-project.md` — Project V2 governance.
- `docs/reference/agents/documentation-governance.md` — documentation ownership and lifecycle.

## Architecture and theory

- `docs/adr/` — accepted architecture decisions.
- `docs/architecture/` — diagram-as-code sources.
- `docs/theory/software-engineering-foundations.md` — principles and traceability model.

## Operations

- `docs/runbooks/github-project-rollback.md` — Project recovery procedure.
- `docs/how-to/adoption.md` — skills bundle validation and operating model.

## Governance rule

All documentation is written in English, versioned, linked to work items when changed, and updated according to `Type`, `Phase`, `Risk`, and `Area`. Documentation drift is a quality finding, not an optional cleanup task.

## Product and requirements

- `docs/reference/functional-specification.md` — user journey, capability catalog, and functional invariants.
- `docs/reference/objectives-and-success.md` — objectives, quality budgets, academic evidence, and non-goals.

## Work item hierarchy

- `docs/reference/work-items/hierarchy-governance.md` — Milestone → Parent Spec → Sub-Spec → Ticket model.
- `docs/reference/work-items/comment-contract.md` — English engineering comment schema and event policy.
- `docs/reference/work-items/parent-spec-template.md` — Parent Spec contract.
- `docs/reference/work-items/sub-spec-template.md` — Sub-Spec vertical-slice contract.
- `docs/reference/work-items/ticket-template.md` — claimable Ticket contract.

## Parent Spec drafts

- `docs/reference/work-items/parent-specs/M01-foundation-and-architecture.md` — refined local draft; publish only after review and provider dry-run.

## M01 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M01-SS01-solution-and-dependency-boundaries.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

- `docs/reference/work-items/sub-specs/M01-SS02-domain-contracts-and-capability-registry.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

- `docs/reference/work-items/sub-specs/M01-SS03-configuration-and-environment-management.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

- `docs/reference/work-items/sub-specs/M01-SS04-persistence-foundation-and-migrations.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

- `docs/reference/work-items/sub-specs/M01-SS05-execution-and-observability-foundation.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

- `docs/reference/work-items/sub-specs/M01-SS06-end-to-end-vertical-slice-and-quality-gates.md` — refined local draft; publish only after Parent Spec acceptance and provider dry-run.

## M01 validation

- `docs/reference/work-items/validation/M01-coverage-matrix.md` — requirement and Sub-Spec coverage.
- `docs/reference/work-items/validation/M01-dependency-graph.md` — dependency graph and claimable waves.
- `docs/reference/work-items/validation/M01-publication-plan.md` — idempotent GitHub publication plan.

- `docs/reference/work-items/parent-specs/M02-domain-model-and-contracts.md` — refined local Parent Spec draft; publish only after Sub-Spec refinement and validation.

## M02 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M02-SS01-pipeline-dag-and-subpipeline-model.md` — refined local draft; publish only after M02 validation.
- `docs/reference/work-items/sub-specs/M02-SS02-step-capability-contracts.md` — refined local draft; publish only after M02 validation.
- `docs/reference/work-items/sub-specs/M02-SS03-datapacket-schemas-and-lineage.md` — refined local draft; publish only after M02 validation.
- `docs/reference/work-items/sub-specs/M02-SS04-capability-registry-and-historical-resolution.md` — refined local draft; publish only after M02 validation.
- `docs/reference/work-items/sub-specs/M02-SS05-errors-events-compatibility-and-deprecation.md` — refined local draft; publish only after M02 validation.
- `docs/reference/work-items/sub-specs/M02-SS06-domain-verification-and-contract-quality-gates.md` — refined local draft; publish only after M02 validation.

## M02 validation

- `docs/reference/work-items/validation/M02-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M02-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M02-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M02-provider-preflight-and-dry-run.md` — provider inventory and blocked publication dry-run.

- `docs/reference/work-items/parent-specs/M03-pipeline-definition-and-versioning.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M03 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M03-SS01-pipeline-authoring-and-visual-dag-editing.md` — refined local draft; publish only after M03 validation.
- `docs/reference/work-items/sub-specs/M03-SS02-incremental-validation-and-publication-preflight.md` — refined local draft; publish only after M03 validation.
- `docs/reference/work-items/sub-specs/M03-SS03-immutable-version-lifecycle-and-approvals.md` — refined local draft; publish only after M03 validation.
- `docs/reference/work-items/sub-specs/M03-SS04-semantic-diff-impact-and-compatibility.md` — refined local draft; publish only after M03 validation.
- `docs/reference/work-items/sub-specs/M03-SS05-optimistic-concurrency-snapshots-and-merge.md` — refined local draft; publish only after M03 validation.
- `docs/reference/work-items/sub-specs/M03-SS06-governed-import-export-and-quality-gates.md` — refined local draft; publish only after M03 validation.

## M03 validation

- `docs/reference/work-items/validation/M03-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M03-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M03-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/parent-specs/M04-source-and-sink-connectors.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M04 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M04-SS01-file-connectors.md` — refined local draft; publish only after M04 validation.
- `docs/reference/work-items/sub-specs/M04-SS02-postgresql-connectors.md` — refined local draft; publish only after M04 validation.
- `docs/reference/work-items/sub-specs/M04-SS03-http-and-report-connectors.md` — refined local draft; publish only after M04 validation.
- `docs/reference/work-items/sub-specs/M04-SS04-connector-testing.md` — refined local draft; publish only after M04 validation.

## M04 validation

- `docs/reference/work-items/validation/M04-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M04-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M04-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/parent-specs/M05-transformation-and-validation-engine.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M05 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M05-SS01-transformations.md` — refined local draft; publish only after M05 validation.
- `docs/reference/work-items/sub-specs/M05-SS02-validators.md` — refined local draft; publish only after M05 validation.
- `docs/reference/work-items/sub-specs/M05-SS03-processing-engine.md` — refined local draft; publish only after M05 validation.
- `docs/reference/work-items/sub-specs/M05-SS04-testing.md` — refined local draft; publish only after M05 validation.

## M05 validation

- `docs/reference/work-items/validation/M05-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M05-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M05-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M05-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/parent-specs/M06-execution-retry-rollback-and-recovery.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M06 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M06-SS01-scheduler-and-execution-states.md` — refined local draft; publish only after M06 validation.
- `docs/reference/work-items/sub-specs/M06-SS02-retry-and-resilience.md` — refined local draft; publish only after M06 validation.
- `docs/reference/work-items/sub-specs/M06-SS03-rollback-and-recovery.md` — refined local draft; publish only after M06 validation.
- `docs/reference/work-items/sub-specs/M06-SS04-testing.md` — refined local draft; publish only after M06 validation.

## M06 validation

- `docs/reference/work-items/validation/M06-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M06-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M06-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/parent-specs/M07-windows-forms-ui-and-accessibility.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M07 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M07-SS01-ui-shell-and-screens.md` — refined local draft; publish only after M07 validation.
- `docs/reference/work-items/sub-specs/M07-SS02-pipeline-editor-and-configuration.md` — refined local draft; publish only after M07 validation.
- `docs/reference/work-items/sub-specs/M07-SS03-runtime-monitoring-and-diagnostics.md` — refined local draft; publish only after M07 validation.
- `docs/reference/work-items/sub-specs/M07-SS04-accessibility-and-testing.md` — refined local draft; publish only after M07 validation.

## M07 validation

- `docs/reference/work-items/validation/M07-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M07-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M07-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M07-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/parent-specs/M08-postgresql-persistence-and-migrations.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M08 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M08-SS01-relational-schema-and-migrations.md` — refined local draft; publish only after M08 validation.
- `docs/reference/work-items/sub-specs/M08-SS02-repositories-and-transactions.md` — refined local draft; publish only after M08 validation.
- `docs/reference/work-items/sub-specs/M08-SS03-backup-restore-and-recovery.md` — refined local draft; publish only after M08 validation.
- `docs/reference/work-items/sub-specs/M08-SS04-testing-and-performance.md` — refined local draft; publish only after M08 validation.

## M08 validation

- `docs/reference/work-items/validation/M08-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M08-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M08-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M08-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/validation/M08-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/parent-specs/M09-agentcall-security-and-governance.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M09 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M09-SS01-agentcall-contracts-and-providers.md` — refined local draft; publish only after M09 validation.
- `docs/reference/work-items/sub-specs/M09-SS02-security-and-authorization.md` — refined local draft; publish only after M09 validation.
- `docs/reference/work-items/sub-specs/M09-SS03-budgets-resilience-and-audit.md` — refined local draft; publish only after M09 validation.
- `docs/reference/work-items/sub-specs/M09-SS04-evaluation-and-testing.md` — refined local draft; publish only after M09 validation.

## M09 validation

- `docs/reference/work-items/validation/M09-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M09-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M09-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M09-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/parent-specs/M10-observability-verification-documentation-and-release.md` — refined local Parent Spec draft; publish after Sub-Spec refinement and validation.

## M10 Sub-Spec drafts

- `docs/reference/work-items/sub-specs/M10-SS01-observability-and-slos.md` — refined local draft; publish only after M10 validation.
- `docs/reference/work-items/sub-specs/M10-SS02-verification-and-quality-gates.md` — refined local draft; publish only after M10 validation.
- `docs/reference/work-items/sub-specs/M10-SS03-documentation-and-traceability.md` — refined local draft; publish only after M10 validation.
- `docs/reference/work-items/sub-specs/M10-SS04-release-and-operational-readiness.md` — refined local draft; publish only after M10 validation.

## M10 validation

- `docs/reference/work-items/validation/M10-coverage-matrix.md` — requirement and boundary coverage.
- `docs/reference/work-items/validation/M10-dependency-graph.md` — dependency waves and invariants.
- `docs/reference/work-items/validation/M10-publication-plan.md` — idempotent publication plan.

- `docs/reference/work-items/validation/M10-provider-preflight-and-dry-run.md` — provider inventory and publication dry-run.

- `docs/reference/work-items/validation/roadmap-parent-sub-spec-acceptance-audit-20261125.md` — final M01–M10 Parent/Sub-Spec audit and acceptance baseline; Tickets remain a separate authorized phase.
