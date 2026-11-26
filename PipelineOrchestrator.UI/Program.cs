using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Orchestration;
using PipelineOrchestrator.Data;

namespace PipelineOrchestrator.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        IPipelineRepository pipelines = new InMemoryPipelineRepository();
        var application = new PipelineApplication(pipelines);
        Application.Run(new MainForm(application, initializeDesigner: true));
    }
}
