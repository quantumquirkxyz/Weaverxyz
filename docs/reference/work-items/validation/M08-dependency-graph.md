# M08 Dependency Graph

```mermaid
flowchart LR
  M01[M01 persistence seam] --> SS01[M08-SS01 Schema + migrations]
  M02M07[M02–M07 records/contracts] --> SS01
  SS01 --> SS02[M08-SS02 Repositories + transactions]
  M01 --> SS02
  M02[M02 contracts] --> SS02
  SS01 --> SS03[M08-SS03 Backup + recovery]
  SS02 --> SS03
  M06[M06 recovery policy] --> SS03
  SS01 --> SS04[M08-SS04 Testing + performance]
  SS02 --> SS04
  SS03 --> SS04
  SS04 --> NEXT[M09 and operations]
```

## Claimable waves

1. Wave 1: M08-SS01.
2. Wave 2: M08-SS02.
3. Wave 3: M08-SS03.
4. Wave 4: M08-SS04.

## Invariants

- No repository bypasses Core contracts or leaks SQL/Npgsql outside Data.
- No migration proceeds with checksum drift or unapproved destructive change.
- Restore must validate integrity and pending migrations before acceptance.
- Retention cannot delete records required for audit/recovery without policy evidence.
- Tickets remain deferred until Sub-Spec acceptance.
