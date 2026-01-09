# update-benchmark-docs.ps1
# Copies BenchmarkDotNet results to docfx benchmark documentation folder
# Run this after executing benchmarks locally on a quiet machine

param(
    [string]$SourceDir = "tests/Threading/BenchmarkDotNet.Artifacts/results",
    [string]$DestDir = "docfx/packages/threading/benchmarks"
)

$ErrorActionPreference = "Stop"

Write-Host ""
Write-Host "========================================"
Write-Host " Updating Benchmark Documentation"
Write-Host "========================================"
Write-Host ""
Write-Host "Source: $SourceDir"
Write-Host "Destination: $DestDir"
Write-Host ""

# Mapping of benchmark names to documentation filenames
$benchmarkMappings = @{
    "AsyncLockSingleBenchmark" = "asynclock-single.md"
    "AsyncLockMultipleBenchmark" = "asynclock-multiple.md"
    "AsyncAutoResetEventSetBenchmark" = "asyncautoresetevent-set.md"
    "AsyncAutoResetEventSetThenWaitBenchmark" = "asyncautoresetevent-setthenw.md"
    "AsyncAutoResetEventWaitThenSetBenchmark" = "asyncautoresetevent-waitthenset.md"
    "AsyncManualResetEventSetResetBenchmark" = "asyncmanualresetevent-setreset.md"
    "AsyncManualResetEventSetThenWaitBenchmark" = "asyncmanualresetevent-setthenw.md"
    "AsyncManualResetEventWaitThenSetBenchmark" = "asyncmanualresetevent-waitthenset.md"
    "AsyncSemaphoreSingleBenchmark" = "asyncsemaphore-single.md"
    "AsyncCountdownEventSignalBenchmark" = "asynccountdownevent-signal.md"
    "AsyncBarrierSignalAndWaitBenchmark" = "asyncbarrier-signalandwait.md"
    "AsyncReaderWriterLockReaderBenchmark" = "asyncreaderwriterlock-reader.md"
    "AsyncReaderWriterLockWriterBenchmark" = "asyncreaderwriterlock-writer.md"
}

if (-not (Test-Path $SourceDir)) {
    Write-Host "ERROR: Source directory does not exist." -ForegroundColor Red
    Write-Host "Please run benchmarks first:"
    Write-Host "  cd tests/Threading"
    Write-Host "  dotnet run -c Release -- --filter `"*Benchmark*`""
    exit 1
}

if (-not (Test-Path $DestDir)) {
    Write-Host "Creating destination directory..."
    New-Item -ItemType Directory -Force -Path $DestDir | Out-Null
}

Write-Host "Copying benchmark results..."
Write-Host ""

$copied = 0
$missing = 0

foreach ($mapping in $benchmarkMappings.GetEnumerator()) {
    $benchmarkName = $mapping.Key
    $targetName = $mapping.Value
    $sourceFile = Join-Path $SourceDir "Threading.Tests.Async.Pooled.$benchmarkName-report-github.md"

    if (Test-Path $sourceFile) {
        $destFile = Join-Path $DestDir $targetName
        Copy-Item -Path $sourceFile -Destination $destFile -Force
        Write-Host "  [OK] $targetName" -ForegroundColor Green
        $copied++
    } else {
        Write-Host "  [--] $targetName (not found: $benchmarkName)" -ForegroundColor Yellow
        $missing++
    }
}

Write-Host ""
Write-Host "========================================"
Write-Host " Benchmark documentation updated!"
Write-Host " Copied: $copied, Missing: $missing"
Write-Host "========================================"
Write-Host ""
Write-Host "Next steps:"
Write-Host "  1. Review the updated files in $DestDir"
Write-Host "  2. Build docfx to verify: docfx docfx/docfx.json"
Write-Host "  3. Commit the changes"
Write-Host ""
