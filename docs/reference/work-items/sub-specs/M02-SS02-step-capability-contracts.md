# [Sub-Spec][M02-SS02] Step Capability Contracts

## Work Item Contract

- **Work Type:** Sub-Spec
- **Native Issue Type:** Feature
- **Parent Spec:** `[Parent Spec][M02] Domain Model and Contracts`
- **Milestone:** M02 — Domain Model and Contracts
- **Semantic ID:** M02-SS02
- **Owner:** `quantumquirkxyz`
- **Phase:** Design → Implementation → Verification
- **Status:** Draft
- **Priority:** Critical
- **Risk:** High
- **Area:** Core / Domain
- **Effort:** XL
- **Release Train:** MVP
- **Operation ID:** `sub-spec-weaverxyz-m02-ss02-v1`

## Capability and outcome

Define the complete Step capability contract: identity, category, implementation and contract versions, schemas, typed configuration, security, sensitivity, redaction, reversibility, compensation, idempotency, retry, timeout, circuit breaker, resource, observability, lineage, compatibility, deprecation, and executable validation.

## Dependencies

M01-SS02; M02-SS01

## Scope boundaries

This Sub-Spec consumes M01 foundation contracts and the M02 Parent Spec. It must not duplicate or silently change approved M01 boundaries. It exposes versioned contracts for downstream milestones and keeps implementation details behind the declared domain seam.

## Definition of Ready

- M02 Parent Spec and this Sub-Spec boundary are accepted.
- Dependencies and ownership are resolved.
- Contract, security, compatibility, testing, and evidence expectations are documented.
- Numeric limits and implementation choices required for Tickets are explicit.

## Definition of Done

- The declared contract is implemented, versioned, and validated.
- Positive, negative, compatibility, security, and redaction tests pass.
- Invariants and failure behavior are executable and documented.
- Evidence is reproducible and checksummed.
- ADRs, documentation, Project metadata, and native relationships are synchronized.
- The Sub-Spec is explicitly accepted before Tickets are generated.

## Acceptance criteria

1. The declared capability is represented by a stable versioned contract.
2. Invalid, incompatible, unsafe, ambiguous, or secret-bearing inputs fail closed.
3. Downstream consumers can validate and reproduce the contract without private implementation knowledge.
4. Required compatibility, migration, deprecation, and security behavior is evidenced.
5. The verification strategy produces deterministic results and an artifact manifest.

## Expected evidence

- Contract and domain diagrams
- Versioned C# and JSON Schema manifest
- Positive and negative test output
- Compatibility/security/redaction evidence
- Reproducibility and quality-gate report
- Documentation, ADR, Project, and traceability links
- Contract, schema, policy completeness, security, redaction, compatibility, and negative tests.
