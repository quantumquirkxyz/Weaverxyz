# M02 Provider Preflight and Publication Dry-Run

## Status

**BLOCKED — one Project taxonomy decision required before remote mutation**

## Provider evidence

- Repository: `quantumquirkxyz/Weaverxyz`
- Permission: `ADMIN`
- Default branch: `main`
- Issue Types enabled: `Task`, `Bug`, `Feature`
- Project: `Weaverxyz Engineering Delivery` (#30)
- Project ID: `PVT_kwHOB2Vrws4BtH6J`
- Project repository link: verified for `quantumquirkxyz/Weaverxyz`
- Existing Milestones: M01 only
- Native sub-issue mutations: available
- Project item field updates: available

## Planned remote mutations

Operation ID: `publish-m02-domain-model-contracts-v1`

1. Create Milestone `M02 — Domain Model and Contracts` if absent.
2. Create or reconcile Parent Spec `[Parent Spec][M02] Domain Model and Contracts`.
3. Add Parent Spec to Project #30 and set `Work Type=Parent Spec`, `Priority=Critical`, `Risk=High`, `Phase=Architecture`, `Effort=XL`, `Release Train=MVP`.
4. Create or reconcile six Feature Issues for M02-SS01 through M02-SS06.
5. Add each Issue to Milestone M02 and Project #30.
6. Set native Issue Type `Feature`, labels, assignee, and governed Project fields.
7. Link each Sub-Spec as a native child of the M02 Parent Spec.
8. Post structured English engineering comments.
9. Reconcile Project metadata and emit audit evidence.

## Dry-run mapping

| Semantic item | Planned type | Area | Dependency state |
|---|---|---|---|
| M02 | Parent Spec | Infrastructure or Core boundary review | Ready after M01 acceptance |
| M02-SS01 | Sub-Spec | Core | Ready after M01-SS02 |
| M02-SS02 | Sub-Spec | Core | Blocked by SS01 |
| M02-SS03 | Sub-Spec | Core/Data | Blocked by SS01 |
| M02-SS04 | Sub-Spec | Core | Blocked by SS02 |
| M02-SS05 | Sub-Spec | Core | Blocked by SS02–SS04 |
| M02-SS06 | Sub-Spec | QA/Cross-cutting | Blocked by SS01–SS05 |

## Blocking taxonomy gap

Project #30 `Area` currently supports `UI`, `Core`, `Orchestrator`, `Data`, `Persistence`, `Agent`, `Security`, `Infrastructure`, and `Documentation`. It does not support `QA` or `Cross-cutting`.

Recommended resolution: add `QA` and `Cross-cutting` options before publication. This requires explicit approval because it mutates Project configuration. Do not silently map M02-SS06 to an inaccurate area.

## Approval gate

Remote publication is not authorized until the taxonomy resolution is approved and the dry-run is accepted.
