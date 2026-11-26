# M08 Coverage Matrix

## Parent Spec

`[Parent Spec][M08] PostgreSQL Persistence and Migrations`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M08-SS01 | Schema/migrations | Complete relational model and governed evolution | M01, M02–M07 records | SS02, SS03, SS04 |
| M08-SS02 | Repositories/transactions | Aggregate persistence and durable boundaries | SS01, M01, M02 | SS03, M06, M07, M09 |
| M08-SS03 | Backup/recovery | Restore, RPO/RTO, retention, abandoned-run recovery | SS01, SS02, M06 | M07, M09 |
| M08-SS04 | Testing/performance | Persistence quality, performance, security evidence | SS01–SS03 | M09 and operations |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Relational schema and invariants | SS01 | ERD/constraint report |
| Checksummed migrations and drift | SS01 | Migration/checksum report |
| JSONB validation/redaction | SS01, SS02 | Schema/redaction evidence |
| Aggregate repositories and transactions | SS02 | Contract/transaction report |
| Outbox/idempotency/concurrency | SS02 | Reconciliation evidence |
| Backup/restore/RPO/RTO | SS03 | Restore/runbook report |
| Retention and abandoned-run recovery | SS03 | Recovery/retention evidence |
| Query plans and performance | SS04 | EXPLAIN/baseline report |
| Persistence quality gates | SS04 | Checksummed test manifest |

## Boundary review

- M06 owns runtime recovery policy; M08 persists recovery state and executes persistence reconciliation.
- M07 consumes application/repository contracts; it does not access SQL/Npgsql.
- M08 owns PostgreSQL implementation, migrations, retention, restore, and persistence evidence.
- M09 consumes secure persistence/configuration seams for AgentCall evidence.
- No uncovered M08 requirement identified.
