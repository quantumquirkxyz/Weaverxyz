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
    public void Ui_references_only_Core_and_Data()
        => Assert.Equal(
            ["..\\PipelineOrchestrator.Core\\PipelineOrchestrator.Core.csproj", "..\\PipelineOrchestrator.Data\\PipelineOrchestrator.Data.csproj"],
            ProjectReferences("PipelineOrchestrator.UI/PipelineOrchestrator.UI.csproj"));

    [Fact]
    public void Source_contains_no_embedded_credentials()
    {
        var source = Directory.EnumerateFiles(Root, "*.cs", SearchOption.AllDirectories)
            .Where(path => !path.Contains(Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar))
            .Select(File.ReadAllText);
        Assert.DoesNotContain(source, text => text.Contains("api_key", StringComparison.OrdinalIgnoreCase)
            || text.Contains("password=", StringComparison.OrdinalIgnoreCase));
    }

    private static string[] ProjectReferences(string relativePath) =>
        XDocument.Load(Path.Combine(Root, relativePath))
            .Descendants("ProjectReference")
            .Select(element => (string?)element.Attribute("Include") ?? string.Empty)
            .ToArray();
}
