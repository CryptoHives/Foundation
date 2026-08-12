# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# publish-ghpages.ps1
# Builds the DocFX site locally and publishes it to the `gh-pages` branch.
#
# The normal path is .github/workflows/docfx.yml, which builds the site in CI and hands it to
# GitHub Pages through actions/deploy-pages. This script exists for when that is unavailable -
# an Actions budget that has run out, an outage, or simply wanting to see the real published
# site before a change lands. It produces byte-for-byte the same site: the same trends databases
# from the same archive, the same `docfx docfx/docfx.json`.
#
# Publishing from a branch instead of from a workflow requires the repository's Pages source to
# be set to "Deploy from a branch" -> gh-pages / (root). While it is set to "GitHub Actions",
# pushing here changes nothing, which makes a dry publish safe but a real one silent.
#
# Two details that only matter for branch-based publishing, both handled below:
#
#   - `.nojekyll` has to exist, or GitHub runs the site through Jekyll, which silently drops
#     every path beginning with an underscore. The Actions deploy path bypasses Jekyll entirely,
#     so this file is not in the build output and has to be added here.
#   - Each publish replaces the branch with a single orphan commit rather than adding to it. The
#     site carries ~13 MB of SQLite per publish, and SQLite rewrites pages throughout on every
#     rebuild, so an accumulating history would add that much again every time - the same reason
#     the trends databases are not committed to main. gh-pages is a derived artifact; its history
#     is worth nothing and costs a lot.
#
# Usage:
#   .\scripts\publish-ghpages.ps1                                  # build, then publish
#   .\scripts\publish-ghpages.ps1 -BenchmarkArchive ../foundation-bench
#   .\scripts\publish-ghpages.ps1 -NoBuild                         # publish docfx/_site as it is
#   .\scripts\publish-ghpages.ps1 -DryRun                          # show what would be pushed

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Path to a checkout of the benchmarks branch. A temporary worktree is used when omitted.")]
    [string]$BenchmarkArchive,

    [Parameter(HelpMessage = "Publish the existing docfx/_site without rebuilding it")]
    [switch]$NoBuild,

    [Parameter(HelpMessage = "Branch to publish to (default: gh-pages)")]
    [string]$Branch = "gh-pages",

    [Parameter(HelpMessage = "Git remote to push to (default: origin)")]
    [string]$Remote = "origin",

    [Parameter(HelpMessage = "Stage and commit locally, but do not push")]
    [switch]$NoPush,

    [Parameter(HelpMessage = "Dry run - report what would happen without building, committing or pushing")]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

$RepoRoot = Split-Path $PSScriptRoot
$SiteDir = Join-Path $RepoRoot "docfx/_site"
$WorktreeDir = Join-Path ([System.IO.Path]::GetTempPath()) "cryptohives-ghpages"

Write-Host ""
Write-Host "========================================"
Write-Host " Publishing DocFX site to $Branch"
Write-Host "========================================"
Write-Host ""

# ---------------------------------------------------------------- build
if (-not $NoBuild) {
    $buildArgs = @("-NoProfile", "-File", (Join-Path $PSScriptRoot "run-docfx.ps1"), "-Clean")
    if ($BenchmarkArchive) { $buildArgs += @("-BenchmarkArchive", $BenchmarkArchive) }
    if ($DryRun) { $buildArgs += "-DryRun" }

    Write-Host "Building the site..." -ForegroundColor Cyan
    & pwsh @buildArgs
    if ($LASTEXITCODE -ne 0) { throw "run-docfx.ps1 failed with exit code $LASTEXITCODE." }
    Write-Host ""
}

if (-not (Test-Path $SiteDir)) {
    throw "No site at $SiteDir. Drop -NoBuild, or build first with .\scripts\run-docfx.ps1."
}

$siteFileCount = (Get-ChildItem -Recurse -File -Force $SiteDir).Count
Write-Host "Site: $SiteDir ($siteFileCount file(s))"

# A site with no trends database still publishes, and looks fine until someone opens a dashboard
# and finds an empty chart - so say so here rather than letting it ship quietly.
foreach ($db in @("packages/threading/benchmark-trends/benchmark-history.sqlite",
                  "packages/security/cryptography/benchmark-trends/benchmark-history.sqlite")) {
    $path = Join-Path $SiteDir $db
    if (Test-Path $path) {
        $sizeMb = [math]::Round((Get-Item $path).Length / 1MB, 1)
        Write-Host "  [OK] $db ($sizeMb MB)" -ForegroundColor Green
    } else {
        Write-Host "  [WARN] $db is missing - its dashboard will load empty." -ForegroundColor Yellow
    }
}
Write-Host ""

# ---------------------------------------------------------------- worktree
# A worktree rather than a second clone: it shares the object store, so publishing does not copy
# the whole repository, and it keeps the main working tree untouched while the branch is rewritten.
if (Test-Path $WorktreeDir) {
    Write-Host "Removing the previous publish worktree..."
    if (-not $DryRun) {
        git -C $RepoRoot worktree remove --force $WorktreeDir 2>$null | Out-Null
        if (Test-Path $WorktreeDir) { Remove-Item -Recurse -Force $WorktreeDir }
    }
}

Write-Host "Preparing $Branch in $WorktreeDir"
if (-not $DryRun) {
    # --detach, then an orphan commit: the branch ref is only moved at the very end, so a failure
    # anywhere in between leaves the published site exactly as it was.
    git -C $RepoRoot worktree add --detach $WorktreeDir HEAD | Out-Null
    Get-ChildItem -Force $WorktreeDir | Where-Object { $_.Name -ne ".git" } | Remove-Item -Recurse -Force

    Copy-Item -Path (Join-Path $SiteDir "*") -Destination $WorktreeDir -Recurse -Force

    # Without this GitHub runs the site through Jekyll, which drops every underscore-prefixed path.
    New-Item -ItemType File -Path (Join-Path $WorktreeDir ".nojekyll") -Force | Out-Null
}

# ---------------------------------------------------------------- commit
$sourceCommit = (git -C $RepoRoot rev-parse HEAD).Trim()
$sourceShort = $sourceCommit.Substring(0, 8)
$message = "Publish docs built from $sourceShort`n`nBuilt locally with scripts/publish-ghpages.ps1."

if ($DryRun) {
    Write-Host ""
    Write-Host "[DRY RUN] Would replace '$Branch' with one orphan commit of $siteFileCount file(s)" -ForegroundColor Yellow
    Write-Host "[DRY RUN] Would force-push it to $Remote/$Branch" -ForegroundColor Yellow
    Write-Host ""
    return
}

Push-Location $WorktreeDir
try {
    git add -A --force | Out-Null

    # An orphan commit, so the branch never accumulates the previous publish's blobs.
    $tree = (git write-tree).Trim()
    $commit = (git commit-tree $tree -m $message).Trim()
    git branch -f $Branch $commit | Out-Null

    Write-Host ""
    Write-Host "  [OK] $Branch now points at $($commit.Substring(0, 8))" -ForegroundColor Green

    if ($NoPush) {
        Write-Host ""
        Write-Host "  -NoPush given; nothing was pushed. To publish:" -ForegroundColor Yellow
        Write-Host "      git push --force $Remote ${Branch}:$Branch"
    } else {
        Write-Host "  Pushing to $Remote/$Branch (force, by design - see the header comment)..."
        # The site is ~13 MB, so this is not instant on a slow link.
        git push --force $Remote "${Branch}:$Branch"
        if ($LASTEXITCODE -ne 0) { throw "git push failed with exit code $LASTEXITCODE." }
        Write-Host "  [OK] Pushed." -ForegroundColor Green
    }
} finally {
    Pop-Location
    git -C $RepoRoot worktree remove --force $WorktreeDir 2>$null | Out-Null
}

Write-Host ""
Write-Host "========================================"
Write-Host " Published docs built from $sourceShort"
Write-Host "========================================"
Write-Host ""
Write-Host "The site only goes live if the repository's Pages source is set to"
Write-Host "'Deploy from a branch' -> $Branch / (root). While it is set to 'GitHub Actions',"
Write-Host "this push changes nothing that visitors see."
Write-Host ""
Write-Host "  https://cryptohives.github.io/Foundation/"
Write-Host ""
