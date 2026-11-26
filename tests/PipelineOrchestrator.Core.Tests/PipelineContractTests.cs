using PipelineOrchestrator.Core.Data;
using PipelineOrchestrator.Core.Models;
using PipelineOrchestrator.Core.Orchestration;
using Xunit;

namespace PipelineOrchestrator.Core.Tests;

public sealed class PipelineContractTests
{
    [Fact]
    public async Task Repository_returns_seeded_pipeline_by_identity()
    {
        var pipeline = new PipelineDefinition(Guid.NewGuid(), "orders",
            [new PipelineStep("read", "DataSource")]);
        var repository = new InMemoryPipelineRepository([pipeline]);

        Assert.Equal(pipeline, await repository.FindAsync(pipeline.Id));
    }

    [Fact]
    public async Task Repository_returns_null_for_unknown_pipeline()
        => Assert.Null(await new InMemoryPipelineRepository().FindAsync(Guid.NewGuid()));

    [Fact]
    public async Task Repository_honors_cancellation()
    {
        using var source = new CancellationTokenSource();
        source.Cancel();

        await Assert.ThrowsAsync<OperationCanceledException>(
            () => new InMemoryPipelineRepository().FindAsync(Guid.NewGuid(), source.Token));
    }

    [Fact]
    public void Application_requires_an_explicit_repository()
        => Assert.Throws<ArgumentNullException>(() => new PipelineApplication(null!));
}
