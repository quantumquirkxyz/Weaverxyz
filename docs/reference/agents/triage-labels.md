# Triage Labels

Triage is part of the standard project flow in this repo. It turns incoming issues and PRs into a stable state machine before implementation starts. Every tracked item must carry exactly one label from each applicable dimension below, using the tracker label strings exactly as defined.

## Label dimensions

| Dimension | Purpose |
|---|---|
| `type` | What kind of work the item is |
| `priority` | Urgency and business impact |
| `status` | Workflow / triage state (the five canonical triage roles) |
| `area` | Which part of the system the item touches |
| `effort` | Estimated size / complexity |
| `project` | GitHub Project V2 field values (sprint, quarter, team, roadmap) |

---

### Type labels (`type:`)

| Tracker label | Meaning |
|---|---|
| `type:bug` | A defect or regression in existing behavior |
| `type:feature` | New functionality or capability |
| `type:task` | General work that is not a bug or feature |
| `type:epic` | Large body of work decomposed into child issues |
| `type:story` | User-facing requirement from the product backlog |
| `type:spike` | Time-boxed research or prototype |
| `type:chore` | Maintenance, tooling, dependency updates |
| `type:docs` | Documentation changes only |
| `type:refactor` | Internal code improvement, no behavior change |
| `type:test` | Test addition or improvement |
| `type:security` | Security vulnerability or hardening |
| `type:performance` | Performance optimization |
| `type:dependency` | Third-party dependency change |
| `type:incident` | Production incident or outage |
| `type:question` | Support or usage question |
| `type:proposal` | Design proposal or RFC |
| `type:experiment` | Experiment or A/B test |

---

### Priority labels (`priority:`)

| Tracker label | Meaning | SLA target |
|---|---|---|
| `priority:critical` | Production down or data loss; immediate response | 4 hours |
| `priority:high` | Major feature blocked or severe degradation | 1 business day |
| `priority:medium` | Normal feature work or moderate bug | 1 week |
| `priority:low` | Minor improvement or cosmetic issue | 1 month |
| `priority:backlog` | Deferred indefinitely; revisit next quarter | None |

---

### Status labels (`status:`) — canonical triage roles

| Tracker label | Canonical role | Meaning |
|---|---|---|
| `status:needs-triage` | `needs-triage` | Maintainer needs to evaluate this item |
| `status:needs-info` | `needs-info` | Waiting on reporter for more information |
| `status:ready-for-agent` | `ready-for-agent` | Fully specified, ready for an AFK agent |
| `status:ready-for-human` | `ready-for-human` | Requires human implementation or merge |
| `status:in-progress` | (extension) | Currently being implemented |
| `status:blocked` | (extension) | Blocked by dependency or external factor |
| `status:review` | (extension) | In code review or QA |
| `status:done` | (extension) | Completed and merged / closed |
| `status:wontfix` | `wontfix` | Will not be actioned |
| `status:duplicate` | (extension) | Duplicate of another item |

Every issue carries exactly one `status:*` label. State transitions follow the triage state machine:
`needs-triage` → `needs-info` / `ready-for-agent` / `ready-for-human` / `wontfix` / `duplicate`; `needs-info` → `needs-triage` on reporter response; `ready-for-agent` / `ready-for-human` → `in-progress` → `blocked` / `review` → `done`.

---

### Area labels (`area:`)

| Tracker label | Meaning |
|---|---|
| `area:ui` | Windows Forms presentation layer |
| `area:api` | Core business logic and orchestration engine |
| `area:data` | PostgreSQL persistence and repositories |
| `area:core` | Domain models and shared kernel |
| `area:orchestrator` | Pipeline runner, step executor, error handler |
| `area:agent` | AI Agent integration (AgentConnector, AgentCall step) |
| `area:persistence` | Repositories, migrations, triggers, JSONB schemas |
| `area:presentation` | UI controls, graphics, polling, logs viewer |
| `area:infra` | Build, CI/CD, Visual Studio solution, NuGet |
| `area:docs` | Documentation and ADRs |
| `area:security` | Authentication, secrets, supply chain |

---

### Effort labels (`effort:`)

| Tracker label | Meaning | Story points (approx.) |
|---|---|---|
| `effort:S` | Small; < 1 day | 1–2 |
| `effort:M` | Medium; 1–3 days | 3–5 |
| `effort:L` | Large; 3–10 days | 8–13 |
| `effort:XL` | Extra large; needs decomposition | 20+ |

---

### GitHub Project V2 field labels (`project:`)

| Tracker label | Project field | Meaning |
|---|---|---|
| `project:sprint-1` | Sprint | Current iteration |
| `project:sprint-2` | Sprint | Next iteration |
| `project:sprint-backlog` | Sprint | Icebox / backlog |
| `project:q1-2027` | Quarter | Q1 2027 roadmap |
| `project:q2-2027` | Quarter | Q2 2027 roadmap |
| `project:q3-2027` | Quarter | Q3 2027 roadmap |
| `project:q4-2027` | Quarter | Q4 2027 roadmap |
| `project:team-platform` | Team | Platform engineering team |
| `project:team-orchestrator` | Team | Orchestrator team |
| `project:team-ui` | Team | UI team |
| `project:roadmap-now` | Roadmap | Now / current |
| `project:roadmap-next` | Roadmap | Next / upcoming |
| `project:roadmap-later` | Roadmap | Later / future |

---

### Label usage rules

1. **Every issue must have at least one `type:*`, one `priority:*`, and one `status:*` label.**
2. **Area and effort labels are recommended but not mandatory.**
3. **GitHub Project labels mirror the corresponding Project V2 custom fields** so that the issue sidebar and the Project board stay in sync.
4. **Use the canonical role name first** (`needs-triage`, `needs-info`, `ready-for-agent`, `ready-for-human`, `wontfix`) when a skill mentions a role; use the tracker label (`status:needs-triage`, etc.) second.
5. **Never create ad-hoc labels outside this taxonomy.** If a new dimension is needed, update this file first via `/setup-quirk-skills` or a doc PR.

When a skill mentions a role, use the canonical role name first and the tracker label second if the tracker vocabulary differs.
