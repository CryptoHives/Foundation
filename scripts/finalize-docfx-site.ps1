# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT

# finalize-docfx-site.ps1
#
# Post-processing for the built docfx site. Run after `docfx build`, before the
# output is served locally or published to GitHub Pages. Runs under pwsh on the
# CI runner and Windows PowerShell locally.
#
#   1. Strip the UTF-8 BOM from sitemap.xml. docfx writes one, and Google Search
#      Console rejects a sitemap that has any bytes before `<?xml` with the generic
#      "Sitemap could not be read" - even though the file opens fine in a browser.
#
#   2. Enforce noindex for pages marked `_noindex: true` in front matter. docfx only
#      emits `<meta name="searchOption" content="noindex">` for those, which hides the
#      page from the docfx search box but means nothing to a search engine. This adds
#      a real `<meta name="robots" content="noindex, nofollow">` and drops the page
#      from sitemap.xml - a noindex URL listed in a sitemap is a Search Console error.
#      The Impressum is the page this exists for: it carries a maintainer's real name
#      and home address (required by German law) and must not be indexed.

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$SiteDir,

    [string]$BaseUrl = "https://cryptohives.github.io/Foundation/"
)

$ErrorActionPreference = "Stop"

if (-not (Test-Path -PathType Container $SiteDir)) {
    throw "Site directory not found: $SiteDir"
}
if (-not $BaseUrl.EndsWith("/")) { $BaseUrl += "/" }

$sitemapPath = Join-Path $SiteDir "sitemap.xml"
if (-not (Test-Path $sitemapPath)) {
    throw "sitemap.xml not found in $SiteDir - did 'docfx build' run with a 'sitemap' block in docfx.json?"
}

$Utf8NoBom = [System.Text.UTF8Encoding]::new($false)
$noindexMarker = 'name="searchOption" content="noindex"'
$robotsMeta = '    <meta name="robots" content="noindex, nofollow">'
# Insert just before </head> so the charset meta stays first in the head.
$headEndRegex = [regex]::new('(</head>)', 'IgnoreCase')

# --- 2a. Patch every noindex page's HTML and remember its URL ---------------------
$removedUrls = [System.Collections.Generic.List[string]]::new()

Get-ChildItem -Path $SiteDir -Recurse -Filter *.html | ForEach-Object {
    $html = [System.IO.File]::ReadAllText($_.FullName)
    if (-not $html.Contains($noindexMarker)) { return }

    if ($html -notmatch '(?i)name="robots"') {
        # Replace only the first </head> match.
        $html = $headEndRegex.Replace($html, "$robotsMeta`n`$1", 1)
        [System.IO.File]::WriteAllText($_.FullName, $html, $Utf8NoBom)
    }

    $rel = [System.IO.Path]::GetRelativePath($SiteDir, $_.FullName).Replace('\', '/')
    $removedUrls.Add($BaseUrl + $rel)
    Write-Host "noindex: $rel" -ForegroundColor DarkGray
}

# --- 2b. + 1. Rewrite sitemap.xml: drop noindex URLs, no BOM ---------------------
# [xml] parsing consumes any leading BOM; XmlWriter with a BOM-less encoding keeps it out.
[xml]$doc = [System.IO.File]::ReadAllText($sitemapPath)

$ns = [System.Xml.XmlNamespaceManager]::new($doc.NameTable)
$ns.AddNamespace('sm', 'http://www.sitemaps.org/schemas/sitemap/0.9')

foreach ($url in $removedUrls) {
    $node = $doc.SelectSingleNode("//sm:url[sm:loc='$url']", $ns)
    if ($null -ne $node) {
        [void]$node.ParentNode.RemoveChild($node)
        Write-Host "removed from sitemap: $url" -ForegroundColor DarkGray
    }
    else {
        Write-Warning "noindex page not found in sitemap (already absent?): $url"
    }
}

$settings = [System.Xml.XmlWriterSettings]::new()
$settings.Encoding = $Utf8NoBom
$settings.Indent = $true
$settings.IndentChars = '  '
$writer = [System.Xml.XmlWriter]::Create($sitemapPath, $settings)
try { $doc.Save($writer) } finally { $writer.Dispose() }

# --- Assertions -----------------------------------------------------------------
$bytes = [System.IO.File]::ReadAllBytes($sitemapPath)
if ($bytes.Length -ge 3 -and $bytes[0] -eq 0xEF -and $bytes[1] -eq 0xBB -and $bytes[2] -eq 0xBF) {
    throw "sitemap.xml still starts with a UTF-8 BOM"
}
$sitemapText = [System.Text.Encoding]::UTF8.GetString($bytes)
foreach ($url in $removedUrls) {
    if ($sitemapText.Contains($url)) { throw "noindex URL still present in sitemap.xml: $url" }
}

$locCount = ([regex]::Matches($sitemapText, '<loc>')).Count
Write-Host "sitemap.xml finalized: $locCount urls, $($removedUrls.Count) noindex page(s) excluded" -ForegroundColor Green
