using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Models;
using PipelineOrchestrator.Data;
using Xunit;

namespace PipelineOrchestrator.Data.IntegrationTests;

public sealed class DataBoundaryTests
{
    [Fact]
    public async Task Core_pipeline_repository_contract_is_reachable()
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
