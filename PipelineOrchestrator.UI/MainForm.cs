using PipelineOrchestrator.Core.Orchestration;

namespace PipelineOrchestrator.UI;

public sealed partial class MainForm(PipelineApplication application) : Form
{
    private readonly PipelineApplication compositionRoot = application;

    public MainForm(PipelineApplication application, bool initializeDesigner) : this(application)
    {
        if (initializeDesigner)
            InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = "Pipeline Orchestrator";
        status.Text = $"Pipeline Orchestrator ready ({compositionRoot.Pipelines.GetType().Name})";
    }
}
