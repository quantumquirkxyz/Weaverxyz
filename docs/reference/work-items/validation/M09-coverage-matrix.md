# M09 Coverage Matrix

## Parent Spec

`[Parent Spec][M09] AI Agent Integration and Security`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M09-SS01 | Contracts/providers | Versioned AgentCall contracts and governed provider/model registry | M02, M06, M08 | SS02–SS04, M07 |
| M09-SS02 | Security/authorization | Secret-safe data handling and least-privilege authorization | M02, M05, M08, SS01 | SS03–SS04, M07 |
| M09-SS03 | Budgets/resilience/audit | Bounded, resilient, deduplicated and auditable runtime | M06, M08, SS01–SS02 | SS04, M07, operations |
| M09-SS04 | Evaluation/testing | Quality, security, adversarial, performance and human-review gates | SS01–SS03, M07, M08 | Operations and acceptance |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Versioned AgentCall contracts | SS01 | Contract/compatibility report |
| Provider/model registry and allowlists | SS01 | Registry/policy manifest |
| Classification, redaction, secret prohibition | SS02 | Security/redaction report |
| Prompt-injection and exfiltration defense | SS02, SS04 | Adversarial security evidence |
| Least-privilege authorization | SS02 | Capability decision matrix |
| Budgets, retry, fallback, circuit breaker | SS03 | Runtime resilience report |
| Deduplication and cost reconciliation | SS03 | Reconciliation evidence |
| Audit, provenance, hashes, retention | SS03 | Redacted audit export |
| Golden, regression and human-review evaluation | SS04 | Evaluation manifest |
| Integration and quality gates | SS04 | Checksummed test report |

## Boundary review

- M06 owns generic runtime retry, recovery, cancellation, and budgets; M09 specializes these for AgentCall policy and provider behavior.
- M08 owns persistence, retention, audit storage, and evidence durability; M09 owns AgentCall evidence semantics.
- M07 presents AgentCall configuration/status and review workflows; it does not execute provider calls directly.
- M09 must not leak provider SDKs, secrets, or raw sensitive payloads across Core/Data/UI boundaries.
- No uncovered M09 requirement identified.
