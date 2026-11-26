# M03 Dependency Graph

```mermaid
flowchart LR
  M02[M02 accepted contracts] --> SS01[M03-SS01 Authoring]
  SS01 --> SS02[M03-SS02 Preflight]
  SS01 --> SS03[M03-SS03 Lifecycle]
  SS02 --> SS03
  SS02 --> SS04[M03-SS04 Semantic diff]
  SS03 --> SS04
  SS01 --> SS05[M03-SS05 Concurrency + merge]
  SS03 --> SS05
  SS01 --> SS06[M03-SS06 Import/export + gates]
  SS02 --> SS06
  SS03 --> SS06
  SS04 --> SS06
  SS05 --> SS06
  SS06 --> NEXT[M04–M09 consumers]
```

## Claimable waves

1. Wave 1: M03-SS01.
2. Wave 2: M03-SS02.
3. Wave 3: M03-SS03 and M03-SS04.
4. Wave 4: M03-SS05.
5. Wave 5: M03-SS06.

## Invariants

- No dependency cycle exists.
- M03 cannot redefine accepted M02 domain contracts.
- Publication remains blocked until preflight and lifecycle evidence pass.
- Tickets remain deferred until the corresponding Sub-Spec is accepted.
