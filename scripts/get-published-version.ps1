# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

<#
 .SYNOPSIS
    Resolves the newest version published on nuget.org for every CryptoHives.Foundation package.

 .DESCRIPTION
    Queries the NuGet flat container for each package and returns the highest version that all of
    them have published. The intersection matters: the packages are released together today, but if
    one ever lags behind, testing against a version only some of them have would fail at restore
    with a confusing error rather than telling you what is actually going on.

    Prints the version to stdout, and appends `version=<value>` to $env:GITHUB_OUTPUT when running
    inside GitHub Actions.

 .PARAMETER IncludePrerelease
    Consider pre-release versions (e.g. 0.7.1-preview) as well as stable ones.

 .PARAMETER PackageId
    Package ids to consider. Defaults to the four shipped packages.

 .EXAMPLE
    ./scripts/get-published-version.ps1
    ./scripts/get-published-version.ps1 -IncludePrerelease
#>

[CmdletBinding()]
param(
    [switch]$IncludePrerelease,

    [string[]]$PackageId = @(
        'CryptoHives.Foundation.Memory',
        'CryptoHives.Foundation.Threading',
        'CryptoHives.Foundation.Threading.Analyzers',
        'CryptoHives.Foundation.Security.Cryptography'
    )
)

$ErrorActionPreference = 'Stop'

# Sorts semver strings the way NuGet does for the bit we care about: numeric release parts first,
# and a version with a pre-release label ranks below the same version without one.
function ConvertTo-SortKey([string]$version) {
    $release, $pre = $version -split '-', 2
    $parts = @($release -split '\.' | ForEach-Object { [int]$_ })
    while ($parts.Count -lt 4) { $parts += 0 }
    return [PSCustomObject]@{
        Release    = $parts
        IsStable   = [string]::IsNullOrEmpty($pre)
        Prerelease = $pre
    }
}

function Compare-Version([string]$a, [string]$b) {
    $x = ConvertTo-SortKey $a
    $y = ConvertTo-SortKey $b
    for ($i = 0; $i -lt 4; $i++) {
        if ($x.Release[$i] -ne $y.Release[$i]) { return $x.Release[$i] - $y.Release[$i] }
    }
    if ($x.IsStable -ne $y.IsStable) { return $(if ($x.IsStable) { 1 } else { -1 }) }
    return [string]::Compare($x.Prerelease, $y.Prerelease, [StringComparison]::OrdinalIgnoreCase)
}

$common = $null
foreach ($id in $PackageId) {
    $uri = "https://api.nuget.org/v3-flatcontainer/$($id.ToLowerInvariant())/index.json"
    try {
        $versions = (Invoke-RestMethod -Uri $uri -MaximumRetryCount 3 -RetryIntervalSec 5).versions
    }
    catch {
        throw "Failed to query nuget.org for '$id': $($_.Exception.Message)"
    }

    if (-not $IncludePrerelease) {
        $versions = @($versions | Where-Object { $_ -notmatch '-' })
    }
    if (-not $versions -or $versions.Count -eq 0) {
        throw "No matching versions published for '$id'$(if (-not $IncludePrerelease) { ' (stable only - try -IncludePrerelease)' })."
    }

    Write-Verbose "$id : $($versions.Count) version(s), newest $($versions[-1])"
    $common = if ($null -eq $common) { $versions } else { $common | Where-Object { $versions -contains $_ } }
}

$common = @($common)
if ($common.Count -eq 0) {
    throw "The packages have no version in common on nuget.org: $($PackageId -join ', '). " +
          "Pass an explicit version to test one package set anyway."
}

$latest = $common[0]
foreach ($candidate in $common) {
    if ((Compare-Version $candidate $latest) -gt 0) { $latest = $candidate }
}

Write-Verbose "Newest version published for all $($PackageId.Count) packages: $latest"
Write-Output $latest

if ($env:GITHUB_OUTPUT) {
    "version=$latest" | Out-File -FilePath $env:GITHUB_OUTPUT -Encoding utf8 -Append
}
