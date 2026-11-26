# [Sub-Spec][M01-SS06] End-to-End Vertical Slice and Quality Gates

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS06
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Implementation → Verification → Release
- **Status:** Triage
- **Priority:** Critical
- **Risk:** Critical
- **Area:** Cross-cutting / QA / Release
- **Repo Scope:** Cross-cutting
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss06-vertical-slice-v1`

## Capability and outcome

Integrate the five preceding M01 Sub-Specs into a release-candidate desktop vertical slice and prove that Weaverxyz's UI, domain contracts, execution engine, PostgreSQL persistence, configuration, observability, security, accessibility, and quality gates operate together.

## Operator journey

1. Create or load a Pipeline in Windows Forms.
2. Edit the DAG visually.
3. Configure Steps, contracts, policies, and connectors.
4. Validate graph, schemas, security, resources, and effective configuration.
5. Save an immutable Pipeline version and definition hash.
6. Execute from the UI.
7. Observe pushed Step events and 500 ms aggregate refresh.
8. Inspect structured, redacted logs and snapshots.
9. Trigger or simulate failure.
10. Verify retry, rollback/compensation, cancellation, or recovery.
11. Compare executions.
12. Export diagnostics and evidence.

## End-to-end scenarios

### Successful pipelines

- `FileSource → FilterTransform → FileSink`
- `PostgresSource → MapTransform → PostgresSink`

### Negative and resilience scenarios

- Invalid input/output schema
- Cyclic DAG
- Unavailable source
- Failed transformation
- Failed sink
- Retryable timeout
- Cancellation and cooperative shutdown
- Rollback/compensation success
- Rollback/compensation failure
- Abandoned execution and recovery
- Redacted snapshot
- Configuration conflict
- Comparison of successful and failed executions
- Diagnostic export

## Quality gates

M01-SS06 blocks completion unless all applicable gates pass:

- reproducible build;
- architecture/dependency tests;
- unit, integration, contract, migration, and end-to-end tests;
- state-machine and resilience tests;
- fault injection and replay;
- performance and resource-budget validation;
- secret, dependency, and SBOM scans;
- threat-model/security checks;
- accessibility and manual UI QA;
- documentation/link validation;
- GitHub Project metadata and native relationship reconciliation;
- release evidence and rollback readiness.

Gates activate adaptively by `Type`, `Risk`, `Area`, and `Phase`. Exceptions require owner, rationale, control, expiry, and approval.

## Reproducible evidence package

Every release-candidate run produces an artifact manifest containing operation ID, commit, Pipeline version, definition/configuration hashes, environment identity, test matrix, gate results, UI screenshots/recording, execution/diagnostic exports, rollback/recovery results, security/accessibility evidence, documentation links, Project reconciliation report, release notes, and checksums.

## Windows Forms QA

The manual QA session records environment, application/version, Designer open/save behavior, keyboard/focus/contrast/scaling behavior, DAG editing, validation, execution, logs, states, cancellation, errors, rollback, recovery, redaction, screenshots/recording, defects, and linked evidence.

## Release governance

M01 release requires all required Sub-Specs/Tickets closed, quality gates passed, evidence reproducible, version tag, release notes, known limitations, security/accessibility status, migration/rollback plan, synchronized Project metadata, and explicit release-owner approval. The Parent Spec closes only after the release is accepted.

## Definition of Ready

- M01-SS01 through M01-SS05 contracts are accepted and available.
- End-to-end scenarios, gates, evidence format, QA checklist, release rules, and dependencies are documented.
- Environment and test data are reproducible and safe.
- Project metadata, owners, risks, and evidence destinations are assigned.
- No unresolved integration conflict blocks execution.

## Definition of Done

- Full Windows Forms journey executes successfully.
- Both primary pipelines and all required negative/resilience scenarios are evidenced.
- Rollback, retry, cancellation, recovery, observability, and redaction pass.
- Quality gates, security, accessibility, performance, and documentation checks pass.
- Manual QA session is reproducible and complete.
- Project metadata and native relationships reconcile.
- Artifact manifest, release notes, known limitations, and rollback plan are approved.
- M01 release is tagged and approved; Parent Spec remains open until release evidence is accepted.

## Acceptance criteria

1. An operator can complete the full design-to-diagnosis journey from Windows Forms.
2. Both primary source/transform/sink pipelines execute and persist evidence.
3. Invalid graphs and contracts are blocked before side effects.
4. Failure scenarios demonstrate retry, compensation, cancellation, and recovery policies.
5. UI events, aggregate state, logs, snapshots, metrics, and diagnostics correlate correctly.
6. Sensitive values are redacted and never appear in forbidden persistence or evidence surfaces.
7. Clean-environment and CI results are reproducible.
8. Manual accessibility and Designer QA evidence exists.
9. All required gates and Project reconciliation pass.
10. Release artifacts and rollback procedures are approved.

## Expected evidence

- End-to-end execution traces
- Test matrix and quality-gate report
- Fault injection/replay results
- UI QA checklist, screenshots/recording, and defect log
- Security, secret, dependency, SBOM, and accessibility evidence
- Performance/resource report
- Diagnostic exports and artifact manifest
- Project reconciliation report
- Release tag, notes, limitations, and rollback plan
