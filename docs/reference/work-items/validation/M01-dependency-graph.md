# M01 Dependency Graph

```mermaid
flowchart LR
  SS01[M01-SS01\nBoundaries] --> SS02[M01-SS02\nContracts]
  SS01 --> SS03[M01-SS03\nConfiguration]
  SS02 --> SS03
  SS01 --> SS04[M01-SS04\nPersistence]
  SS02 --> SS04
  SS03 --> SS04
  SS01 --> SS05[M01-SS05\nExecution]
  SS02 --> SS05
  SS03 --> SS05
  SS04 --> SS05
  SS01 --> SS06[M01-SS06\nE2E + Gates]
  SS02 --> SS06
  SS03 --> SS06
  SS04 --> SS06
  SS05 --> SS06
  SS06 --> M02[M02]
```

## Claimable waves

1. **Wave 1:** M01-SS01.
2. **Wave 2:** M01-SS02.
3. **Wave 3:** M01-SS03.
4. **Wave 4:** M01-SS04.
5. **Wave 5:** M01-SS05.
6. **Wave 6:** M01-SS06.

The strict sequence is intentional: each Sub-Spec establishes contracts consumed by the next. Parallel Tickets may be introduced inside a Sub-Spec only when their local dependencies permit it.

## Invariants

- No cycle exists.
- No Sub-Spec is claimable before its dependencies satisfy DoD.
- SS06 cannot start integration until SS01–SS05 provide accepted contracts.
- M02 cannot start from M01 until SS06 release evidence is accepted.
