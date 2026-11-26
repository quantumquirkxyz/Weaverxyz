# M02 Ticket Decomposition Dry-Run

Status: **READY FOR GRANULARITY APPROVAL**

Operation: `to-tickets-weaverxyz-m02-v1`

## Proposed vertical Tickets

| ID | Title | Blocked by | Delivery |
|---|---|---|---|
| M02-T01 | Deliver versioned Pipeline DAG and subpipeline contracts | M01-T06 (#66) | Immutable Pipeline DAG, subpipeline boundaries, identity, reachability, acyclicity, topological validity, and definition hashes. |
| M02-T02 | Deliver complete Step capability contracts | M02-T01 | Step metadata, schemas, policies, reversibility, compensation, idempotency, retry, limits, sensitivity, and observability contracts. |
| M02-T03 | Deliver DataPacket schemas, lineage, and redaction | M02-T02 | Tabular/document envelopes, schema alignment, lineage, hashes, sensitivity, redaction, cancellation context, and limits. |
| M02-T04 | Deliver historical capability registry resolution | M02-T02, M02-T03 | Typed registration, factories, categories, version resolution, deprecation state, and historical reproduction. |
| M02-T05 | Deliver typed errors, events, and compatibility governance | M02-T01, M02-T02, M02-T03, M02-T04 | Result/errors, immutable correlated events, adapters, migrations, compatibility matrices, deprecation, and breaking-change review. |
| M02-T06 | Prove domain contract quality and compatibility gates | M02-T01, M02-T02, M02-T03, M02-T04, M02-T05 | Property, serialization, fuzzing, redaction, idempotency, compensation, compatibility, and negative-test evidence. |

## Waves

- Wave 0: M02-T01
- Wave 1: M02-T02
- Wave 2: M02-T03 and M02-T04
- Wave 3: M02-T05
- Wave 4: M02-T06

## Approval questions

1. Is six Tickets the right granularity?
2. Are the blocking edges genuine and minimal?
3. Should any Ticket be split or merged before publication?

No GitHub Ticket Issues or Project items were created by this dry-run.
