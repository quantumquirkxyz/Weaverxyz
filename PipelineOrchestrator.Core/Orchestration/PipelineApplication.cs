using PipelineOrchestrator.Core.Contracts;

namespace PipelineOrchestrator.Core.Orchestration;

public sealed class PipelineApplication
{
    public PipelineApplication(IPipelineRepository pipelines)
        => Pipelines = pipelines ?? throw new ArgumentNullException(nameof(pipelines));

    public IPipelineRepository Pipelines { get; }
}
