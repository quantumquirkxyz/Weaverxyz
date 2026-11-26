# [Sub-Spec][M01-SS03] Configuration and Environment Management

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M01] Foundation and Architecture`
- **Milestone:** M01 — Foundation and Architecture
- **Semantic ID:** M01-SS03
- **Owner:** `quantumquirkxyz` (initial operational owner)
- **Phase:** Architecture → Design → Implementation → Verification
- **Status:** Triage
- **Priority:** High
- **Risk:** High
- **Area:** Infrastructure / Security
- **Repo Scope:** Cross-cutting
- **Effort:** L
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m01-ss03-configuration-v1`

## Capability and outcome

Provide a governed configuration system that makes every execution reproducible, secure, environment-aware, and auditable. Configuration must be treated as a versioned operational contract rather than scattered constants or manually edited values.

## Supported environments

- `Development`
- `Test`
- `Demo`
- `Production-like`

Each environment has explicit configuration, limits, security policies, external services, data rules, and secret requirements. `Production-like` is a safe validation profile, not a claim of production deployment.

## Configuration precedence

Values are resolved in this order:

1. Secure code defaults.
2. Versioned base configuration.
3. Versioned environment overlay.
4. Local user configuration where permitted.
5. Process environment variables.
6. `.env` adapter for local/CI secrets.
7. Explicit runtime overrides only when allowlisted.

Each effective value records source, precedence, sensitivity, schema path, and validation result. Secrets are represented by references and never by values in configuration snapshots.

## Configuration identity

The system calculates:

- effective configuration hash;
- hash for each source and overlay;
- execution configuration snapshot hash;
- baseline comparison result;
- non-sensitive diff;
- `operationId` for reconciliation or mutation.

An execution uses an immutable configuration snapshot. A configuration change cannot alter an active execution.

## Schemas and validation

Configuration schemas are versioned and validate:

- types, ranges, enums, required references, and compatibility;
- database connections and migration expectations;
- agent endpoints, model settings, timeout, retry, circuit breaker, and quota policy;
- resource limits, packet sizes, row limits, concurrency, and backpressure;
- logging, metrics, retention, redaction, and diagnostics;
- feature flags and capability registrations;
- security policy, allowed hosts, TLS expectations, and SSRF controls;
- environment isolation and safe defaults.

Invalid, ambiguous, conflicting, or incomplete configuration fails closed before execution.

## Secrets

`ISecretProvider` abstracts secret resolution. `.env` and process environment variables are local/CI adapters; a future secret store can implement the same interface. Secret behavior includes scoped access, rotation support, existence validation without value exposure, automatic redaction, secret scanning, and fail-closed missing-secret handling.

Secrets must never enter source control, PostgreSQL Pipeline configuration, configuration hashes, StepLogs, diagnostics, comments, or Project metadata.

## Runtime overrides

Runtime overrides are allowed only through an allowlist. Each override is schema- and range-validated, non-sensitive, audited without exposing secrets, included in the execution hash, assigned an owner, approved according to risk, and given an expiration. Expired or prohibited overrides block execution.

## Runtime reload

Configuration is reloadable by category:

- Safe operational values may reload at a safe boundary.
- Connection, security, contract, and execution semantics require restart or a new session.
- Active executions keep their immutable configuration snapshot.
- Pending changes are validated, audited, and applied only at a safe boundary.

## Drift detection

The system compares effective configuration with an approved baseline. It reports source/overlay hash differences, safe non-sensitive diffs, owner, timestamp, `operationId`, impact, and remediation. Protected environments alert and block on unauthorized drift. Reconciliation and rollback are documented in the Project runbooks.

## Definition of Ready

- Parent Spec and M01-SS03 boundary are accepted.
- Environment names, configuration authority, precedence, secret policy, and protected categories are documented.
- Required schemas, risks, tests, and Project metadata are assigned.
- No unresolved security or configuration ownership conflict blocks implementation.

## Definition of Done

- All four environments are defined with explicit policies and safe defaults.
- Versioned schemas validate complete effective configuration.
- Precedence and value origin are deterministic and observable.
- `ISecretProvider` resolves secrets without exposing or persisting values.
- No secret appears in Git, PostgreSQL, logs, diagnostics, comments, or Project metadata.
- Drift detection, baseline comparison, safe diff, operation IDs, and rollback work.
- Runtime overrides are allowlisted, audited, hashed, and expirable.
- Runtime reload respects safe boundaries and immutable execution snapshots.
- Positive, negative, security, compatibility, isolation, and fail-closed tests pass.
- Documentation, ADRs, Project metadata, and evidence report are synchronized.

## Acceptance criteria

1. A clean Development environment loads through documented configuration sources.
2. Test, Demo, and Production-like profiles validate independently.
3. Precedence produces the same effective configuration for the same inputs.
4. Missing required secrets blocks startup/execution without revealing values.
5. A secret cannot be persisted in Pipeline configuration or StepLog.
6. Unauthorized baseline drift is detected, reported, and blocked in protected environments.
7. Allowed runtime overrides affect the execution hash and are reproducible.
8. Forbidden or expired overrides fail before execution.
9. Active executions retain their initial configuration snapshot after reload.
10. Configuration ambiguity and source conflicts fail closed.

## Expected evidence

- Configuration schema and version matrix
- Environment profile files and safe-default review
- Precedence/origin resolution report
- Secret-provider and redaction test results
- Secret-scan result
- Drift detection and baseline diff report
- Override approval and expiration evidence
- Runtime reload boundary tests
- Configuration hash/reproducibility report
- Documentation, ADR, and Project traceability links
