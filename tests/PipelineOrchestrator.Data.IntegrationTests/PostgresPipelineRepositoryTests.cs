using PipelineOrchestrator.Core.Models;
using PipelineOrchestrator.Data;
using Xunit;

namespace PipelineOrchestrator.Data.IntegrationTests;

public sealed class PostgresPipelineRepositoryTests
{
    [PostgresFact]
    public async Task Repository_round_trips_pipeline_through_postgres()
    {
        var connectionString = Environment.GetEnvironmentVariable(
            "WEAVERXYZ_POSTGRES_CONNECTION_STRING");
        await using var repository = new PostgresPipelineRepository(connectionString!);
        await repository.EnsureSchemaAsync();

        var pipeline = new PipelineDefinition(
            Guid.NewGuid(),
            "orders",
            [new PipelineStep("read", "DataSource")]);

        await repository.UpsertAsync(pipeline);
        var loaded = await repository.FindAsync(pipeline.Id);

        Assert.Equal(pipeline, loaded);
    }
}

internal sealed class PostgresFactAttribute : FactAttribute
{
    public PostgresFactAttribute()
    {
        if (string.IsNullOrWhiteSpace(
                Environment.GetEnvironmentVariable("WEAVERXYZ_POSTGRES_CONNECTION_STRING")))
        {
            Skip = "WEAVERXYZ_POSTGRES_CONNECTION_STRING is not configured.";
        }
    }
}
