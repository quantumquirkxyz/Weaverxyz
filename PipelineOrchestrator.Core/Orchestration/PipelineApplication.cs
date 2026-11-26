using PipelineOrchestrator.Core.Contracts;

namespace PipelineOrchestrator.Core.Orchestration;

public sealed class PipelineApplication(IPipelineRepository pipelines)
{
    public IPipelineRepository Pipelines { get; } = pipelines;
}
