using System.Text.Json;
using Npgsql;
using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Models;

namespace PipelineOrchestrator.Data;

public sealed class PostgresPipelineRepository : IPipelineRepository
{
    private readonly NpgsqlDataSource dataSource;

    public PostgresPipelineRepository(string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);
        dataSource = NpgsqlDataSource.Create(connectionString);
    }

    public async Task EnsureSchemaAsync(CancellationToken cancellationToken = default)
    {
        await using var command = dataSource.CreateCommand("""
            CREATE TABLE IF NOT EXISTS pipelines (
                id uuid PRIMARY KEY,
                name text NOT NULL,
                steps jsonb NOT NULL
            )
            """);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task<PipelineDefinition?> FindAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await using var command = dataSource.CreateCommand(
            "SELECT name, steps FROM pipelines WHERE id = $1");
        command.Parameters.AddWithValue(id);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        var steps = JsonSerializer.Deserialize<PipelineStep[]>(
            reader.GetFieldValue<string>(1)) ?? [];
        return new PipelineDefinition(id, reader.GetString(0), steps);
    }

    public async Task UpsertAsync(
        PipelineDefinition pipeline,
        CancellationToken cancellationToken = default)
    {
        var steps = JsonSerializer.Serialize(pipeline.Steps);
        await using var command = dataSource.CreateCommand("""
            INSERT INTO pipelines (id, name, steps)
            VALUES ($1, $2, $3::jsonb)
            ON CONFLICT (id) DO UPDATE
            SET name = EXCLUDED.name, steps = EXCLUDED.steps
            """);
        command.Parameters.AddWithValue(pipeline.Id);
        command.Parameters.AddWithValue(pipeline.Name);
        command.Parameters.AddWithValue(steps);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync() => await dataSource.DisposeAsync();
}
