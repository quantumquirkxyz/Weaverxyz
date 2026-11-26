# M05 Dependency Graph

```mermaid
flowchart LR
  M02[M02 contracts] --> SS01[M05-SS01 Transformations]
  M03[M03 definitions] --> SS01
  M04[M04 connector outputs] --> SS01
  SS01 --> SS02[M05-SS02 Validators]
  M02 --> SS02
  M04 --> SS02
  SS01 --> SS03[M05-SS03 Processing Engine]
  SS02 --> SS03
  M01[M01 execution seams] --> SS03
  SS01 --> SS04[M05-SS04 Testing]
  SS02 --> SS04
  SS03 --> SS04
  SS04 --> NEXT[M06–M09 consumers]
```

## Claimable waves

1. Wave 1: M05-SS01.
2. Wave 2: M05-SS02.
3. Wave 3: M05-SS03.
4. Wave 4: M05-SS04.

## Invariants

- Transformations and validators use accepted M02 contracts and do not bypass the registry.
- Critical quality/security failures cannot be hidden by collect-all or quarantine policy.
- Processing budgets fail closed.
- M06 owns orchestration-level retry/rollback/recovery, while M05 owns processing outcomes.
- Tickets remain deferred until Sub-Spec acceptance.
