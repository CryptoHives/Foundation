// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;

/// <summary>
/// Loads the NIST ACVP conformance vectors for ML-KEM (FIPS 203) from the embedded
/// <c>mlkem-acvp-fips203.txt</c> resource.
/// </summary>
/// <remarks>
/// <para>
/// The vectors are the complete ACVP-Server set -- 25 key generation and 25 encapsulation
/// cases per parameter set, plus 10 each of decapsulation, encapsulation key check and
/// decapsulation key check -- rather than a curated handful. They live in a data file rather
/// than in C# literals because ML-KEM-1024 alone carries roughly 9.6 KB of hex per key
/// generation case; inline they would dominate the test source.
/// </para>
/// <para>
/// The file is pipe-delimited rather than JSON so it parses with <c>String.Split</c> on every
/// target framework: the test project also targets net48, where <c>System.Text.Json</c> would
/// need an extra package reference. It is gzip-compressed because the flattened vectors are
/// about 1.7 MB of hex, which compresses to roughly 770 KB. Regenerate it with
/// <c>scripts/fetch-mlkem-acvp-vectors.py</c>, which zeroes the gzip mtime so unchanged
/// vectors round-trip to a byte-identical file; the decompressed header records its
/// provenance.
/// </para>
/// </remarks>
public static class MLKemAcvpVectors
{
    /// <summary>
    /// Name of the embedded resource holding the vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.mlkem-acvp-fips203.txt.gz";

    private static readonly Lazy<Records> Loaded = new(Load);

    /// <summary>
    /// Gets the key generation vectors: parameter set, tcId, d, z, ek, dk.
    /// </summary>
    public static IEnumerable<TestCaseData> KeyGen => Build(Loaded.Value.KeyGen, "KeyGen");

    /// <summary>
    /// Gets the encapsulation vectors: parameter set, tcId, ek, dk, m, c, k.
    /// </summary>
    public static IEnumerable<TestCaseData> Encaps => Build(Loaded.Value.Encaps, "Encaps");

    /// <summary>
    /// Gets the decapsulation vectors: parameter set, tcId, reason, dk, c, k.
    /// </summary>
    public static IEnumerable<TestCaseData> Decaps => Build(Loaded.Value.Decaps, "Decaps");

    /// <summary>
    /// Gets the encapsulation key check vectors: parameter set, tcId, expected, reason, ek.
    /// </summary>
    public static IEnumerable<TestCaseData> EncapsulationKeyCheck
        => Build(Loaded.Value.EncapsulationKeyCheck, "EkCheck");

    /// <summary>
    /// Gets the decapsulation key check vectors: parameter set, tcId, expected, reason, dk.
    /// </summary>
    public static IEnumerable<TestCaseData> DecapsulationKeyCheck
        => Build(Loaded.Value.DecapsulationKeyCheck, "DkCheck");

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

        Assembly assembly = typeof(MLKemAcvpVectors).Assembly;
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
                    records.KeyGen.Add([f[1], int.Parse(f[2], CultureInfo.InvariantCulture), f[3], f[4], f[5], f[6]]);
                    break;
                case "E":
                    records.Encaps.Add([f[1], int.Parse(f[2], CultureInfo.InvariantCulture), f[3], f[4], f[5], f[6], f[7]]);
                    break;
                case "D":
                    records.Decaps.Add([f[1], int.Parse(f[2], CultureInfo.InvariantCulture), f[3], f[4], f[5], f[6]]);
                    break;
                case "X":
                    records.EncapsulationKeyCheck.Add(
                        [f[1], int.Parse(f[2], CultureInfo.InvariantCulture), bool.Parse(f[3]), f[4], f[5]]);
                    break;
                case "Y":
                    records.DecapsulationKeyCheck.Add(
                        [f[1], int.Parse(f[2], CultureInfo.InvariantCulture), bool.Parse(f[3]), f[4], f[5]]);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown record kind '{f[0]}'.");
            }
        }

        if (records.KeyGen.Count == 0 || records.Encaps.Count == 0 || records.Decaps.Count == 0)
        {
            throw new InvalidOperationException("ML-KEM ACVP vector file parsed to no vectors.");
        }

        return records;
    }

    /// <summary>
    /// The parsed vector file.
    /// </summary>
    private sealed class Records
    {
        public List<object[]> KeyGen { get; } = [];

        public List<object[]> Encaps { get; } = [];

        public List<object[]> Decaps { get; } = [];

        public List<object[]> EncapsulationKeyCheck { get; } = [];

        public List<object[]> DecapsulationKeyCheck { get; } = [];
    }
}
