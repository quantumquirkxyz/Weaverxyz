using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Data;

namespace PipelineOrchestrator.UI.Composition;

public static class PipelineCompositionRoot
{
    public static IPipelineRepository CreatePipelineRepository() =>
        new InMemoryPipelineRepository();
}
