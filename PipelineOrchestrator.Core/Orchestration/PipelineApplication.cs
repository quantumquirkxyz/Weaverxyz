using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Data;

namespace PipelineOrchestrator.Core.Orchestration;

public sealed class PipelineApplication
{
    public IPipelineRepository Pipelines { get; } = new InMemoryPipelineRepository();
}
