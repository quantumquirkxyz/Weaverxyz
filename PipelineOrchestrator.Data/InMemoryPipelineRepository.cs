using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Models;

namespace PipelineOrchestrator.Data;

public sealed class InMemoryPipelineRepository : IPipelineRepository
{
    private readonly IReadOnlyDictionary<Guid, PipelineDefinition> pipelines;

    public InMemoryPipelineRepository(IEnumerable<PipelineDefinition>? seed = null)
        => pipelines = (seed ?? []).ToDictionary(pipeline => pipeline.Id);

    public Task<PipelineDefinition?> FindAsync(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        pipelines.TryGetValue(id, out var pipeline);
        return Task.FromResult(pipeline);
    }
}
