# M04 Ticket Decomposition Dry-Run

Status: **READY FOR GRANULARITY APPROVAL**

Operation: `to-tickets-weaverxyz-m04-v1`

## Proposed vertical Tickets

| ID | Title | Blocked by | Delivery |
|---|---|---|---|
| M04-T01 | Deliver governed file source and sink connectors | M03-T06 (#78) | FileSource/FileSink with allowlists, traversal protection, schemas, streaming, limits, atomic staging/commit, idempotency, cleanup, rollback, redaction, and observability. |
| M04-T02 | Deliver governed PostgreSQL source and sink connectors | M03-T06 (#78) | PostgresSource/PostgresSink with secret provider, TLS/allowlists, parameterized access, batching, transactions, staging/upsert, idempotency, compensation, query plans, and safe diagnostics. |
| M04-T03 | Deliver governed HTTP and report connectors | M03-T06 (#78) | HttpSource and ReportSink with SSRF/TLS/host controls, limits, pagination, safe retry, circuit breaker, redaction, validated templates, checksums, atomic output, and accessibility evidence. |
| M04-T04 | Prove connector security, resilience, and quality gates | M04-T01, M04-T02, M04-T03 | Contract, integration, fault-injection, security, secret, performance, query-plan, recovery, reproducibility, and cross-connector evidence. |

## Waves

- Wave 0: M04-T01, M04-T02, M04-T03
- Wave 1: M04-T04

## Approval questions

1. Is four Tickets the right granularity?
2. Are the blocking edges genuine and minimal?
3. Should any Ticket be split or merged before publication?

No GitHub Ticket Issues or Project items were created by this dry-run.
