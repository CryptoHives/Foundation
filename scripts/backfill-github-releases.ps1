<#
 .SYNOPSIS
    Pushes the curated notes in releases/ into the matching GitHub releases and corrects their
    pre-release flags.

 .DESCRIPTION
    Release notes live in the repository as releases/<nuget-version>.md, one file per published
    package version. GitHub releases are keyed by git tag, which carries a fourth version part that
    NuGet drops (0.6.79.4022 -> 0.6.79), so each notes file is matched to its tag the same way
    .github/workflows/test-published-packages.yml does it: compare the first three version parts
    plus the pre-release label.

    For every match the script sets the release body from the file and sets the pre-release flag
    from the version itself - a version carrying a pre-release label (-preview) is a pre-release,
    one without is not. Releases whose body and flag already agree with the repository are left
    alone, so re-running is a no-op.

 .PARAMETER Repo
    The GitHub repository, owner/name. Passed to gh explicitly because this clone has more than one
    remote and inference would be ambiguous.

 .PARAMETER NotesDirectory
    Directory holding the per-version notes files. Defaults to releases/ beside this script's repo
    root. README.md is ignored.

 .PARAMETER Skip
    Versions to leave untouched. Defaults to the 0.2.17-preview.ga9c29ac5a0 test build.

 .PARAMETER UpdateLatest
    Also mark the newest stable release as 'Latest'. GitHub does not recompute that flag when a
    release stops being a pre-release, so without this the previous stable release keeps the badge.

 .PARAMETER BackupPath
    Where to write the current release bodies and flags before changing anything. Editing a release
    replaces its body outright, and the auto-generated 'What's Changed' lists are not recoverable
    from the API afterwards. Defaults to a timestamped file in the repository root.

 .PARAMETER NoBackup
    Skip the backup. Only sensible on a re-run, once the originals are already saved.

 .EXAMPLE
    ./scripts/backfill-github-releases.ps1 -WhatIf
    Shows what would change without touching anything. Run this first.

 .EXAMPLE
    ./scripts/backfill-github-releases.ps1 -UpdateLatest
#>
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
param(
    [string]$Repo = 'CryptoHives/Foundation',
    [string]$NotesDirectory,
    [string[]]$Skip = @('0.2.17-preview.ga9c29ac5a0'),
    [switch]$UpdateLatest,
    [string]$BackupPath,
    [switch]$NoBackup
)

$ErrorActionPreference = 'Stop'

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
if (-not $NotesDirectory) {
    $NotesDirectory = Join-Path $repoRoot 'releases'
}

if (-not (Test-Path $NotesDirectory)) {
    throw "Notes directory not found: $NotesDirectory"
}

if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    throw "The GitHub CLI (gh) is required. See https://cli.github.com/."
}

& gh auth status *> $null
if ($LASTEXITCODE -ne 0) {
    throw "gh is not authenticated. Run 'gh auth login' first."
}

# Tags are the only link between a notes file and its GitHub release, so read them once.
$allTags = @(& git -C $repoRoot tag --list)
if ($LASTEXITCODE -ne 0) {
    throw "Could not list git tags in $repoRoot."
}

# One API call rather than one per release; body is needed to keep re-runs idempotent.
Write-Verbose "Fetching releases for $Repo"
$releases = & gh api "repos/$Repo/releases" --paginate | ConvertFrom-Json
$byTag = @{}
foreach ($release in $releases) {
    $byTag[$release.tag_name] = $release
}
Write-Verbose "$($byTag.Count) release(s) found"

# Mirrors the tag resolution in .github/workflows/test-published-packages.yml: release tags carry
# the full assembly version (0.6.51.25133) while NuGet drops the fourth part (0.6.51).
function Resolve-TagForVersion([string]$version, [string[]]$tags) {
    $release, $pre = $version -split '-', 2
    $candidates = @($tags | Where-Object {
        $tagRelease, $tagPre = $_ -split '-', 2
        $parts = $tagRelease -split '\.'
        $parts.Count -ge 3 -and (($parts[0..2] -join '.') -eq $release) -and ($tagPre -eq $pre)
    } | Sort-Object)

    if ($candidates.Count -eq 0) { return $null }
    # Newest wins if a three-part version was ever tagged twice.
    return $candidates[-1]
}

# GitHub stores bodies with CRLF; normalise both sides so line endings alone never force an edit.
function ConvertTo-ComparableText([string]$text) {
    if ($null -eq $text) { return '' }
    return ($text -replace "`r`n", "`n").TrimEnd()
}

# Bodies are replaced, not merged, and the auto-generated lists cannot be read back afterwards.
if (-not $NoBackup -and -not $WhatIfPreference) {
    if (-not $BackupPath) {
        $stamp = Get-Date -Format 'yyyyMMdd-HHmmss'
        $BackupPath = Join-Path $repoRoot "release-bodies-backup-$stamp.json"
    }

    $releases |
        Select-Object tag_name, name, prerelease, draft, body |
        ConvertTo-Json -Depth 5 |
        Set-Content -Path $BackupPath -Encoding utf8

    Write-Host "Backed up $($releases.Count) release body/bodies to $BackupPath"
}

$notesFiles = Get-ChildItem -Path $NotesDirectory -Filter '*.md' |
    Where-Object { $_.Name -ne 'README.md' } |
    Sort-Object Name

if ($notesFiles.Count -eq 0) {
    throw "No notes files found in $NotesDirectory."
}

$results = [System.Collections.Generic.List[object]]::new()

foreach ($file in $notesFiles) {
    $version = $file.BaseName

    if ($Skip -contains $version) {
        $results.Add([pscustomobject]@{ Version = $version; Tag = ''; Action = 'skipped (excluded)' })
        continue
    }

    $tag = Resolve-TagForVersion -version $version -tags $allTags
    if (-not $tag) {
        Write-Warning "No git tag matches $version - skipping."
        $results.Add([pscustomobject]@{ Version = $version; Tag = ''; Action = 'skipped (no tag)' })
        continue
    }

    $release = $byTag[$tag]
    if (-not $release) {
        Write-Warning "Tag $tag has no GitHub release - skipping. Create it first."
        $results.Add([pscustomobject]@{ Version = $version; Tag = $tag; Action = 'skipped (no release)' })
        continue
    }

    # The version itself is the authority: a pre-release label means a pre-release.
    $shouldBePrerelease = $version -match '-'
    $notes = Get-Content -Path $file.FullName -Raw

    $bodyDiffers = (ConvertTo-ComparableText $release.body) -ne (ConvertTo-ComparableText $notes)
    $flagDiffers = [bool]$release.prerelease -ne [bool]$shouldBePrerelease

    if (-not $bodyDiffers -and -not $flagDiffers) {
        $results.Add([pscustomobject]@{ Version = $version; Tag = $tag; Action = 'unchanged' })
        continue
    }

    $changes = @()
    if ($bodyDiffers) { $changes += 'notes' }
    if ($flagDiffers) { $changes += "prerelease $($release.prerelease) -> $shouldBePrerelease" }
    $description = $changes -join ', '

    if (-not $PSCmdlet.ShouldProcess("$tag ($version)", "update $description")) {
        $results.Add([pscustomobject]@{ Version = $version; Tag = $tag; Action = "would update: $description" })
        continue
    }

    $ghArgs = @(
        'release', 'edit', $tag,
        '--repo', $Repo,
        '--notes-file', $file.FullName,
        "--prerelease=$($shouldBePrerelease.ToString().ToLowerInvariant())"
    )

    & gh @ghArgs | Out-Null
    if ($LASTEXITCODE -ne 0) {
        throw "gh release edit failed for $tag (exit $LASTEXITCODE)."
    }

    Write-Host "Updated $tag ($version): $description"
    $results.Add([pscustomobject]@{ Version = $version; Tag = $tag; Action = "updated: $description" })
}

if ($UpdateLatest) {
    # 'Latest' is a stored flag, not a computed one, so clearing a pre-release flag does not move it.
    $stable = $notesFiles |
        Where-Object { $Skip -notcontains $_.BaseName -and $_.BaseName -notmatch '-' } |
        Sort-Object { [version]$_.BaseName } |
        Select-Object -Last 1

    if ($stable) {
        $tag = Resolve-TagForVersion -version $stable.BaseName -tags $allTags
        if ($tag -and $PSCmdlet.ShouldProcess("$tag ($($stable.BaseName))", 'mark as latest')) {
            & gh release edit $tag --repo $Repo --latest | Out-Null
            if ($LASTEXITCODE -ne 0) {
                throw "gh release edit --latest failed for $tag (exit $LASTEXITCODE)."
            }
            Write-Host "Marked $tag as latest"
        }
        elseif ($tag) {
            Write-Host "Would mark $tag ($($stable.BaseName)) as latest"
        }
    }
}

Write-Host ''
$results | Format-Table -AutoSize
