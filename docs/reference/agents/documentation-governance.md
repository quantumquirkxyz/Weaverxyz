# Documentation Governance

## Documentation types

| Location | Purpose | Owner |
|---|---|---|
| `README.md` | Onboarding and project orientation | `quantumquirkxyz` initially |
| `CONTEXT.md` | Stable domain vocabulary and boundaries | `quantumquirkxyz` initially |
| `docs/adr/` | Durable architecture decisions | Architecture role |
| `docs/theory/` | Software Engineering and domain theory | Documentation role |
| `docs/how-to/` | Repeatable procedures | Documentation role |
| `docs/reference/` | Contracts, metadata, governance, and configuration | Maintainer role |
| `docs/runbooks/` | Operational recovery and response | Operations role |
| `docs/architecture/` | Diagram sources and architecture maps | Architecture role |

Owners are role-based initially; `quantumquirkxyz` is the operational owner and backup until additional maintainers are explicitly assigned.

## Rules

- All repository documentation is written in English.
- Every durable decision requires an ADR with status, context, decision, consequences, alternatives, and references.
- Every public term must exist in `CONTEXT.md` or be flagged as a glossary gap.
- Diagrams are maintained as source code and validated/generated in CI.
- Documentation changes link to their issue and update the relevant Project metadata.
- Stale documents are marked and scheduled for review; historical records are archived, not silently deleted.
