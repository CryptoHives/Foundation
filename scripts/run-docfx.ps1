# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# run-docfx.ps1
# Compiles DocFX documentation and optionally serves the content
# Usage: .\scripts\run-docfx.ps1 [-Serve] [-Port 8080] [-NoBuild]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Serve the documentation locally after building")]
    [switch]$Serve,

    [Parameter(HelpMessage = "Port to serve documentation on (default: 8080)")]
    [int]$Port = 8080,

    [Parameter(HelpMessage = "Skip building and only serve existing content")]
    [switch]$NoBuild,

    [Parameter(HelpMessage = "Clean the output directory before building")]
    [switch]$Clean,

    [Parameter(HelpMessage = "Skip regenerating the benchmark trends database before building")]
    [switch]$SkipTrends,

    [Parameter(HelpMessage = "Path to a checkout of the benchmarks branch. A temporary worktree is used when omitted.")]
    [string]$BenchmarkArchive,

    [Parameter(HelpMessage = "Do not open the browser when serving (only applies with -Serve)")]
    [switch]$NoBrowser,

    [Parameter(HelpMessage = "Dry run - show command without executing")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

# Get repository root
$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptPath
$docfxPath = Join-Path $repoRoot "docfx"
$docfxJson = Join-Path $docfxPath "docfx.json"
$siteOutput = Join-Path $docfxPath "_site"

Write-Host ""
Write-Host "========================================"
Write-Host " CryptoHives DocFX Documentation"
Write-Host "========================================"
Write-Host ""
Write-Host "Configuration:"
Write-Host "  DocFX Path:    $docfxPath"
Write-Host "  Config:        $docfxJson"
Write-Host "  Output:        $siteOutput"
Write-Host "  Serve:         $Serve"
if ($Serve) {
    Write-Host "  Port:          $Port"
}
Write-Host ""

# Validate docfx.json exists
if (-not (Test-Path $docfxJson)) {
    Write-Host "ERROR: docfx.json not found at $docfxJson" -ForegroundColor Red
    exit 1
}

# Check if docfx is installed
$docfxInstalled = $null
try {
    $docfxInstalled = Get-Command docfx -ErrorAction SilentlyContinue
}
catch {
    # Ignore
}

if (-not $docfxInstalled) {
    Write-Host "DocFX not found. Installing as global tool..." -ForegroundColor Yellow
    if (-not $DryRun) {
        & dotnet tool install -g docfx
        if ($LASTEXITCODE -ne 0) {
            Write-Host "ERROR: Failed to install DocFX" -ForegroundColor Red
            exit 1
        }
    }
    else {
        Write-Host "[DRY RUN] Would run: dotnet tool install -g docfx" -ForegroundColor Yellow
    }
    Write-Host ""
}

# Regenerate the benchmark trends database.
#
# The database is a derived artifact built from the run archive on the `benchmarks` branch, not
# something committed alongside the docs, so a docs build that skips this step publishes a
# dashboard with no data - or, worse, with whatever data happened to be left over locally.
if (-not $SkipTrends -and -not $NoBuild) {
    $trendsScript = Join-Path $scriptPath "build-trends-database.ps1"
    $trendsDb = Join-Path $docfxPath "packages/threading/benchmark-trends/benchmark-history.sqlite"

    Write-Host "Regenerating benchmark trends database..." -ForegroundColor Green
    if ($DryRun) {
        Write-Host "[DRY RUN] Would run: $trendsScript" -ForegroundColor Yellow
    }
    else {
        try {
            if ($BenchmarkArchive) {
                & $trendsScript -Archive $BenchmarkArchive
            }
            else {
                & $trendsScript
            }
            if ($LASTEXITCODE -ne 0) { throw "build-trends-database.ps1 exited with $LASTEXITCODE." }
        }
        catch {
            # A clone that has never fetched the benchmarks branch can still build the docs; only
            # the trend charts are affected. Fail only when there is no database at all, since
            # publishing an empty dashboard silently is the outcome worth preventing.
            if (Test-Path $trendsDb) {
                Write-Host "WARNING: could not regenerate the trends database ($($_.Exception.Message))." -ForegroundColor Yellow
                Write-Host "         Building with the existing one - its numbers may be stale." -ForegroundColor Yellow
            }
            else {
                Write-Host "ERROR: could not build the trends database and none exists." -ForegroundColor Red
                Write-Host "       Fetch the archive branch first:  git fetch origin benchmarks" -ForegroundColor Red
                Write-Host "       Or pass -SkipTrends to build the rest of the site without it." -ForegroundColor Red
                exit 1
            }
        }
    }
    Write-Host ""
}

# Clean output directory if requested
if ($Clean -and (Test-Path $siteOutput)) {
    Write-Host "Cleaning output directory: $siteOutput" -ForegroundColor Yellow
    if (-not $DryRun) {
        Remove-Item -Path $siteOutput -Recurse -Force
    }
    else {
        Write-Host "[DRY RUN] Would remove: $siteOutput" -ForegroundColor Yellow
    }
    Write-Host ""
}

# Build documentation
if (-not $NoBuild) {
    $buildArgs = @($docfxJson)

    $cmdDisplay = "docfx " + ($buildArgs -join " ")
    Write-Host "Command: $cmdDisplay" -ForegroundColor Cyan
    Write-Host ""

    if ($DryRun) {
        Write-Host "[DRY RUN] Would build documentation" -ForegroundColor Yellow
    }
    else {
        Write-Host "Building documentation..." -ForegroundColor Green
        Write-Host "========================================"
        Write-Host ""

        & docfx @buildArgs

        $exitCode = $LASTEXITCODE
        if ($exitCode -ne 0) {
            Write-Host ""
            Write-Host "DocFX build failed with exit code: $exitCode" -ForegroundColor Red
            exit $exitCode
        }

        Write-Host ""
        Write-Host "========================================"
        Write-Host " Documentation built successfully!"
        Write-Host "========================================"
        Write-Host ""
    }
}

# Serve documentation
if ($Serve) {
    # Validate site output exists
    if (-not (Test-Path $siteOutput)) {
        Write-Host "ERROR: Site output not found at $siteOutput. Build the documentation first." -ForegroundColor Red
        exit 1
    }

    # `docfx <config> --serve` builds *and* serves, so using it here rebuilt everything a second
    # time after the build above - and ignored -NoBuild entirely. `docfx serve <folder>` only
    # serves, which is what this step is for.
    $serveArgs = @("serve", $siteOutput, "--port", $Port)
    if (-not $NoBrowser) { $serveArgs += "--open-browser" }

    $cmdDisplay = "docfx " + ($serveArgs -join " ")
    Write-Host "Command: $cmdDisplay" -ForegroundColor Cyan
    Write-Host ""

    if ($DryRun) {
        Write-Host "[DRY RUN] Would serve documentation at http://localhost:$Port" -ForegroundColor Yellow
        if (-not $NoBrowser) {
            Write-Host "[DRY RUN] Would open browser to http://localhost:$Port" -ForegroundColor Yellow
        }
    }
    else {
        Write-Host "Serving documentation at http://localhost:$Port" -ForegroundColor Green
        Write-Host "Press Ctrl+C to stop the server"
        Write-Host "========================================"
        Write-Host ""

        # --open-browser rather than Start-Process: docfx opens it once the listener is up,
        # instead of racing the server and landing on a connection error.
        & docfx @serveArgs
    }
}
else {
    Write-Host "Documentation output: $siteOutput"
    Write-Host ""
    Write-Host "To view the documentation, run:"
    Write-Host "  .\scripts\run-docfx.ps1 -Serve"
    Write-Host ""
    # Opening the files directly used to be suggested here. It does not work for the benchmark
    # trends pages: they fetch a SQLite database over XHR, which browsers block under file://
    # regardless of what is on disk. Serving over HTTP is the only way those pages have data.
    Write-Host "Note: the benchmark trends pages need to be served over HTTP - opening" -ForegroundColor DarkGray
    Write-Host "      $siteOutput\index.html directly leaves their charts empty." -ForegroundColor DarkGray
    Write-Host ""
}
