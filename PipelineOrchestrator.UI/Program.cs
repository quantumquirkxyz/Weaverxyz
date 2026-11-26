using PipelineOrchestrator.Core.Orchestration;

namespace PipelineOrchestrator.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var application = new PipelineApplication();
        Application.Run(new MainForm(application, initializeDesigner: true));
    }
}
