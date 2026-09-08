// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MLDsa;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;

/// <summary>
/// Loads the NIST ACVP conformance vectors for ML-DSA (FIPS 204) from the embedded
/// <c>mldsa-acvp-fips204.txt.gz</c> resource.
/// </summary>
/// <remarks>
/// <para>
/// The vectors are every ACVP-Server case the library can run -- 25 key generation cases per
/// parameter set, 15 signature generation cases per parameter set for each of the deterministic
/// and hedged variants, and 15 verification cases per parameter set -- rather than a curated
/// handful. The ACVP files also carry pre-hash (HashML-DSA), internal-interface and external-mu
/// groups; those are filtered out at generation time because there is no implementation to test
/// them against yet.
/// </para>
/// <para>
/// They live in a data file rather than in C# literals because ACVP messages run to several
/// kilobytes each and ML-DSA-87 carries a 4.6 KB signature per case; inline they added up to
/// 448 KB of test source that dwarfed the tests themselves.
/// </para>
/// <para>
/// The file is pipe-delimited rather than JSON so it parses with <c>String.Split</c> on every
/// target framework: the test project also targets net48, where <c>System.Text.Json</c> would
/// need an extra package reference. It is gzip-compressed because the flattened vectors are
/// about 3.7 MB of hex, which compresses to roughly 2.1 MB. Regenerate it with
/// <c>scripts/fetch-mldsa-acvp-vectors.py</c>, which zeroes the gzip mtime so unchanged vectors
/// round-trip to a byte-identical file; the decompressed header records its provenance.
/// </para>
/// </remarks>
public static class MLDsaAcvpVectors
{
    /// <summary>
    /// Name of the embedded resource holding the vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.mldsa-acvp-fips204.txt.gz";

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
        using var reader = new StreamReader(decompressed);

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            if (line.Length == 0 || line[0] == '#')
            {
                continue;
            }

            string[] f = line.Split('|');
            switch (f[0])
            {
                case "K":
                    records.KeyGen.Add([f[1], Id(f[2]), f[3], f[4], f[5]]);
                    break;
                case "S":
                    // S|set|tcId|deterministic|sk|message|context|rnd|signature
                    if (bool.Parse(f[3]))
                    {
                        records.SigGenDeterministic.Add([f[1], Id(f[2]), f[4], f[5], f[6], f[8]]);
                    }
                    else
                    {
                        records.SigGenHedged.Add([f[1], Id(f[2]), f[4], f[5], f[6], f[7], f[8]]);
                    }

                    records.SigGen.Add([f[1], Id(f[2]), f[4], f[5], f[6], f[8]]);
                    break;
                case "V":
                    // V|set|tcId|pass|reason|pk|message|context|signature, reordered so the
                    // reason precedes the expectation in the test signature.
                    records.SigVer.Add(
                        [f[1], Id(f[2]), f[4], bool.Parse(f[3]), f[5], f[6], f[7], f[8]]);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown record kind '{f[0]}'.");
            }
        }

        if (records.KeyGen.Count == 0 || records.SigGen.Count == 0 || records.SigVer.Count == 0)
        {
            throw new InvalidOperationException("ML-DSA ACVP vector file parsed to no vectors.");
        }

        return records;
    }

    private static int Id(string value) => int.Parse(value, CultureInfo.InvariantCulture);

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
