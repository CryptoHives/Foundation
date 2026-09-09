// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Loads the NIST ACVP conformance vectors for HashSLH-DSA (FIPS 205 §10.2).
/// </summary>
/// <remarks>
/// <para>
/// A sibling of <see cref="SlhDsaAcvpVectors"/>, reading the same NIST ACVP JSON schema from a
/// separate gzip-compressed file. The two are kept apart deliberately: the pre-hash groups are
/// selected by a different rule, and folding them into the pure file would rewrite an
/// already-committed 2.15 MB blob every time either set is regenerated.
/// </para>
/// <para>
/// The size problem is sharper here than anywhere else in the suite. The runnable pre-hash set
/// is 456 cases and 15.9 MB gzipped, and even the full cross product of 12 parameter sets by 12
/// approved pre-hash functions would be 144 sigGen cases and roughly 5 MB. The committed
/// selection is therefore 37 cases (~1.38 MB), chosen by rotation: sigGen assigns each parameter
/// set a different pre-hash function by index, covering all 12 sets and all 12 functions in 24
/// cases; sigVer keeps the valid case on that same rotation plus every failure reason on
/// <c>SLH-DSA-SHA2-128f</c> and <c>SLH-DSA-SHAKE-256f</c>, which span both hash instantiations
/// and the SHA-512 split. See <c>scripts/fetch-slhdsa-acvp-vectors.py</c> for the exact rule.
/// </para>
/// <para>
/// Nothing is permanently unreachable. Running that script with <c>--profile prehash-full</c>
/// writes the complete 456-case file, and this loader picks it up from
/// <see cref="OverrideVariable"/> or from its default location in the repository. The weekly
/// <c>acvp-full-vectors</c> workflow does exactly that.
/// </para>
/// </remarks>
public static class SlhDsaPreHashAcvpVectors
{
    /// <summary>
    /// Environment variable naming an alternative vector file, which takes precedence over
    /// everything else.
    /// </summary>
    public const string OverrideVariable = "CRYPTOHIVES_SLHDSA_PREHASH_ACVP_VECTORS";

    /// <summary>
    /// Number of cases in the committed selection. The loaded set must never fall below this:
    /// an override is meant to add coverage, never to remove it.
    /// </summary>
    public const int StratifiedCaseCount = 37;

    /// <summary>
    /// Name of the embedded resource holding the committed vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.slhdsa-prehash-acvp-fips205.json.gz";

    /// <summary>
    /// Repository-relative location the <c>--profile prehash-full</c> script writes to.
    /// </summary>
    private const string FullVectorsRelativePath =
        "tests/Security/Cryptography/TestData/slhdsa-prehash-acvp-fips205.full.json.gz";

    private static readonly Lazy<Records> Loaded = new(Load);

    /// <summary>
    /// Gets a description of where the loaded vectors came from, for the run log.
    /// </summary>
    public static string Source => Loaded.Value.Source;

    /// <summary>
    /// Gets the total number of loaded cases across both modes.
    /// </summary>
    public static int CaseCount => Loaded.Value.SigGen.Count + Loaded.Value.SigVer.Count;

    /// <summary>
    /// Gets the deterministic pre-hash signing vectors: parameter set, tcId, hashAlg, sk,
    /// message, context, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenDeterministic
        => Build(Loaded.Value.SigGenDeterministic, "SigGenPreHashDet");

    /// <summary>
    /// Gets the hedged pre-hash signing vectors: parameter set, tcId, hashAlg, sk, message,
    /// context, additionalRandomness, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenHedged
        => Build(Loaded.Value.SigGenHedged, "SigGenPreHashHedged");

    /// <summary>
    /// Gets every pre-hash signing vector without the variant-specific randomness: parameter
    /// set, tcId, hashAlg, sk, message, context, signature.
    /// </summary>
    /// <remarks>
    /// Used by the tests that drive the key-holding <c>SlhDsa</c> API, which signs hedged-only
    /// and so cannot reproduce a byte-exact signature — it verifies the ACVP one instead, for
    /// which the deterministic and hedged cases are interchangeable.
    /// </remarks>
    public static IEnumerable<TestCaseData> SigGen => Build(Loaded.Value.SigGen, "SigGenPreHash");

    /// <summary>
    /// Gets the pre-hash verification vectors: parameter set, tcId, hashAlg, reason, expected,
    /// pk, message, context, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigVer => Build(Loaded.Value.SigVer, "SigVerPreHash");

    /// <summary>
    /// Wraps parsed fields as NUnit cases, naming each after its parameter set, pre-hash
    /// function and tcId so a failure identifies the original ACVP case without opening the
    /// data file.
    /// </summary>
    /// <remarks>
    /// Cases for the <c>s</c> parameter sets are categorized <c>Slow</c>. Signing with those
    /// costs on the order of a million hash invocations, so a run that only needs a quick pass
    /// can exclude them with <c>--filter "TestCategory!=Slow"</c>. They still run by default.
    /// </remarks>
    /// <param name="rows">The parsed rows, each already in test-argument order.</param>
    /// <param name="prefix">The test name prefix.</param>
    /// <returns>The test cases.</returns>
    private static IEnumerable<TestCaseData> Build(List<object[]> rows, string prefix)
    {
        foreach (object[] row in rows)
        {
            string parameterSet = (string)row[0];

            // The slash in SHA2-512/224 would read as a path separator in a test name.
            string hashAlg = ((string)row[2]).Replace("/", "-");
            var data = new TestCaseData(row).SetName($"{prefix}_{parameterSet}_{hashAlg}_tc{row[1]}");

            if (parameterSet[^1] == 's')
            {
                data = data.SetCategory("Slow");
            }

            yield return data;
        }
    }

    /// <summary>
    /// Opens the vector file, preferring an on-demand full set over the embedded one.
    /// </summary>
    /// <param name="source">Receives a description of what was opened.</param>
    /// <returns>The compressed stream.</returns>
    private static Stream Open(out string source)
    {
        string? configured = Environment.GetEnvironmentVariable(OverrideVariable);
        if (!string.IsNullOrEmpty(configured))
        {
            if (!File.Exists(configured))
            {
                throw new FileNotFoundException(
                    $"{OverrideVariable} points at '{configured}', which does not exist. Generate it with: "
                    + "python scripts/fetch-slhdsa-acvp-vectors.py --profile prehash-full", configured);
            }

            source = $"{OverrideVariable}={configured}";
            return File.OpenRead(configured!);
        }

        string? full = FindInRepository();
        if (full is not null)
        {
            source = full;
            return File.OpenRead(full);
        }

        Assembly assembly = typeof(SlhDsaPreHashAcvpVectors).Assembly;
        source = $"embedded {ResourceName}";
        return assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException(
                $"Embedded resource '{ResourceName}' was not found. Available: "
                + string.Join(", ", assembly.GetManifestResourceNames()));
    }

    /// <summary>
    /// Looks for a full vector file at its default location in the repository.
    /// </summary>
    /// <remarks>
    /// Walks up from the test binaries rather than requiring an environment variable, so that
    /// running the fetch script and then <c>dotnet test</c> just works. Returns
    /// <see langword="null"/> outside a source checkout, which is the normal case.
    /// </remarks>
    /// <returns>The path, or <see langword="null"/> when there is none.</returns>
    private static string? FindInRepository()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            string candidate = Path.Combine(directory.FullName,
                FullVectorsRelativePath.Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(candidate))
            {
                return candidate;
            }

            directory = directory.Parent;
        }

        return null;
    }

    /// <summary>
    /// Reads and parses the vector file.
    /// </summary>
    /// <returns>The parsed records.</returns>
    private static Records Load()
    {
        using Stream stream = Open(out string source);
        var records = new Records(source);

        using var decompressed = new GZipStream(stream, CompressionMode.Decompress);
        using JsonDocument json = JsonDocument.Parse(decompressed);

        foreach (JsonElement document in json.RootElement.GetProperty("documents").EnumerateArray())
        {
            // Each document is an upstream ACVP file and names its own mode.
            string mode = document.GetProperty("mode").GetString()!;

            foreach (JsonElement group in document.GetProperty("testGroups").EnumerateArray())
            {
                string parameterSet = group.GetProperty("parameterSet").GetString()!;

                foreach (JsonElement test in group.GetProperty("tests").EnumerateArray())
                {
                    int tcId = test.GetProperty("tcId").GetInt32();
                    string hashAlg = Text(test, "hashAlg");

                    switch (mode)
                    {
                        case "sigGen":
                            AddSigGen(records, group, parameterSet, tcId, hashAlg, test);
                            break;

                        case "sigVer":
                            records.SigVer.Add([
                                parameterSet, tcId, hashAlg,
                                Text(test, "reason"), test.GetProperty("testPassed").GetBoolean(),
                                Text(test, "pk"), Text(test, "message"), Text(test, "context"),
                                Text(test, "signature")]);
                            break;

                        default:
                            throw new InvalidOperationException($"Unknown ACVP mode '{mode}'.");
                    }
                }
            }
        }

        if (records.SigGen.Count == 0 || records.SigVer.Count == 0)
        {
            throw new InvalidOperationException(
                $"HashSLH-DSA ACVP vector file ({source}) parsed to no vectors.");
        }

        TestContext.Progress.WriteLine(
            $"HashSLH-DSA ACVP vectors: {records.SigGen.Count + records.SigVer.Count} cases from {source}");

        return records;
    }

    /// <summary>
    /// Records one signature generation case under both the variant-specific list and the
    /// combined one.
    /// </summary>
    /// <remarks>
    /// <c>deterministic</c> lives on the group rather than the case, and ACVP omits
    /// <c>additionalRandomness</c> for the deterministic groups because FIPS 205 fixes opt_rand
    /// to PK.seed there.
    /// </remarks>
    private static void AddSigGen(Records records, JsonElement group, string parameterSet, int tcId,
                                  string hashAlg, JsonElement test)
    {
        string sk = Text(test, "sk");
        string message = Text(test, "message");
        string context = Text(test, "context");
        string signature = Text(test, "signature");

        if (group.GetProperty("deterministic").GetBoolean())
        {
            records.SigGenDeterministic.Add(
                [parameterSet, tcId, hashAlg, sk, message, context, signature]);
        }
        else
        {
            records.SigGenHedged.Add([
                parameterSet, tcId, hashAlg, sk, message, context,
                Text(test, "additionalRandomness"), signature]);
        }

        records.SigGen.Add([parameterSet, tcId, hashAlg, sk, message, context, signature]);
    }

    /// <summary>
    /// Reads a string property, treating an absent one as empty.
    /// </summary>
    /// <remarks>
    /// ACVP omits fields that do not apply to a group rather than emitting them empty —
    /// <c>context</c> on some groups, <c>additionalRandomness</c> on the deterministic ones.
    /// </remarks>
    /// <param name="element">The test case object.</param>
    /// <param name="name">The property name.</param>
    /// <returns>The value, or an empty string when absent or null.</returns>
    private static string Text(JsonElement element, string name)
        => element.TryGetProperty(name, out JsonElement value) ? value.GetString() ?? string.Empty : string.Empty;

    /// <summary>
    /// The parsed vector file.
    /// </summary>
    private sealed class Records
    {
        public Records(string source) => Source = source;

        public string Source { get; }

        public List<object[]> SigGenDeterministic { get; } = [];

        public List<object[]> SigGenHedged { get; } = [];

        public List<object[]> SigGen { get; } = [];

        public List<object[]> SigVer { get; } = [];
    }
}
