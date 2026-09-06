// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1050 // Declare types in namespaces

using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Markdown exporter that writes each benchmark report under the short name of the class that was
/// measured, rather than BenchmarkDotNet's fully qualified default.
/// </summary>
/// <remarks>
/// <para>
/// Produces files like "AesGcm256Benchmark-report.md" instead of
/// "Cryptography.Tests.Benchmarks.AesGcm256Benchmark-report-github.md". The archive on the
/// <c>benchmarks</c> branch is keyed by package, commit, platform and framework, so the namespace in
/// the file name carries no information the path does not already hold, and the short name is what the
/// documentation links to.
/// </para>
/// <para>
/// Shared by every benchmark configuration in the repository. It depends on nothing category-specific -
/// only on the type of the first benchmark case - so the orderers and columns stay local to each config
/// while this does not.
/// </para>
/// </remarks>
public sealed class ShortNameMarkdownExporter : IExporter
{
    /// <summary>
    /// Shared instance. The exporter is stateless, so every configuration can use the same one.
    /// </summary>
    public static readonly ShortNameMarkdownExporter Default = new();

    private readonly IExporter _inner = MarkdownExporter.GitHub;

    public string Name => "ShortMarkdown";

    public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
    {
        // Short class name, without the namespace.
        var typeName = summary.BenchmarksCases.FirstOrDefault()?.Descriptor.Type.Name ?? "Benchmark";

        var fileName = $"{typeName}-report.md";
        var safeFileName = Path.GetFileName(fileName);
        var filePath = Path.IsPathRooted(safeFileName)
                ? safeFileName
                : Path.Combine(summary.ResultsDirectoryPath, safeFileName);

        // Export using the inner exporter's logic.
        using var writer = new StreamWriter(filePath);
        using var logger = new StreamLogger(writer);
        _inner.ExportToLog(summary, logger);

        consoleLogger.WriteLine($"  // * Results exported to: {filePath}");
        return [filePath];
    }

    public void ExportToLog(Summary summary, ILogger logger)
    {
        _inner.ExportToLog(summary, logger);
    }
}
