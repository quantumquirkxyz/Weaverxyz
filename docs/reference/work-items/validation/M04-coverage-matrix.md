# M04 Coverage Matrix

## Parent Spec

`[Parent Spec][M04] Source and Sink Connectors`

| Sub-Spec | Primary concern | Required outcome | Depends on | Consumers |
|---|---|---|---|---|
| M04-SS01 | File connectors | Safe FileSource/FileSink platform | M02, M03 | M05, M06, M07 |
| M04-SS02 | PostgreSQL connectors | Secure transactional source/sink platform | M01 persistence, M02, M03 | M05, M06, M08 |
| M04-SS03 | HTTP/report connectors | SSRF-safe HTTP and governed reports | M02 security, M03 packages | M05, M06, M07, M09 |
| M04-SS04 | Connector testing | Cross-connector quality gates and evidence | SS01–SS03 | M05–M09 |

## Requirement coverage

| Requirement | Verifying Sub-Spec | Evidence |
|---|---|---|
| Common connector contract and lifecycle | SS01–SS03 | Contract and lifecycle tests |
| File CSV/JSON operations | SS01 | Fixture, schema, atomic-write report |
| PostgreSQL source/sink operations | SS02 | Integration, transaction, query-plan report |
| HTTP SSRF-safe ingestion | SS03 | SSRF/security/resilience report |
| Governed report output | SS03 | Redaction, integrity, accessibility report |
| Idempotency, compensation, limits, resilience | SS01–SS03 | Fault/recovery evidence |
| Cross-connector quality gates | SS04 | Checksummed test matrix |

## Boundary review

- M02 owns capability, DataPacket, schema, error, event, sensitivity, and resilience contracts.
- M03 owns Pipeline authoring and publication lifecycle.
- M04 owns connector implementations and external-system safety.
- M05 owns transforms and validators consuming connector outputs.
- No uncovered M04 requirement identified.
