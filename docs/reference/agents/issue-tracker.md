# Issue tracker: GitHub

Issues and PRDs for this repo live as GitHub issues in `quantumquirkxyz/Weaverxyz`. Use the `gh` CLI for all operations. Everything tracked natively in GitHub must be available: all fields, dates, priorities, issue types, and GitHub Project fields.

## GitHub native fields — tracked and prepared

Every issue must have the following GitHub-native metadata populated and kept in sync:

| Field | Source | Purpose |
|---|---|---|
| `number` | GitHub | Immutable issue identifier |
| `title` | `gh issue create --title` | Short summary |
| `body` | `gh issue create --body` | Full description, repro steps, acceptance criteria |
| `state` | `open` / `closed` | Lifecycle state |
| `labels` | `gh issue edit --add-label` / `--remove-label` | Type, priority, status, area, effort, project (see `triage-labels.md`) |
| `assignees` | `gh issue edit --add-assignee` | Person(s) responsible |
| `reviewers` | `gh pr edit --add-reviewer` | Code reviewers (on linked PRs) |
| `milestone` | `gh issue edit --milestone` | Release or version target |
| `projects` | `gh api` / Project V2 | GitHub Project board membership |
| `created_at` | GitHub (auto) | When the issue was opened |
| `updated_at` | GitHub (auto) | Last activity timestamp |
| `closed_at` | GitHub (auto) | When the issue was closed |
| `due_date` | `gh issue edit --due-date` | Target completion date |
| `author` | GitHub (auto) | Issue opener |
| `reactions` | GitHub (auto) | Team sentiment signal |
| `comments` | `gh issue comment` / `--comments` | Discussion history |

### Dates — all must be available

- **`created_at`** — when the issue was created (GitHub auto)
- **`updated_at`** — last modification (GitHub auto)
- **`closed_at`** — when closed (GitHub auto)
- **`due_date`** — target date, set via `gh issue edit --due-date YYYY-MM-DD`
- **`started_at`** — when work began (recorded as a comment or Project V2 date field)
- **`completed_at`** — when finished (recorded as a comment or Project V2 date field)

### Priorities — tracked via `priority:*` labels

See `triage-labels.md` for `priority:critical`, `priority:high`, `priority:medium`, `priority:low`, `priority:backlog`. These mirror GitHub Project V2 single-select priority fields.

### Issue types — tracked via `type:*` labels

See `triage-labels.md` for `type:bug`, `type:feature`, `type:task`, `type:epic`, `type:story`, `type:spike`, `type:chore`, `type:docs`, `type:refactor`, `type:test`, `type:security`, `type:performance`, `type:dependency`, `type:incident`, `type:question`, `type:proposal`, `type:experiment`. These mirror GitHub Project V2 single-select type fields.

### GitHub Project fields — tracked via `project:*` labels

See `triage-labels.md` for sprint, quarter, team, and roadmap labels. These mirror GitHub Project V2 single-select fields so the issue sidebar and Project board stay in sync.

## Conventions

- **Create an issue**: `gh issue create --title "..." --body "..." --label "type:feature" --label "priority:high" --label "status:needs-triage" --assignee @me --milestone "v1.0"`. Use a heredoc for multi-line bodies.
- **Read an issue**: `gh issue view <number> --comments`, filtering comments by `jq` and also fetching labels.
- **List issues**: `gh issue list --state open --json number,title,body,labels,assignees,milestone,createdAt,updatedAt,dueDate,comments --jq '...'` with appropriate `--label`, `--state`, `--assignee`, `--milestone` filters.
- **Comment on an issue**: `gh issue comment <number> --body "..."`
- **Apply / remove labels**: `gh issue edit <number> --add-label "..."` / `--remove-label "..."`
- **Close**: `gh issue close <number> --comment "..."`
- **Reopen**: `gh issue reopen <number>`

Infer the repo from `git remote -v` — `gh` does this automatically when run inside a clone.

## Pull requests as a triage surface

**PRs as a request surface: no.** _(Set to `yes` if this repo treats external PRs as feature requests; `/triage` reads this flag.)_

When set to `yes`, PRs run through the same labels and states as issues, using the `gh pr` equivalents:

- **Read a PR**: `gh pr view <number> --comments` and `gh pr diff <number>` for the diff.
- **List external PRs for triage**: `gh pr list --state open --json number,title,body,labels,author,authorAssociation,comments` then keep only `authorAssociation` of `CONTRIBUTOR`, `FIRST_TIME_CONTRIBUTOR`, or `NONE` (drop `OWNER`/`MEMBER`/`COLLABORATOR`).
- **Comment / label / close**: `gh pr comment`, `gh pr edit --add-label`/`--remove-label`, `gh pr close`.

GitHub shares one number space across issues and PRs, so a bare `#42` may be either — resolve with `gh pr view 42` and fall back to `gh issue view 42`.

## When a skill says "publish to the issue tracker"

Create a GitHub issue with all native fields populated: type, priority, status, area, effort, project labels; assignee; milestone; due date; and full body with acceptance criteria.

## When a skill says "fetch the relevant ticket"

Run `gh issue view <number> --comments` and inspect all labels, assignees, milestone, dates, and linked development.

## Development linkage

- **Issue-linked development branch**: `gh issue develop <number>` creates a branch from the issue.
- **Link PR to issue**: `gh pr create --body "Closes #<number>"` or `gh issue edit <number> --add-label "ready-for-review"`.
- **Cross-reference**: use `#<number>` in PR descriptions and commit messages to auto-link.

## Wayfinding operations

Used by `/wayfinder`. The **map** is a single issue with **child** issues as tickets.

- **Map**: a single issue labelled `wayfinder:map`, holding the Notes / Decisions-so-far / Fog body. `gh issue create --label wayfinder:map`.
- **Child ticket**: an issue linked to the map as a GitHub sub-issue (`gh api` on the sub-issues endpoint). Where sub-issues aren't enabled, add the child to a task list in the map body and put `Part of #<map>` at the top of the child body. Labels: `wayfinder:<type>` (`research`/`prototype`/`grilling`/`task`). Once claimed, the ticket is assigned to the driving dev.
- **Blocking**: GitHub's **native issue dependencies** — the canonical, UI-visible representation. Add an edge with `gh api --method POST repos/<owner>/<repo>/issues/<child>/dependencies/blocked_by -F issue_id=<blocker-db-id>`, where `<blocker-db-id>` is the blocker's numeric **database id** (`gh api repos/<owner>/<repo>/issues/<n> --jq .id`, _not_ the `#number` or `node_id`). GitHub reports `issue_dependencies_summary.blocked_by` (open blockers only — the live gate). Where dependencies aren't available, fall back to a `Blocked by: #<n>, #<n>` line at the top of the child body. A ticket is unblocked when every blocker is closed.
- **Frontier query**: list the map's open children (`gh issue list --state open`, scoped to the map's sub-issues / task list), drop any with an open blocker (`issue_dependencies_summary.blocked_by > 0`, or an open issue in the `Blocked by` line) or an assignee; first in map order wins.
- **Claim**: `gh issue edit <n> --add-assignee @me` — the session's first write.
- **Resolve**: `gh issue comment <n> --body "<answer>"`, then `gh issue close <n>`, then append a context pointer (gist + link) to the map's Decisions-so-far.

## Defaults

- Default tracker labels for spec publication: `type:spec`, `status:ready-for-agent`, `priority:medium`.
- Default tracker labels for tickets: `status:ready-for-agent` plus any justified area, effort, type, priority, and project labels inherited from the source spec.
- Keep assignees, labels, milestones, project items, relationships, development branches, and Project V2 fields aligned with the canonical work-item format (`docs/reference/agents/work-item-format.md`).

## Wayfinding operations

- `to-spec` publishes one spec issue.
- `to-tickets` publishes tracer-bullet tickets with explicit blockers.
- `publish-open-pr` publishes a prepared branch as a PR.
- `ship-subissue` merges a clean subissue PR and closes the linked issue when needed.

## Notes

- PRs are not treated as a general request surface unless a skill explicitly says so.
- All GitHub-native fields (dates, priorities, types, Project fields) must remain available in the issue sidebar and Project V2 board at all times.
