# M06 Dependency Graph

```mermaid
flowchart LR
  M01[M01 execution seams] --> SS01[M06-SS01 Scheduler + states]
  M02[M02 contracts] --> SS01
  M03[M03 definitions] --> SS01
  M05[M05 outcomes] --> SS01
  SS01 --> SS02[M06-SS02 Retry + resilience]
  M04[M04 effects] --> SS02
  M02 --> SS02
  M05 --> SS02
  SS01 --> SS03[M06-SS03 Rollback + recovery]
  SS02 --> SS03
  M01 --> SS03
  M04 --> SS03
  M05 --> SS03
  SS01 --> SS04[M06-SS04 Testing]
  SS02 --> SS04
  SS03 --> SS04
  SS04 --> NEXT[M07–M09 consumers]
```

## Claimable waves

1. Wave 1: M06-SS01.
2. Wave 2: M06-SS02.
3. Wave 3: M06-SS03.
4. Wave 4: M06-SS04.

## Invariants

- Runtime retry and recovery cannot bypass M02 idempotency/compensation contracts.
- Compensation failures preserve original failure context and residual risk.
- Recovery never restarts uncertain effects blindly.
- M07 consumes runtime state/events and does not redefine them.
- Tickets remain deferred until Sub-Spec acceptance.
