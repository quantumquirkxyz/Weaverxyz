namespace PipelineOrchestrator.Core.Contracts;

public interface IPipelineRepository
{
    Task<PipelineDefinition?> FindAsync(Guid id, CancellationToken cancellationToken = default);
}
