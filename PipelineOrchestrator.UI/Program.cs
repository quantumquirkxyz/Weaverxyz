using PipelineOrchestrator.Core.Contracts;
using PipelineOrchestrator.Core.Orchestration;
using PipelineOrchestrator.UI.Composition;

namespace PipelineOrchestrator.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        IPipelineRepository pipelines = PipelineCompositionRoot.CreatePipelineRepository();
        var application = new PipelineApplication(pipelines);
        Application.Run(new MainForm(application, initializeDesigner: true));
    }
}
