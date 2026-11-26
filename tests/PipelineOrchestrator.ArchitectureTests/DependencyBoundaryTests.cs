using System.Xml.Linq;
using Xunit;

namespace PipelineOrchestrator.ArchitectureTests;

public sealed class DependencyBoundaryTests
{
    private static string Root => Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../.."));

    [Fact]
    public void Core_has_no_project_references()
        => Assert.Empty(ProjectReferences("PipelineOrchestrator.Core/PipelineOrchestrator.Core.csproj"));

    [Fact]
    public void Data_references_only_Core()
        => Assert.Equal(["..\\PipelineOrchestrator.Core\\PipelineOrchestrator.Core.csproj"],
            ProjectReferences("PipelineOrchestrator.Data/PipelineOrchestrator.Data.csproj"));

    [Fact]
    public void Ui_references_Core_and_Data_for_composition()
        => Assert.Equal(
            ["..\\PipelineOrchestrator.Core\\PipelineOrchestrator.Core.csproj",
             "..\\PipelineOrchestrator.Data\\PipelineOrchestrator.Data.csproj"],
            ProjectReferences("PipelineOrchestrator.UI/PipelineOrchestrator.UI.csproj"));

    [Fact]
    public void Project_graph_has_no_cycles_or_forbidden_ui_data_edge()
    {
        var references = new Dictionary<string, string[]>
        {
            ["Core"] = ProjectReferences("PipelineOrchestrator.Core/PipelineOrchestrator.Core.csproj"),
            ["Data"] = ProjectReferences("PipelineOrchestrator.Data/PipelineOrchestrator.Data.csproj"),
            ["UI"] = ProjectReferences("PipelineOrchestrator.UI/PipelineOrchestrator.UI.csproj")
        };

        Assert.DoesNotContain(references["Core"], reference => reference.Contains("PipelineOrchestrator.Data"));
        Assert.DoesNotContain(references["Data"], reference => reference.Contains("PipelineOrchestrator.UI"));
        Assert.False(HasCycle(references));
    }

    [Fact]
    public void Build_properties_are_deterministic_and_nullable()
    {
        var props = XDocument.Load(Path.Combine(Root, "Directory.Build.props")).ToString();
        Assert.Contains("<Deterministic>true</Deterministic>", props);
        Assert.Contains("<Nullable>enable</Nullable>", props);
        Assert.Contains("<LangVersion>12.0</LangVersion>", props);
    }

    [Fact]
    public void Source_contains_no_embedded_credentials()
    {
        var source = Directory.EnumerateFiles(Root, "*.cs", SearchOption.AllDirectories)
            .Where(path => !path.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
            .Where(path => !path.Contains(Path.DirectorySeparatorChar + "tests" + Path.DirectorySeparatorChar))
            .Select(File.ReadAllText);
        Assert.DoesNotContain(source, text => text.Contains("api_key", StringComparison.OrdinalIgnoreCase)
            || text.Contains("password=", StringComparison.OrdinalIgnoreCase));
    }

    private static string[] ProjectReferences(string relativePath) =>
        XDocument.Load(Path.Combine(Root, relativePath))
            .Descendants("ProjectReference")
            .Select(element => (string?)element.Attribute("Include") ?? string.Empty)
            .ToArray();

    private static bool HasCycle(IReadOnlyDictionary<string, string[]> graph)
    {
        var visiting = new HashSet<string>();
        var visited = new HashSet<string>();

        bool Visit(string project)
        {
            if (!graph.ContainsKey(project))
                return false;
            if (!visiting.Add(project))
                return true;
            if (graph[project].Any(reference => Visit(ProjectName(reference))))
                return true;
            visiting.Remove(project);
            visited.Add(project);
            return false;
        }

        return graph.Keys.Any(project => !visited.Contains(project) && Visit(project));
    }

    private static string ProjectName(string reference) =>
        reference.Contains("PipelineOrchestrator.Core", StringComparison.Ordinal) ? "Core" :
        reference.Contains("PipelineOrchestrator.Data", StringComparison.Ordinal) ? "Data" :
        reference.Contains("PipelineOrchestrator.UI", StringComparison.Ordinal) ? "UI" : reference;
}
