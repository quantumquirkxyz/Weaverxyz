# ADR-004: AI Agent Integration — AgentCall Step via HttpClient, Agent-Agnostic

## Status

Accepted

## Context

Weaverxyz connects to AI Agents because every agent system internally executes pipelines (consult data, process with model, filter results, store, notify). The orchestrator can serve as the infrastructure layer that executes those steps, with the agent being one node in the pipeline.

The `AgentCall` step type must call an external AI agent, but the orchestrator should not be coupled to any specific agent provider (Anthropic Claude, Hermes/OpenClaw local, or a custom REST endpoint). Agent credentials must never be stored in code or in the database.

## Decision

Implement AI agent integration as follows:

- **Step type**: `AgentCall` in the `steps` table (`step_type = 'agent_call'`).
- **Executor**: `StepExecutor` dispatches to an `AgentConnector` when `step_type` is `agent_call`. The connector issues an HTTP request via `HttpClient` to the agent's REST API.
- **Configuration**: Agent settings (endpoint URL, model, prompt template, parameters) are stored in the `config` JSONB column of `step_configs`. Changing from Claude to a local agent is a database configuration change only — no code modification.
- **Supported endpoints**: Anthropic Claude API, local agents (Hermes, OpenClaw on `localhost`), or any JSON-in/JSON-out REST endpoint.
- **Authentication**: API keys and tokens are stored outside the application in a `.env` file (excluded from git) or another secret store. They are injected at runtime, never hardcoded and never persisted in `step_configs`.

## Consequences

### Positive

- Agent-agnostic: the orchestrator works with any REST agent that accepts JSON and returns JSON.
- Configuration-driven: agent selection and parameters change via the database, not code.
- Testable: `AgentConnector` can be mocked or pointed at a local test endpoint.
- Secure: credentials are never in version control or the persistence layer.
- Aligns with the domain claim that the orchestrator can be the infrastructure layer for AI agent pipelines.

### Negative / Trade-offs

- HTTP latency and failure handling (timeouts, retries, circuit breaking) must be implemented in `AgentConnector`.
- JSON schema drift between agent request/response formats must be handled gracefully.
- No built-in authentication abstraction; API keys must be managed securely via `.env` or secret store.

## Alternatives Considered

- **Provider-specific SDKs (Anthropic SDK, etc.)**: Rejected — would couple the orchestrator to specific providers, violating agent-agnosticism.
- **Message queue / event bus**: Deferred — for a desktop demonstrator, direct HTTP via `HttpClient` is simpler; a queue can be added if asynchronous agent calls become necessary.
- **gRPC**: Rejected — REST/JSON is more universally supported by agent providers and easier to debug.
- **Storing API keys in `step_configs.config` JSONB**: Rejected — credentials must never be persisted in the database.

## References

- `CONTEXT.md` — AI Agents section: `AgentCall`, `AgentConnector`, `HttpClient`, `step_configs` JSONB.
- `docs/reference/agents/domain.md` — `AgentConnector` in the design patterns table.
