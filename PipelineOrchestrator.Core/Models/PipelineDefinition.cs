namespace PipelineOrchestrator.Core.Models;

public sealed record PipelineDefinition(Guid Id, string Name, IReadOnlyList<PipelineStep> Steps);

public sealed record PipelineStep(string Name, string StepType);
