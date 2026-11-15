#!/usr/bin/env bash
# Creates the project that hosts Program.cs for the Mono runtime tests.
# Usage: create-host.sh <dotnet new template> <output directory>
#
# The host lives outside the repository so the repository's central package management and
# warnings-as-errors settings do not apply to the generated template.
set -euo pipefail

template=$1
host=$2
repo=$(cd "$(dirname "$0")/../.." && pwd)
nunit=$(grep -oP '<PackageVersion Include="NUnit" Version="\K[^"]+' "$repo/Directory.Packages.props")

dotnet new "$template" -o "$host" -n TestHost
dotnet add "$host" package NUnit --version "$nunit"
cp "$repo/.github/mono-test-host/Program.cs" "$host/Program.cs"

# The tests are referenced as a library: an executable referencing another executable is
# otherwise rejected, and only the assembly is needed.
sed -i "s#</Project>#  <PropertyGroup>\n    <ValidateExecutableReferencesMatchSelfContained>false</ValidateExecutableReferencesMatchSelfContained>\n    <InvariantGlobalization>true</InvariantGlobalization>\n  </PropertyGroup>\n  <ItemGroup>\n    <ProjectReference Include=\"$repo/tests/Security/Cryptography/Cryptography.Tests.csproj\" SetTargetFramework=\"TargetFramework=net10.0\" AdditionalProperties=\"MonoRuntimeTests=true\" />\n  </ItemGroup>\n</Project>#" "$host/TestHost.csproj"

cat "$host/TestHost.csproj"
