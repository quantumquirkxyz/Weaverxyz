using PipelineOrchestrator.Core.Orchestration;

namespace PipelineOrchestrator.UI;

public sealed class MainForm(PipelineApplication application) : Form
{
    private readonly PipelineApplication compositionRoot = application;
    private readonly Label status = new() { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = "Pipeline Orchestrator";
        status.Text = $"Pipeline Orchestrator ready ({compositionRoot.Pipelines.GetType().Name})";
        Controls.Add(status);
    }
}
