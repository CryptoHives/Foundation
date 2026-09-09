// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Loads the NIST ACVP conformance vectors for SLH-DSA (FIPS 205).
/// </summary>
/// <remarks>
/// <para>
/// The file holds NIST's own ACVP JSON, in its own schema: an envelope carrying provenance plus
/// the upstream keyGen, sigGen and sigVer documents, each with its <c>testGroups</c> and
/// <c>tests</c> arrays as published — the same shape <see cref="MLDsa.MLDsaAcvpVectors"/> reads.
/// </para>
/// <para>
/// SLH-DSA differs from ML-DSA in one respect: the full runnable set cannot be committed. Its
/// signatures run from 7,856 to 49,856 bytes, so the same "external interface, pure, no pre-hash"
/// filter that trims ML-DSA to 2.5 MB leaves SLH-DSA at 11.8 MB. The embedded resource therefore
/// carries a stratified 180-case selection (~2.15 MB): every parameter set in keyGen and sigGen,
/// and in sigVer one valid case per set plus the complete failure-reason matrix on four
/// representative sets. See <c>scripts/fetch-slhdsa-acvp-vectors.py</c> for the exact rule.
/// </para>
/// <para>
/// Nothing is permanently unreachable. Running that script with <c>--profile full</c> writes the
/// complete 456-case file, and this loader picks it up from
/// <c>CRYPTOHIVES_SLHDSA_ACVP_VECTORS</c> or from its default location in the repository. The
/// weekly <c>acvp-full-vectors</c> workflow does exactly that, so every vector is still executed
/// on a schedule.
/// </para>
/// </remarks>
public static class SlhDsaAcvpVectors
{
    /// <summary>
    /// Environment variable naming an alternative vector file, which takes precedence over
    /// everything else.
    /// </summary>
    public const string OverrideVariable = "CRYPTOHIVES_SLHDSA_ACVP_VECTORS";

    /// <summary>
    /// Number of cases in the committed stratified selection. The loaded set must never fall
    /// below this: an override is meant to add coverage, never to remove it.
    /// </summary>
    public const int StratifiedCaseCount = 180;

    /// <summary>
    /// Name of the embedded resource holding the stratified vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.slhdsa-acvp-fips205.json.gz";

    /// <summary>
    /// Repository-relative location the <c>--profile full</c> script writes to.
    /// </summary>
    private const string FullVectorsRelativePath =
        "tests/Security/Cryptography/TestData/slhdsa-acvp-fips205.full.json.gz";

    private static readonly Lazy<Records> Loaded = new(Load);

    /// <summary>
    /// Gets a description of where the loaded vectors came from, for the run log.
    /// </summary>
    public static string Source => Loaded.Value.Source;

    /// <summary>
    /// Gets the total number of loaded cases across all three modes.
    /// </summary>
    public static int CaseCount
        => Loaded.Value.KeyGen.Count + Loaded.Value.SigGen.Count + Loaded.Value.SigVer.Count;

    /// <summary>
    /// Gets the key generation vectors: parameter set, tcId, skSeed, skPrf, pkSeed, pk, sk.
    /// </summary>
    public static IEnumerable<TestCaseData> KeyGen => Build(Loaded.Value.KeyGen, "KeyGen");

    /// <summary>
    /// Gets the deterministic signing vectors: parameter set, tcId, sk, message, context, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenDeterministic
        => Build(Loaded.Value.SigGenDeterministic, "SigGenDet");

    /// <summary>
    /// Gets the hedged signing vectors: parameter set, tcId, sk, message, context,
    /// additionalRandomness, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenHedged
        => Build(Loaded.Value.SigGenHedged, "SigGenHedged");

    /// <summary>
    /// Gets every signing vector without the variant-specific randomness: parameter set, tcId,
    /// sk, message, context, signature.
    /// </summary>
    /// <remarks>
    /// Used by the tests that drive the key-holding <c>SlhDsa</c> API, which signs hedged-only
    /// and so cannot reproduce a byte-exact signature — it verifies the ACVP one instead, for
    /// which the deterministic and hedged cases are interchangeable.
    /// </remarks>
    public static IEnumerable<TestCaseData> SigGen => Build(Loaded.Value.SigGen, "SigGen");

    /// <summary>
    /// Gets the verification vectors: parameter set, tcId, reason, expected, pk, message,
    /// context, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigVer => Build(Loaded.Value.SigVer, "SigVer");

    /// <summary>
    /// Maps an ACVP parameter set name to its algorithm descriptor.
    /// </summary>
    /// <param name="parameterSet">The ACVP name, e.g. <c>SLH-DSA-SHAKE-128f</c>.</param>
    /// <returns>The matching descriptor.</returns>
    /// <exception cref="ArgumentException">The name is not a FIPS 205 parameter set.</exception>
    public static SlhDsaAlgorithm AlgorithmFor(string parameterSet) => parameterSet switch {
        "SLH-DSA-SHA2-128s" => SlhDsaAlgorithm.SlhDsaSha2_128s,
        "SLH-DSA-SHAKE-128s" => SlhDsaAlgorithm.SlhDsaShake128s,
        "SLH-DSA-SHA2-128f" => SlhDsaAlgorithm.SlhDsaSha2_128f,
        "SLH-DSA-SHAKE-128f" => SlhDsaAlgorithm.SlhDsaShake128f,
        "SLH-DSA-SHA2-192s" => SlhDsaAlgorithm.SlhDsaSha2_192s,
        "SLH-DSA-SHAKE-192s" => SlhDsaAlgorithm.SlhDsaShake192s,
        "SLH-DSA-SHA2-192f" => SlhDsaAlgorithm.SlhDsaSha2_192f,
        "SLH-DSA-SHAKE-192f" => SlhDsaAlgorithm.SlhDsaShake192f,
        "SLH-DSA-SHA2-256s" => SlhDsaAlgorithm.SlhDsaSha2_256s,
        "SLH-DSA-SHAKE-256s" => SlhDsaAlgorithm.SlhDsaShake256s,
        "SLH-DSA-SHA2-256f" => SlhDsaAlgorithm.SlhDsaSha2_256f,
        "SLH-DSA-SHAKE-256f" => SlhDsaAlgorithm.SlhDsaShake256f,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    /// <summary>
    /// Converts a hexadecimal string to bytes.
    /// </summary>
    /// <param name="hex">The hexadecimal string.</param>
    /// <returns>The decoded bytes.</returns>
    public static byte[] FromHex(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }

        return bytes;
    }

    /// <summary>
    /// Wraps parsed fields as NUnit cases, naming each after its parameter set and tcId so a
    /// failure identifies the original ACVP case without opening the data file.
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
            var data = new TestCaseData(row).SetName($"{prefix}_{parameterSet}_tc{row[1]}");

            if (parameterSet[^1] == 's')
            {
                data = data.SetCategory("Slow");
            }

            yield return data;
        }
    }

    /// <summary>
    /// Opens the vector file, preferring an on-demand full set over the embedded stratified one.
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
                    $"{OverrideVariable} points at '{configured}', which does not exist. Generate it "
                    + "with: python scripts/fetch-slhdsa-acvp-vectors.py --profile full", configured);
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

        Assembly assembly = typeof(SlhDsaAcvpVectors).Assembly;
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

                    switch (mode)
                    {
                        case "keyGen":
                            records.KeyGen.Add([
                                parameterSet, tcId,
                                Text(test, "skSeed"), Text(test, "skPrf"), Text(test, "pkSeed"),
                                Text(test, "pk"), Text(test, "sk")]);
                            break;

                        case "sigGen":
                            AddSigGen(records, group, parameterSet, tcId, test);
                            break;

                        case "sigVer":
                            records.SigVer.Add([
                                parameterSet, tcId,
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

        if (records.KeyGen.Count == 0 || records.SigGen.Count == 0 || records.SigVer.Count == 0)
        {
            throw new InvalidOperationException(
                $"SLH-DSA ACVP vector file ({source}) parsed to no vectors.");
        }

        TestContext.Progress.WriteLine(
            $"SLH-DSA ACVP vectors: {records.KeyGen.Count + records.SigGen.Count + records.SigVer.Count} "
            + $"cases from {source}");

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
    private static void AddSigGen(Records records, JsonElement group, string parameterSet, int tcId, JsonElement test)
    {
        string sk = Text(test, "sk");
        string message = Text(test, "message");
        string context = Text(test, "context");
        string signature = Text(test, "signature");

        if (group.GetProperty("deterministic").GetBoolean())
        {
            records.SigGenDeterministic.Add([parameterSet, tcId, sk, message, context, signature]);
        }
        else
        {
            records.SigGenHedged.Add(
                [parameterSet, tcId, sk, message, context, Text(test, "additionalRandomness"), signature]);
        }

        records.SigGen.Add([parameterSet, tcId, sk, message, context, signature]);
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

        public List<object[]> KeyGen { get; } = [];

        public List<object[]> SigGenDeterministic { get; } = [];

        public List<object[]> SigGenHedged { get; } = [];

        public List<object[]> SigGen { get; } = [];

        public List<object[]> SigVer { get; } = [];
    }
}
