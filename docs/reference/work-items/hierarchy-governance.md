# Work Item Hierarchy Governance

## Canonical hierarchy

```text
Milestone
└── Parent Spec (GitHub Issue)
    └── Sub-Spec (GitHub sub-issue)
        └── Ticket (GitHub sub-issue)
```

All three levels are GitHub Issues. Native Milestones and native parent/sub-issue relationships are the operational source of truth. The issue body repeats stable semantic identifiers for validation, but never replaces native relationships.

## Product roadmap milestones

| ID | Milestone | Parent Spec |
|---|---|---|
| M01 | Foundation and Architecture | one root Parent Spec |
| M02 | Domain Model and Contracts | one root Parent Spec |
| M03 | Pipeline Definition and Versioning | one root Parent Spec |
| M04 | Source and Sink Connectors | one root Parent Spec |
| M05 | Transformation and Validation Engine | one root Parent Spec |
| M06 | Execution, Retry, Rollback, and Recovery | one root Parent Spec |
| M07 | Windows Forms UI and Accessibility | one root Parent Spec |
| M08 | PostgreSQL Persistence and Migrations | one root Parent Spec |
| M09 | AI Agent Integration and Security | one root Parent Spec |
| M10 | Observability, Verification, Documentation, and Release | one root Parent Spec |

Each Milestone has exactly one root Parent Spec by default. Additional Parent Specs require an approved exception with bounded-context, ownership, lifecycle, release, and risk justification.

## Parent Spec

A Parent Spec is the source of truth for one Milestone. It must define objective, users, scope/exclusions, requirements, non-functional requirements, domain model, architecture, contracts, dependencies, risks, security, observability, testing, documentation, roadmap, DoR, DoD, acceptance criteria, and expected evidence.

## Sub-Spec

A Sub-Spec is a governed end-to-end vertical slice. It must define its Parent Spec, capability boundary, domain and architecture impact, contracts, data/migrations, security, observability, dependencies, risks, tests, documentation, descendant Tickets, DoR, DoD, and end-to-end acceptance criteria.

## Ticket

A Ticket is a claimable, independently verifiable unit of delivery. It may implement code, tests, contracts, migrations, security controls, documentation, or integration. It must not be a vague task or merely a list of files.

## Work Type and native Issue Type

GitHub native Issue Type expresses the general classification. Project V2 `Work Type` expresses hierarchy: `Parent Spec`, `Sub-Spec`, or `Ticket`. Specialized Ticket variants use native types such as Bug, Test, Documentation, Security, Migration, or Task.

## Closure rules

- A Ticket closes only after its DoD and evidence are verified.
- A Sub-Spec completes only when required descendant Tickets, gates, documentation, and evidence are complete.
- A Parent Spec completes only when required Sub-Specs and milestone-level evidence are complete.
- Conflicts, missing relationships, failed gates, stale documentation, or missing comments block closure.

## Comments

All comments are written in English using the engineering update schema in `comment-contract.md`. Initial comments are generated at creation; checkpoint comments are required for claim, implementation start, scope change, architecture decision, block/unblock, PR, review, QA, documentation, release, closure, and reconciliation conflict.
