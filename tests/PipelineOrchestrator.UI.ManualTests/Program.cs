using PipelineOrchestrator.Core.Orchestration;
using PipelineOrchestrator.UI;

namespace PipelineOrchestrator.UI.ManualTests;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(new PipelineApplication(
            new ManualTestRepository()), initializeDesigner: true));
    }

    private sealed class ManualTestRepository : PipelineOrchestrator.Core.Contracts.IPipelineRepository
    {
        public Task<PipelineOrchestrator.Core.Models.PipelineDefinition?> FindAsync(
            Guid id,
            CancellationToken cancellationToken = default)
            => Task.FromResult<PipelineOrchestrator.Core.Models.PipelineDefinition?>(null);
    }
}
