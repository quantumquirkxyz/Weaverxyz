namespace PipelineOrchestrator.UI;

public sealed partial class MainForm
{
    private Label status = null!;

    private void InitializeComponent()
    {
        status = new Label { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
        Controls.Add(status);
    }
}
