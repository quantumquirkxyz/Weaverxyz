# M09 Dependency Graph

```mermaid
flowchart LR
  M02[M02 contracts/capabilities] --> SS01[M09-SS01 Contracts + providers]
  M06[M06 runtime seams] --> SS01
  M08[M08 persistence] --> SS01
  SS01 --> SS02[M09-SS02 Security + authorization]
  M05[M05 classification/redaction] --> SS02
  M02 --> SS02
  M08 --> SS02
  SS01 --> SS03[M09-SS03 Budgets + resilience + audit]
  SS02 --> SS03
  M06 --> SS03
  M08 --> SS03
  SS01 --> SS04[M09-SS04 Evaluation + testing]
  SS02 --> SS04
  SS03 --> SS04
  M07[M07 review workflows] --> SS04
  M08 --> SS04
  SS04 --> NEXT[Operations and acceptance]
```

## Claimable waves

1. Wave 1: M09-SS01.
2. Wave 2: M09-SS02.
3. Wave 3: M09-SS03.
4. Wave 4: M09-SS04.

## Invariants

- Unregistered providers/models and absent authorization fail closed.
- Secrets and unsafe sensitive payloads never cross the provider boundary.
- Invalid responses are quarantined rather than treated as successful.
- Retries and fallbacks cannot duplicate external effects or bypass budgets.
- Audit evidence is redacted, correlated, retained, and reconciled.
- High-impact effects require configured human review.
- Tickets remain deferred until Sub-Spec acceptance.
