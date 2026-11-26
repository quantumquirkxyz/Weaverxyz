using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Data;
using PipelineOrchestrator.Core.Models;
using Xunit;

namespace PipelineOrchestrator.Contracts.Tests;

public sealed class RepositoryContractTests
{
    [Fact]
    public async Task InMemory_repository_implements_pipeline_repository_contract()
    {
        IPipelineRepository repository = new InMemoryPipelineRepository();
        Assert.Null(await repository.FindAsync(Guid.NewGuid()));
    }

    [Fact]
    public void Pipeline_definition_preserves_step_order()
    {
        var pipeline = new PipelineDefinition(Guid.NewGuid(), "ordered",
        [
            new PipelineStep("source", "DataSource"),
            new PipelineStep("sink", "Sink")
        ]);

        Assert.Equal(["source", "sink"], pipeline.Steps.Select(step => step.Name));
    }
}
