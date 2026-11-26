using System.Reflection;
using PipelineOrchestrator.Core.Contracts;

namespace PipelineOrchestrator.UI.Composition;

public static class PipelineCompositionRoot
{
    public static IPipelineRepository CreatePipelineRepository()
    {
        var dataAssembly = Assembly.Load("PipelineOrchestrator.Data");
        var repositoryType = dataAssembly.GetType(
            "PipelineOrchestrator.Data.InMemoryPipelineRepository",
            throwOnError: true)!;

        return (IPipelineRepository)Activator.CreateInstance(repositoryType)!;
    }
}
