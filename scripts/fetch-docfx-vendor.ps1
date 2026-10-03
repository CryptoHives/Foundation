# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# fetch-docfx-vendor.ps1
# Downloads the browser libraries the benchmark dashboards use into docfx/vendor, so the published
# site serves them itself and no visitor request reaches a third-party CDN. The files are not
# committed; each download is pinned to a version and checked against its SHA-256.
# Usage: .\scripts\fetch-docfx-vendor.ps1 [-Force]

[CmdletBinding()]
param(
    [Parameter(HelpMessage = "Download again even if a file with the expected hash is present")]
    [switch]$Force
)

$ErrorActionPreference = "Stop"

$vendorDir = Join-Path (Split-Path -Parent $PSScriptRoot) "docfx/vendor"

# To update a library: change its version in the URLs, run with -Force, and replace the hash with
# the one the failure message reports after checking the new file.
$files = @(
    @{ Name = "sql-wasm.js";                            Sha256 = "558a72c3ab3415d0e6d243cfd23f9d61543600d59054b4b7b8da3cd65f6b9fd4"; Url = "https://cdn.jsdelivr.net/npm/sql.js@1.10.3/dist/sql-wasm.js" }
    @{ Name = "sql-wasm.wasm";                          Sha256 = "d7e61b828523001f26ce0b3f88dabcf6c12e5e6edf80eb4f08b26ac7b946ff88"; Url = "https://cdn.jsdelivr.net/npm/sql.js@1.10.3/dist/sql-wasm.wasm" }
    @{ Name = "LICENSE.sql.js.txt";                     Sha256 = "60a3f6e4d7b29b4321359e683b36cf198d24f58e24582070f56e6fa89d5ee2be"; Url = "https://cdn.jsdelivr.net/npm/sql.js@1.10.3/LICENSE" }
    @{ Name = "chart.umd.min.js";                       Sha256 = "b38076762f7363bc9e912b68b8e034826798db5df26bb61f000ec2e7a3137bc7"; Url = "https://cdn.jsdelivr.net/npm/chart.js@4.4.4/dist/chart.umd.min.js" }
    @{ Name = "LICENSE.chart.js.txt";                   Sha256 = "41a84aa2caba645f966a18d9c2056b73e6d3a81d80bc0046bc0011a2634d4cce"; Url = "https://cdn.jsdelivr.net/npm/chart.js@4.4.4/LICENSE.md" }
    @{ Name = "chartjs-adapter-date-fns.bundle.min.js"; Sha256 = "ea7ab30d26c38dcf1f2d26bb43e73a94537b58f1906f55e1a546dd09321b5615"; Url = "https://cdn.jsdelivr.net/npm/chartjs-adapter-date-fns@3.0.0/dist/chartjs-adapter-date-fns.bundle.min.js" }
    @{ Name = "LICENSE.chartjs-adapter-date-fns.txt";   Sha256 = "b4b8355c2cd2b18354980a0c6422181d7bd6e895d94ae88b3570e97c60eea03d"; Url = "https://cdn.jsdelivr.net/npm/chartjs-adapter-date-fns@3.0.0/LICENSE.md" }
)

New-Item -ItemType Directory -Force -Path $vendorDir | Out-Null

foreach ($file in $files) {
    $target = Join-Path $vendorDir $file.Name

    if (-not $Force -and (Test-Path $target) -and
        (Get-FileHash -Algorithm SHA256 $target).Hash -eq $file.Sha256) {
        Write-Host "  up to date  $($file.Name)"
        continue
    }

    $partial = "$target.download"
    Invoke-WebRequest -Uri $file.Url -OutFile $partial -UseBasicParsing
    $actual = (Get-FileHash -Algorithm SHA256 $partial).Hash
    if ($actual -ne $file.Sha256) {
        Remove-Item $partial
        throw "SHA-256 mismatch for $($file.Name) from $($file.Url): expected $($file.Sha256), got $($actual.ToLowerInvariant())"
    }
    Move-Item -Force $partial $target
    Write-Host "  downloaded  $($file.Name)"
}
