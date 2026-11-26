using System.Reflection;
using PipelineOrchestrator.Core.Contracts;

namespace PipelineOrchestrator.UI.Composition;

public static class PipelineCompositionRoot
{
    public static IPipelineRepository CreatePipelineRepository()
    {
        var dataAssembly = Assembly.Load("PipelineOrchestrator.Data");
        var connectionString = Environment.GetEnvironmentVariable(
            "WEAVERXYZ_POSTGRES_CONNECTION_STRING");
        var repositoryName = string.IsNullOrWhiteSpace(connectionString)
            ? "PipelineOrchestrator.Data.InMemoryPipelineRepository"
            : "PipelineOrchestrator.Data.PostgresPipelineRepository";
        var repositoryType = dataAssembly.GetType(
            repositoryName,
            throwOnError: true)!;

        return (IPipelineRepository)(string.IsNullOrWhiteSpace(connectionString)
            ? Activator.CreateInstance(repositoryType)!
            : Activator.CreateInstance(repositoryType, connectionString)!);
    }
}
