using PipelineOrchestrator.Core.Models;
using PipelineOrchestrator.Data;
using Xunit;

namespace PipelineOrchestrator.Data.IntegrationTests;

public sealed class InMemoryPipelineRepositoryTests
{
    [Fact]
    public async Task Returns_seeded_pipeline_by_identity()
    {
        var pipeline = new PipelineDefinition(Guid.NewGuid(), "orders",
            [new PipelineStep("read", "DataSource")]);

        Assert.Equal(pipeline, await new InMemoryPipelineRepository([pipeline]).FindAsync(pipeline.Id));
    }

    [Fact]
    public async Task Returns_null_for_unknown_pipeline()
        => Assert.Null(await new InMemoryPipelineRepository().FindAsync(Guid.NewGuid()));

    [Fact]
    public async Task Honors_cancellation()
    {
        using var source = new CancellationTokenSource();
        source.Cancel();

        await Assert.ThrowsAsync<OperationCanceledException>(
            () => new InMemoryPipelineRepository().FindAsync(Guid.NewGuid(), source.Token));
    }
}
