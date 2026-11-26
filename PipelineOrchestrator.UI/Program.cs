using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Orchestration;

namespace PipelineOrchestrator.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        IPipelineRepository pipelines = new PipelineOrchestrator.Core.Data.InMemoryPipelineRepository();
        var application = new PipelineApplication(pipelines);
        Application.Run(new MainForm(application, initializeDesigner: true));
    }
}
