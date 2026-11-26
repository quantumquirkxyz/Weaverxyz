# Objectives and Success Criteria

## Objectives

| Objective | Evidence |
|---|---|
| Demonstrate Software Engineering principles | ADR-to-code-to-test traceability, architecture checks, quality gates |
| Execute functional pipelines | End-to-end pipeline scenarios with sources, transforms, AgentCall, sinks |
| Preserve reproducibility | Immutable versions, definition hashes, contracts, migrations, environment identity |
| Provide operational visibility | Live state, structured StepLogs, metrics, comparison, diagnostic export |
| Protect data and integrations | Threat model, secret handling, redaction, retention, SSRF and payload controls |
| Support maintainable evolution | Layer boundaries, open Step registry, Repository/Strategy interfaces, ADR governance |
| Operate through GitHub Project | Complete metadata, forms, workflows, reconciliation, audit and rollback |

## Quality budgets

Every phase has baseline gates: build, static analysis, unit tests, required integration tests, secret scanning, documentation validation, and traceability. Additional gates activate by `Risk`, `Type`, `Area`, and `Phase`.

Exceptions require an owner, rationale, compensating control, expiry date, and explicit approval. Expired exceptions block completion.

## Academic evidence

Each design pattern must link to a domain problem, ADR, implementation classes/interfaces, execution flow, tests, diagram, issue/PR, and documented trade-offs. Naming a pattern without executable evidence is insufficient.

## Explicit non-goals for initial phases

Multi-user collaboration, distributed execution, high availability, external scheduling, queues, cloud deployment, and native cross-platform UI are not initial MVP commitments.
