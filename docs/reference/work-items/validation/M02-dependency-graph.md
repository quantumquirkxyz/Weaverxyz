# M02 Dependency Graph

```mermaid
flowchart LR
  M01[M01 accepted foundation] --> SS01[M02-SS01 DAG]
  SS01 --> SS02[M02-SS02 Step contracts]
  SS01 --> SS03[M02-SS03 DataPacket + lineage]
  SS02 --> SS04[M02-SS04 Capability Registry]
  SS02 --> SS05[M02-SS05 Errors/events + compatibility]
  SS03 --> SS05
  SS04 --> SS05
  SS01 --> SS06[M02-SS06 Verification]
  SS02 --> SS06
  SS03 --> SS06
  SS04 --> SS06
  SS05 --> SS06
  SS06 --> NEXT[M03–M09 consumers]
```

## Claimable waves

1. Wave 1: M02-SS01.
2. Wave 2: M02-SS02 and M02-SS03, after SS01 contracts are accepted.
3. Wave 3: M02-SS04, after SS02 is accepted.
4. Wave 4: M02-SS05, after SS02–SS04 are accepted.
5. Wave 5: M02-SS06, after SS01–SS05 are accepted.

## Invariants

- No dependency cycle exists.
- No Sub-Spec is claimable before its dependencies satisfy DoD.
- M02 does not alter M01 boundaries without an approved ADR.
- M03 consumes M02 contracts and does not redefine them.
- Tickets remain deferred until the corresponding Sub-Spec is accepted.
