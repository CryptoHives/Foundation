#!/usr/bin/env python3
# SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
# SPDX-License-Identifier: MIT
"""
Backfills the `packages` block into run.json for runs recorded before it existed.

update-benchmark-docs.ps1 now records the version of every third-party library a benchmark run
measured against, read from NuGet's resolved restore graph. Runs recorded before that have no
such block, which leaves a hole exactly where it hurts: BouncyCastle went 2.6.2 -> 2.7.0 in #210
and AsyncKeyedLock moved four times across the recorded history, so several existing trend lines
step for reasons that have nothing to do with this repository's code.

The information is recoverable, because central package management pins every version in
Directory.Packages.props and each run.json names the commit it measured. This walks the archive,
reads that file (and the benchmark project's csproj, for which packages were referenced) at each
run's commit, and writes the result back.

What is recovered is the *declared* pin, not the resolved graph, so every entry is stamped
packagesSource="Directory.Packages.props". Central pinning makes the two agree in practice, but
declared is a minimum and resolved is a fact - the distinction is preserved rather than papered
over, and the dashboard says which it is showing.

Idempotent: a run that already has a `packages` block is left untouched, so this is safe to
re-run after adding a new run to the archive.

Usage:
    python scripts/backfill-run-packages.py --archive ../foundation-bench
    python scripts/backfill-run-packages.py --archive ../foundation-bench --dry-run
"""

import argparse
import json
import os
import re
import subprocess
import sys

# The benchmark project whose references define "what this run measured against", per package
# directory in the archive.
PROJECTS = {
    "threading": "tests/Threading/Threading.Tests.csproj",
    "cryptography": "tests/Security/Cryptography/Cryptography.Tests.csproj",
}

PACKAGE_VERSION_RE = re.compile(
    r'<PackageVersion\s+Include="([^"]+)"\s+Version="([^"]+)"', re.IGNORECASE)
PACKAGE_REFERENCE_RE = re.compile(r'<PackageReference\s+([^>]*?)/?>', re.IGNORECASE)
INCLUDE_RE = re.compile(r'Include="([^"]+)"', re.IGNORECASE)


def git_show(repo_root, commit, path):
    """File contents at a commit, or None when the path did not exist there."""
    result = subprocess.run(["git", "-C", repo_root, "show", f"{commit}:{path}"],
                            capture_output=True, text=True, encoding="utf-8")
    return result.stdout if result.returncode == 0 else None


def referenced_packages(csproj_text):
    """Package ids the benchmark project references directly.

    MSBuild conditions are deliberately ignored rather than evaluated. Every condition in these
    two projects gates on target framework or strong-name signing, and the runs being backfilled
    were all recorded on net10.0 without signing - the case in which every condition holds. An
    id that was in fact excluded resolves to a version nothing ever asks about, which is
    harmless; evaluating MSBuild here would not be.
    """
    ids = set()
    for attributes in PACKAGE_REFERENCE_RE.findall(csproj_text):
        # ExcludeAssets="all" references contribute no code to the benchmark, so they cannot
        # affect a measurement (IndexRange is polyfill-only, for instance).
        if 'ExcludeAssets="all"' in attributes:
            continue
        match = INCLUDE_RE.search(attributes)
        if not match:
            continue
        package_id = match.group(1)
        # MSBuild property references are the packed-package self-reference; skip along with the
        # plain form, since our own version is already identified by the run's code commit.
        if "$(" in package_id or package_id.startswith("CryptoHives.Foundation."):
            continue
        ids.add(package_id)
    return ids


def resolve(repo_root, commit, csproj_path):
    """{package id: version} the given commit's central pins declare for that project."""
    props = git_show(repo_root, commit, "Directory.Packages.props")
    csproj = git_show(repo_root, commit, csproj_path)
    if props is None or csproj is None:
        return None, f"Directory.Packages.props or {csproj_path} missing at {commit[:8]}"

    pins = dict(PACKAGE_VERSION_RE.findall(props))
    wanted = referenced_packages(csproj)

    versions = {}
    unpinned = []
    for package_id in sorted(wanted):
        if package_id in pins:
            versions[package_id] = pins[package_id]
        else:
            unpinned.append(package_id)

    if not versions:
        return None, "no referenced package matched a central pin"
    note = f"unpinned: {', '.join(unpinned)}" if unpinned else None
    return versions, note


def main():
    parser = argparse.ArgumentParser(description=__doc__,
                                     formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument("--archive", required=True, help="Root of the run archive (benchmarks-branch worktree)")
    parser.add_argument("--repo", default=os.path.dirname(os.path.dirname(os.path.abspath(__file__))),
                        help="Repository the code commits live in (defaults to this checkout)")
    parser.add_argument("--dry-run", action="store_true", help="Report without writing")
    args = parser.parse_args()

    written = skipped = failed = 0

    for package_dir, csproj_path in sorted(PROJECTS.items()):
        package_root = os.path.join(args.archive, package_dir)
        if not os.path.isdir(package_root):
            continue

        for run_id in sorted(os.listdir(package_root)):
            run_root = os.path.join(package_root, run_id)
            if not os.path.isdir(run_root):
                continue
            for platform in sorted(os.listdir(run_root)):
                platform_root = os.path.join(run_root, platform)
                if not os.path.isdir(platform_root):
                    continue
                # The archive nests a framework level under the platform, since the same commit
                # on the same machine under two target frameworks is two distinct runs.
                for framework in sorted(os.listdir(platform_root)):
                    metadata_path = os.path.join(platform_root, framework, "run.json")
                    if not os.path.isfile(metadata_path):
                        continue

                    with open(metadata_path, encoding="utf-8") as handle:
                        metadata = json.load(handle)

                    label = f"{package_dir}/{run_id}/{platform}/{framework}"
                    if metadata.get("packages"):
                        print(f"  [skip] {label}: already has {len(metadata['packages'])} package(s)")
                        skipped += 1
                        continue

                    commit = metadata.get("codeCommit")
                    if not commit:
                        print(f"  [fail] {label}: no codeCommit", file=sys.stderr)
                        failed += 1
                        continue

                    versions, note = resolve(args.repo, commit, csproj_path)
                    if versions is None:
                        print(f"  [fail] {label}: {note}", file=sys.stderr)
                        failed += 1
                        continue

                    metadata["packagesSource"] = "Directory.Packages.props"
                    metadata["packages"] = versions

                    if args.dry_run:
                        print(f"  [dry-run] {label}: {len(versions)} package(s)"
                              + (f"  ({note})" if note else ""))
                    else:
                        with open(metadata_path, "w", encoding="utf-8", newline="\n") as handle:
                            json.dump(metadata, handle, indent=2)
                            handle.write("\n")
                        print(f"  [ok] {label}: {len(versions)} package(s)"
                              + (f"  ({note})" if note else ""))
                    written += 1

    verb = "Would write" if args.dry_run else "Wrote"
    print(f"{verb} {written}, skipped {skipped}, failed {failed}")
    return 1 if failed else 0


if __name__ == "__main__":
    raise SystemExit(main())
