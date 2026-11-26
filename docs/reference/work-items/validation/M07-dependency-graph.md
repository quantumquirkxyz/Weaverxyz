# M07 Dependency Graph

```mermaid
flowchart LR
  M01[M01 UI boundary] --> SS01[M07-SS01 Shell]
  M02M06[M02–M06 contracts/events] --> SS01
  SS01 --> SS02[M07-SS02 Editor + config]
  M03[M03 authoring] --> SS02
  M04M05[M04/M05 policies] --> SS02
  M06[M06 runtime] --> SS03[M07-SS03 Monitor + diagnostics]
  M08[M08 persistence] --> SS03
  SS01 --> SS04[M07-SS04 Accessibility + testing]
  SS02 --> SS04
  SS03 --> SS04
  SS04 --> NEXT[M08–M09 consumers]
```

## Claimable waves

1. Wave 1: M07-SS01.
2. Wave 2: M07-SS02 and M07-SS03 after their declared contracts are available.
3. Wave 3: M07-SS04.

## Invariants

- UI never bypasses Core or accesses SQL/Npgsql directly.
- Designer-generated code remains isolated.
- Runtime events and states are displayed, not redefined, by UI.
- Accessibility gates block completion when critical barriers remain.
- Tickets remain deferred until Sub-Spec acceptance.
