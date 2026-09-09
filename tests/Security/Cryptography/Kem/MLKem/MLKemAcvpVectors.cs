// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.Json;

/// <summary>
/// Loads the NIST ACVP conformance vectors for ML-KEM (FIPS 203) from the embedded
/// <c>mlkem-acvp-fips203.json.gz</c> resource.
/// </summary>
/// <remarks>
/// <para>
/// The file holds NIST's own ACVP JSON, in its own schema: an envelope carrying provenance plus
/// the upstream keyGen and encapDecap documents, each with its <c>testGroups</c> and
/// <c>tests</c> arrays exactly as published. Nothing is filtered — every ML-KEM group has an
/// implementation to test — so the stored documents are the upstream ones verbatim.
/// </para>
/// <para>
/// That is the complete ACVP-Server set: 25 key generation and 25 encapsulation cases per
/// parameter set, plus 10 each of decapsulation, encapsulation key check and decapsulation key
/// check.
/// </para>
/// </remarks>
public static class MLKemAcvpVectors
{
    /// <summary>
    /// Name of the embedded resource holding the vectors.
    /// </summary>
    private const string ResourceName = "Cryptography.Tests.TestData.mlkem-acvp-fips203.json.gz";

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
        using JsonDocument json = JsonDocument.Parse(decompressed);

        foreach (JsonElement document in json.RootElement.GetProperty("documents").EnumerateArray())
        {
            // Each document is an upstream ACVP file and names its own mode.
            string mode = document.GetProperty("mode").GetString()!;

            foreach (JsonElement group in document.GetProperty("testGroups").EnumerateArray())
            {
                string parameterSet = group.GetProperty("parameterSet").GetString()!;

                // keyGen groups carry no function; encapDecap groups say which of the four.
                string function = mode == "keyGen" ? "keyGen" : Text(group, "function");

                foreach (JsonElement test in group.GetProperty("tests").EnumerateArray())
                {
                    int tcId = test.GetProperty("tcId").GetInt32();

                    switch (function)
                    {
                        case "keyGen":
                            records.KeyGen.Add([
                                parameterSet, tcId,
                                Text(test, "d"), Text(test, "z"), Text(test, "ek"), Text(test, "dk")]);
                            break;

                        case "encapsulation":
                            records.Encaps.Add([
                                parameterSet, tcId,
                                Text(test, "ek"), Text(test, "dk"), Text(test, "m"),
                                Text(test, "c"), Text(test, "k")]);
                            break;

                        case "decapsulation":
                            records.Decaps.Add([
                                parameterSet, tcId, Text(test, "reason"),
                                Text(test, "dk"), Text(test, "c"), Text(test, "k")]);
                            break;

                        case "encapsulationKeyCheck":
                            records.EncapsulationKeyCheck.Add([
                                parameterSet, tcId, test.GetProperty("testPassed").GetBoolean(),
                                Text(test, "reason"), Text(test, "ek")]);
                            break;

                        case "decapsulationKeyCheck":
                            records.DecapsulationKeyCheck.Add([
                                parameterSet, tcId, test.GetProperty("testPassed").GetBoolean(),
                                Text(test, "reason"), Text(test, "dk")]);
                            break;

                        default:
                            throw new InvalidOperationException($"Unknown ACVP function '{function}'.");
                    }
                }
            }
        }

        if (records.KeyGen.Count == 0 || records.Encaps.Count == 0 || records.Decaps.Count == 0)
        {
            throw new InvalidOperationException("ML-KEM ACVP vector file parsed to no vectors.");
        }

        return records;
    }

    /// <summary>
    /// Reads a string property, treating an absent one as empty.
    /// </summary>
    /// <remarks>
    /// ACVP omits fields that do not apply rather than emitting them empty — most visibly
    /// <c>reason</c>, which is present only on the cases that are expected to fail.
    /// </remarks>
    /// <param name="element">The object to read from.</param>
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

        public List<object[]> Encaps { get; } = [];

        public List<object[]> Decaps { get; } = [];

        public List<object[]> EncapsulationKeyCheck { get; } = [];

        public List<object[]> DecapsulationKeyCheck { get; } = [];
    }
}
