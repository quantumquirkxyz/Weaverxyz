using PipelineOrchestrator.Core.Orchestration;
using PipelineOrchestrator.Data;

namespace PipelineOrchestrator.UI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var application = new PipelineApplication(new InMemoryPipelineRepository());
        Application.Run(new MainForm(application));
    }
}
