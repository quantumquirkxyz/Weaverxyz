using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Data;

namespace PipelineOrchestrator.Core.Orchestration;

public sealed class PipelineApplication
{
    public static PipelineApplication CreateDefault()
        => new(new InMemoryPipelineRepository());

    public PipelineApplication(IPipelineRepository pipelines)
        => Pipelines = pipelines ?? throw new ArgumentNullException(nameof(pipelines));

    public IPipelineRepository Pipelines { get; }
}
