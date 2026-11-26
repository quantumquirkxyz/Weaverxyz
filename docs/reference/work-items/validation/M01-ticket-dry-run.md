# M01 Ticket Decomposition Dry-Run

Status: **READY FOR GRANULARITY APPROVAL**

Operation: `to-tickets-weaverxyz-m01-v1`

## Proposed vertical Tickets

| ID | Title | Blocked by | Delivery |
|---|---|---|---|
| M01-T01 | Establish reproducible solution and architecture gates | None | Restorable .NET 8 solution, project graph, composition root, deterministic build, and forbidden-dependency checks. |
| M01-T02 | Deliver versioned domain contracts and capability resolution | M01-T01 | Pipeline/Step/DataPacket contracts, schemas, registry resolution, typed errors/events, and contract validation. |
| M01-T03 | Deliver secure environment configuration and secret boundaries | M01-T01, M01-T02 | Versioned environment profiles, precedence, immutable snapshots, secret provider, overrides, drift detection, and fail-closed validation. |
| M01-T04 | Deliver PostgreSQL persistence for the vertical slice | M01-T02, M01-T03 | Initial schema/migrations, repositories, JSONB validation, execution persistence, outbox/idempotency, and integration evidence. |
| M01-T05 | Deliver governed execution and observability foundation | M01-T02, M01-T03, M01-T04 | DAG scheduler, state machine, execution, retry, compensation, cancellation, recovery, budgets, events, and diagnostics. |
| M01-T06 | Prove the integrated desktop vertical slice and release gates | M01-T01, M01-T02, M01-T03, M01-T04, M01-T05 | Windows Forms journey, source/transform/sink flows, negative/resilience scenarios, accessibility/security/performance gates, evidence manifest, and rollback readiness. |

## Waves

- Wave 0: M01-T01
- Wave 1: M01-T02
- Wave 2: M01-T03
- Wave 3: M01-T04
- Wave 4: M01-T05
- Wave 5: M01-T06

## Approval questions

1. Is six Tickets the right granularity?
2. Are the blocking edges genuine and minimal?
3. Should any Ticket be split or merged before publication?

No GitHub Ticket Issues or Project items were created by this dry-run.
