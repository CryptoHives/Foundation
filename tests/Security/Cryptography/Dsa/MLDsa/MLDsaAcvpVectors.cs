// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MLDsa;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Loads the NIST ACVP conformance vectors for ML-DSA (FIPS 204) from the embedded
/// <c>mldsa-acvp-fips204.json.gz</c> resource.
/// </summary>
/// <remarks>
/// <para>
/// The file holds NIST's own ACVP JSON, in its own schema: an envelope carrying provenance plus
/// the upstream keyGen, sigGen and sigVer documents, each with its <c>testGroups</c> and
/// <c>tests</c> arrays as published. The only transformation the generator applies is dropping
/// whole groups there is no implementation for, so enabling one later is a filter change rather
/// than a file-format change.
/// </para>
/// <para>
/// What is kept is every ACVP-Server case the library can run: 25 key generation cases per
/// parameter set, 15 signature generation cases per parameter set for each of the deterministic
/// and hedged variants, and 15 verification cases per parameter set. The pre-hash (HashML-DSA),
/// internal-interface and external-μ groups are filtered out at generation time.
/// </para>
/// </remarks>
public static class MLDsaAcvpVectors
{
    /// <summary>
    /// Name of the embedded resource holding the vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.mldsa-acvp-fips204.json.gz";

    private static readonly Lazy<Records> Loaded = new(Load);

    /// <summary>
    /// Gets the key generation vectors: parameter set, tcId, seed, pk, sk.
    /// </summary>
    public static IEnumerable<TestCaseData> KeyGen => Build(Loaded.Value.KeyGen, "KeyGen");

    /// <summary>
    /// Gets the deterministic signing vectors: parameter set, tcId, sk, message, context, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenDeterministic
        => Build(Loaded.Value.SigGenDeterministic, "SigGenDet");

    /// <summary>
    /// Gets the hedged signing vectors: parameter set, tcId, sk, message, context, rnd, signature.
    /// </summary>
    public static IEnumerable<TestCaseData> SigGenHedged
        => Build(Loaded.Value.SigGenHedged, "SigGenHedged");

    /// <summary>
    /// Gets every signing vector without the variant-specific randomness: parameter set, tcId,
    /// sk, message, context, signature.
    /// </summary>
    /// <remarks>
    /// Used by the tests that drive the key-holding <c>MLDsa</c> API, which signs hedged-only
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
    /// <param name="rows">The parsed rows, each already in test-argument order.</param>
    /// <param name="prefix">The test name prefix.</param>
    /// <returns>The test cases.</returns>
    private static IEnumerable<TestCaseData> Build(List<object[]> rows, string prefix)
    {
        foreach (object[] row in rows)
        {
            yield return new TestCaseData(row).SetName($"{prefix}_{row[0]}_tc{row[1]}");
        }
    }

    /// <summary>
    /// Reads and parses the embedded vector file.
    /// </summary>
    /// <returns>The parsed records.</returns>
    private static Records Load()
    {
        var records = new Records();

        Assembly assembly = typeof(MLDsaAcvpVectors).Assembly;
        using Stream? stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException(
                $"Embedded resource '{ResourceName}' was not found. Available: "
                + string.Join(", ", assembly.GetManifestResourceNames()));

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
                                Text(test, "seed"), Text(test, "pk"), Text(test, "sk")]);
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
            throw new InvalidOperationException("ML-DSA ACVP vector file parsed to no vectors.");
        }

        return records;
    }

    /// <summary>
    /// Records one signature generation case under both the variant-specific list and the
    /// combined one.
    /// </summary>
    /// <remarks>
    /// <c>deterministic</c> lives on the group rather than the case, and ACVP omits <c>rnd</c>
    /// for the deterministic groups because FIPS 204 fixes it to 32 zero bytes there.
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
                [parameterSet, tcId, sk, message, context, Text(test, "rnd"), signature]);
        }

        records.SigGen.Add([parameterSet, tcId, sk, message, context, signature]);
    }

    /// <summary>
    /// Reads a string property, treating an absent one as empty.
    /// </summary>
    /// <remarks>
    /// ACVP omits fields that do not apply to a group rather than emitting them empty —
    /// <c>context</c> on some groups, <c>rnd</c> on the deterministic ones, <c>reason</c> on
    /// passing cases.
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
        public List<object[]> KeyGen { get; } = [];

        public List<object[]> SigGenDeterministic { get; } = [];

        public List<object[]> SigGenHedged { get; } = [];

        public List<object[]> SigGen { get; } = [];

        public List<object[]> SigVer { get; } = [];
    }
}
