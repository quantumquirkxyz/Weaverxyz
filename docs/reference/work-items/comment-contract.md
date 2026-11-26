# Work Item Comment Contract

All generated comments must be in English and begin with the event type. Comments are immutable evidence; corrections append a new comment rather than rewriting history.

```markdown
## Engineering Update

**Event:** <event-name>
**Operation ID:** <stable-operation-id>
**Work Item:** <M01-SS01-T01>
**GitHub Issue:** #<number>
**Actor:** <actor>
**Timestamp:** <ISO-8601 timestamp>
**Previous State:** <state>
**New State:** <state>
**Parent:** #<number>
**Sub-Spec:** #<number>
**Milestone:** <milestone>

### Summary
<concise update>

### Evidence
- <link, command, test, artifact, or commit>

### Decisions
- <confirmed decision or none>

### Risks
- <risk, owner, mitigation, trigger, or none>

### Dependencies
- <blocked-by/blocking/none>

### Quality Gates
- <gate>: <pass/fail/waived + evidence>

### Documentation
- <updated documents or none>

### Next Steps
- <specific next action and owner>
```

## Required event types

`created`, `claimed`, `implementation-started`, `scope-changed`, `architecture-decision`, `blocked`, `unblocked`, `pull-request-opened`, `reviewed`, `qa-completed`, `documentation-updated`, `release-ready`, `released`, `closed`, `reconciled`, `governance-conflict`.
