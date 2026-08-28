// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Blake;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Tests for BLAKE3 derive-key mode (<see cref="Blake3Mode.DeriveKey"/>).
/// </summary>
/// <remarks>
/// <para>
/// Vectors are the <c>derive_key</c> column of the upstream BLAKE3 project's
/// <c>test_vectors/test_vectors.json</c>, under that file's own context string
/// (<see cref="OfficialContext"/>). Input is the same deterministic pattern the rest of the
/// BLAKE3 suite uses: byte <c>i</c> is <c>i mod 251</c>.
/// </para>
/// <para>
/// Derive-key is the one BLAKE3 mode with two passes -- the context string is hashed under
/// <c>DERIVE_KEY_CONTEXT</c> to produce a 32-byte key, which then seeds a
/// <c>DERIVE_KEY_MATERIAL</c> pass over the key material. The realistic failure mode is a SIMD
/// kernel carrying the wrong flag word into one of those passes, which is what the tier
/// cross-checks below are for.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Blake3DeriveKeyTests
{
    /// <summary>
    /// The context string used by the upstream test vector file.
    /// </summary>
    private const string OfficialContext = "BLAKE3 2019-12-27 16:29:52 test vectors context";

    /// <summary>
    /// Generates the standard BLAKE3 test input pattern: byte <c>i</c> is <c>i mod 251</c>.
    /// </summary>
    /// <param name="length">The input length.</param>
    /// <returns>The generated input.</returns>
    private static byte[] GenerateTestInput(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++)
        {
            input[i] = (byte)(i % 251);
        }

        return input;
    }

    /// <summary>
    /// Official derive-key vectors, truncated to the default 32-byte output.
    /// </summary>
    public static System.Collections.IEnumerable OfficialDeriveKeyVectors
    {
        get
        {
            var vectors = new (int length, string expected)[]
            {
                (0, "2cc39783c223154fea8dfb7c1b1660f2ac2dcbd1c1de8277b0b0dd39b7e50d7d"),
                (1, "b3e2e340a117a499c6cf2398a19ee0d29cca2bb7404c73063382693bf66cb06c"),
                (2, "1f166565a7df0098ee65922d7fea425fb18b9943f19d6161e2d17939356168e6"),
                (3, "440aba35cb006b61fc17c0529255de438efc06a8c9ebf3f2ddac3b5a86705797"),
                (4, "f46085c8190d69022369ce1a18880e9b369c135eb93f3c63550d3e7630e91060"),
                (5, "1f24eda69dbcb752847ec3ebb5dd42836d86e58500c7c98d906ecd82ed9ae47f"),
                (6, "be96b30b37919fe4379dfbe752ae77b4f7e2ab92f7ff27435f76f2f065f6a5f4"),
                (7, "dc3b6485f9d94935329442916b0d059685ba815a1fa2a14107217453a7fc9f0e"),
                (8, "2b166978cef14d9d438046c720519d8b1cad707e199746f1562d0c87fbd32940"),
                (63, "b6451e30b953c206e34644c6803724e9d2725e0893039cfc49584f991f451af3"),
                (64, "a5c4a7053fa86b64746d4bb688d06ad1f02a18fce9afd3e818fefaa7126bf73e"),
                (65, "51fd05c3c1cfbc8ed67d139ad76f5cf8236cd2acd26627a30c104dfd9d3ff8a8"),
                (127, "c91c090ceee3a3ac81902da31838012625bbcd73fcb92e7d7e56f78deba4f0c3"),
                (128, "81720f34452f58a0120a58b6b4608384b5c51d11f39ce97161a0c0e442ca0225"),
                (129, "938d2d4435be30eafdbb2b7031f7857c98b04881227391dc40db3c7b21f41fc1"),
                (1023, "74a16c1c3d44368a86e1ca6df64be6a2f64cce8f09220787450722d85725dea5"),
                (1024, "7356cd7720d5b66b6d0697eb3177d9f8d73a4a5c5e968896eb6a689684302706"),
                (1025, "effaa245f065fbf82ac186839a249707c3bddf6d3fdda22d1b95a3c970379bcb"),
                (2048, "7b2945cb4fef70885cc5d78a87bf6f6207dd901ff239201351ffac04e1088a23"),
                (2049, "2ea477c5515cc3dd606512ee72bb3e0e758cfae7232826f35fb98ca1bcbdf273"),
                (3072, "050df97f8c2ead654d9bb3ab8c9178edcd902a32f8495949feadcc1e0480c46b"),
                (3073, "72613c9ec9ff7e40f8f5c173784c532ad852e827dba2bf85b2ab4b76f7079081"),
                (4096, "1e0d7f3db8c414c97c6307cbda6cd27ac3b030949da8e23be1a1a924ad2f25b9"),
                (4097, "aca51029626b55fda7117b42a7c211f8c6e9ba4fe5b7a8ca922f34299500ead8"),
                (5120, "7a7acac8a02adcf3038d74cdd1d34527de8a0fcc0ee3399d1262397ce5817f60"),
                (5121, "b07f01e518e702f7ccb44a267e9e112d403a7b3f4883a47ffbed4b48339b3c34"),
                (6144, "2a95beae63ddce523762355cf4b9c1d8f131465780a391286a5d01abb5683a15"),
                (6145, "379bcc61d0051dd489f686c13de00d5b14c505245103dc040d9e4dd1facab8e5"),
                (7168, "11c37a112765370c94a51415d0d651190c288566e295d505defdad895dae2237"),
                (7169, "554b0a5efea9ef183f2f9b931b7497995d9eb26f5c5c6dad2b97d62fc5ac31d9"),
                (8192, "ad01d7ae4ad059b0d33baa3c01319dcf8088094d0359e5fd45d6aeaa8b2d0c3d"),
                (8193, "af1e0346e389b17c23200270a64aa4e1ead98c61695d917de7d5b00491c9b0f1"),
                (16384, "160e18b5878cd0df1c3af85eb25a0db5344d43a6fbd7a8ef4ed98d0714c3f7e1"),
                (31744, "39772aef80e0ebe60596361e45b061e8f417429d529171b6764468c22928e28e"),
                (102400, "4652cff7a3f385a6103b5c260fc1593e13c778dbe608efb092fe7ee69df6e9c6")
            };

            foreach ((int length, string expected) in vectors)
            {
                yield return new TestCaseData(length, expected).SetName($"DeriveKey_{length}");
            }
        }
    }

    /// <summary>
    /// Official derive-key vectors at their full 131-byte extended-output length.
    /// </summary>
    public static System.Collections.IEnumerable OfficialDeriveKeyXofVectors
    {
        get
        {
            var vectors = new (int length, string expected)[]
            {
                (0, "2cc39783c223154fea8dfb7c1b1660f2ac2dcbd1c1de8277b0b0dd39b7e50d7d905630c8be290dfcf3e6842f13bddd573c098c3f17361f1f206b8cad9d088aa4a3f746752c6b0ce6a83b0da81d59649257cdf8eb3e9f7d4998e41021fac119deefb896224ac99f860011f73609e6e0e4540f93b273e56547dfd3aa1a035ba6689d89a0"),
                (1, "b3e2e340a117a499c6cf2398a19ee0d29cca2bb7404c73063382693bf66cb06c5827b91bf889b6b97c5477f535361caefca0b5d8c4746441c57617111933158950670f9aa8a05d791daae10ac683cbef8faf897c84e6114a59d2173c3f417023a35d6983f2c7dfa57e7fc559ad751dbfb9ffab39c2ef8c4aafebc9ae973a64f0c76551"),
                (1024, "7356cd7720d5b66b6d0697eb3177d9f8d73a4a5c5e968896eb6a6896843027066c23b601d3ddfb391e90d5c8eccdef4ae2a264bce9e612ba15e2bc9d654af1481b2e75dbabe615974f1070bba84d56853265a34330b4766f8e75edd1f4a1650476c10802f22b64bd3919d246ba20a17558bc51c199efdec67e80a227251808d8ce5bad"),
                (8192, "ad01d7ae4ad059b0d33baa3c01319dcf8088094d0359e5fd45d6aeaa8b2d0c3d4c9e58958553513b67f84f8eac653aeeb02ae1d5672dcecf91cd9985a0e67f4501910ecba25555395427ccc7241d70dc21c190e2aadee875e5aae6bf1912837e53411dabf7a56cbf8e4fb780432b0d7fe6cec45024a0788cf5874616407757e9e6bef7")
            };

            foreach ((int length, string expected) in vectors)
            {
                yield return new TestCaseData(length, expected).SetName($"DeriveKeyXof_{length}");
            }
        }
    }

    /// <summary>
    /// Verifies derive-key output against the official vectors at the default output size.
    /// </summary>
    /// <param name="inputLength">The key-material length.</param>
    /// <param name="expectedHex">The expected derived key in hexadecimal.</param>
    [TestCaseSource(nameof(OfficialDeriveKeyVectors))]
    public void OfficialVectors(int inputLength, string expectedHex)
    {
        byte[] keyMaterial = GenerateTestInput(inputLength);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var blake3 = Blake3.CreateDeriveKey(OfficialContext);
        byte[] derived = blake3.ComputeHash(keyMaterial);

        Assert.That(derived, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies derive-key output at the vectors' full extended-output length, exercising the
    /// XOF squeeze rather than the single-block finalize.
    /// </summary>
    /// <param name="inputLength">The key-material length.</param>
    /// <param name="expectedHex">The expected derived key in hexadecimal.</param>
    [TestCaseSource(nameof(OfficialDeriveKeyXofVectors))]
    public void OfficialVectorsExtendedOutput(int inputLength, string expectedHex)
    {
        byte[] keyMaterial = GenerateTestInput(inputLength);
        byte[] expected = TestHelpers.FromHexString(expectedHex);

        using var blake3 = Blake3.CreateDeriveKey(OfficialContext, expected.Length);
        byte[] derived = blake3.ComputeHash(keyMaterial);

        Assert.That(derived, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies that the UTF-8 span overload agrees with the string overload.
    /// </summary>
    [Test]
    public void Utf8ContextMatchesStringContext()
    {
        byte[] keyMaterial = GenerateTestInput(128);

        using var fromString = Blake3.CreateDeriveKey(OfficialContext);
        using var fromUtf8 = Blake3.CreateDeriveKey(Encoding.UTF8.GetBytes(OfficialContext));

        Assert.That(fromUtf8.ComputeHash(keyMaterial), Is.EqualTo(fromString.ComputeHash(keyMaterial)));
    }

    /// <summary>
    /// Verifies that a non-ASCII context is encoded as UTF-8 rather than truncated.
    /// </summary>
    [Test]
    public void NonAsciiContextIsUtf8Encoded()
    {
        const string context = "CryptoHives \u2603 derive-key test";
        byte[] keyMaterial = GenerateTestInput(64);

        using var fromString = Blake3.CreateDeriveKey(context);
        using var fromUtf8 = Blake3.CreateDeriveKey(Encoding.UTF8.GetBytes(context));

        Assert.That(fromUtf8.ComputeHash(keyMaterial), Is.EqualTo(fromString.ComputeHash(keyMaterial)));
    }

    /// <summary>
    /// Verifies that the context string is genuine domain separation: the same key material
    /// under two different contexts must not collide.
    /// </summary>
    [Test]
    public void DifferentContextsDeriveDifferentKeys()
    {
        byte[] keyMaterial = GenerateTestInput(64);

        using var first = Blake3.CreateDeriveKey("CryptoHives 2026-01-01 context one");
        using var second = Blake3.CreateDeriveKey("CryptoHives 2026-01-01 context two");

        Assert.That(second.ComputeHash(keyMaterial), Is.Not.EqualTo(first.ComputeHash(keyMaterial)));
    }

    /// <summary>
    /// Verifies that derive-key output differs from plain and keyed hashing of the same input,
    /// i.e. that the domain-separation flags actually reach the compression function.
    /// </summary>
    [Test]
    public void DeriveKeyDiffersFromHashAndKeyedHash()
    {
        byte[] keyMaterial = GenerateTestInput(64);
        byte[] key = new byte[Blake3.KeySizeBytes];

        using var plain = Blake3.Create();
        using var keyed = Blake3.CreateKeyed(key);
        using var derive = Blake3.CreateDeriveKey(OfficialContext);

        byte[] derived = derive.ComputeHash(keyMaterial);

        Assert.Multiple(() => {
            Assert.That(derived, Is.Not.EqualTo(plain.ComputeHash(keyMaterial)));
            Assert.That(derived, Is.Not.EqualTo(keyed.ComputeHash(keyMaterial)));
        });
    }

    /// <summary>
    /// Verifies the mode and algorithm name a derive-key instance reports.
    /// </summary>
    [Test]
    public void ModeAndAlgorithmNameAreReported()
    {
        using var blake3 = Blake3.CreateDeriveKey(OfficialContext);

        Assert.Multiple(() => {
            Assert.That(blake3.Mode, Is.EqualTo(Blake3Mode.DeriveKey));
            Assert.That(blake3.AlgorithmName, Is.EqualTo("BLAKE3-DeriveKey"));
        });
    }

    /// <summary>
    /// Verifies that a derive-key instance survives reuse. The context key lives in the same
    /// state slot as a caller-supplied key, so an Initialize() that treated derive-key as
    /// unkeyed would overwrite it with the IV and silently change every subsequent result.
    /// </summary>
    [Test]
    public void ReusingInstanceReproducesTheSameDerivedKey()
    {
        byte[] keyMaterial = GenerateTestInput(128);

        using var blake3 = Blake3.CreateDeriveKey(OfficialContext);
        byte[] first = blake3.ComputeHash(keyMaterial);
        byte[] second = blake3.ComputeHash(keyMaterial);

        using var fresh = Blake3.CreateDeriveKey(OfficialContext);

        Assert.Multiple(() => {
            Assert.That(second, Is.EqualTo(first));
            Assert.That(first, Is.EqualTo(fresh.ComputeHash(keyMaterial)));
        });
    }

    /// <summary>
    /// Verifies that a derive-key instance refuses to be pooled, the same way a keyed instance
    /// does -- its state carries derived key material.
    /// </summary>
    [Test]
    public void TryResetRefusesDeriveKeyInstance()
    {
        using var blake3 = Blake3.CreateDeriveKey(OfficialContext);

        Assert.That(blake3.TryReset(), Is.False);
    }

    /// <summary>
    /// Verifies that streaming the key material in pieces matches hashing it in one call.
    /// </summary>
    [Test]
    public void StreamingMatchesOneShot()
    {
        byte[] keyMaterial = GenerateTestInput(8193);

        using var oneShot = Blake3.CreateDeriveKey(OfficialContext);
        byte[] expected = oneShot.ComputeHash(keyMaterial);

        using var streaming = Blake3.CreateDeriveKey(OfficialContext);
        streaming.Absorb(keyMaterial.AsSpan(0, 1000));
        streaming.Absorb(keyMaterial.AsSpan(1000, 7000));
        streaming.Absorb(keyMaterial.AsSpan(8000));

        byte[] actual = new byte[expected.Length];
        streaming.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies that an empty or null context is rejected.
    /// </summary>
    [Test]
    public void InvalidContextThrows()
    {
        Assert.Multiple(() => {
            Assert.Throws<ArgumentNullException>(() => Blake3.CreateDeriveKey((string)null!));
            Assert.Throws<ArgumentException>(() => Blake3.CreateDeriveKey(string.Empty));
            Assert.Throws<ArgumentException>(() => Blake3.CreateDeriveKey(ReadOnlySpan<byte>.Empty));
        });
    }

    /// <summary>
    /// Verifies that an invalid output size is rejected.
    /// </summary>
    [Test]
    public void InvalidOutputSizeThrows()
    {
        Assert.Multiple(() => {
            Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.CreateDeriveKey(OfficialContext, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => Blake3.CreateDeriveKey(OfficialContext, -1));
        });
    }

    /// <summary>
    /// Cross-validates the AVX2 derive-key path against the scalar one. Both derive-key passes
    /// run through the same SIMD kernels as plain hashing, so a kernel that dropped or
    /// mistyped the flag word would diverge here while plain hashing stayed correct.
    /// </summary>
    /// <param name="inputLength">The key-material length.</param>
    [TestCase(0)]
    [TestCase(1024)]
    [TestCase(8192)]
    [TestCase(8193)]
    [TestCase(16384)]
    [TestCase(31744)]
    public void Avx2MatchesScalar(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx2) == 0)
        {
            Assert.Ignore("AVX2 is not supported on this platform.");
        }

        AssertTierMatchesScalar(CH.SimdSupport.Avx2, inputLength);
    }

    /// <summary>
    /// Cross-validates the AVX-512 derive-key path against the scalar one.
    /// </summary>
    /// <param name="inputLength">The key-material length.</param>
    [TestCase(0)]
    [TestCase(1024)]
    [TestCase(8192)]
    [TestCase(8193)]
    [TestCase(16384)]
    [TestCase(31744)]
    public void Avx512MatchesScalar(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Avx512F) == 0)
        {
            Assert.Ignore("AVX-512 is not supported on this platform.");
        }

        AssertTierMatchesScalar(CH.SimdSupport.Avx512F | CH.SimdSupport.Avx2, inputLength);
    }

    /// <summary>
    /// Cross-validates the NEON derive-key path against the scalar one.
    /// </summary>
    /// <param name="inputLength">The key-material length.</param>
    [TestCase(0)]
    [TestCase(1024)]
    [TestCase(8192)]
    [TestCase(8193)]
    [TestCase(16384)]
    [TestCase(31744)]
    public void NeonMatchesScalar(int inputLength)
    {
        if ((Blake3.SimdSupport & CH.SimdSupport.Neon) == 0)
        {
            Assert.Ignore("NEON is not supported on this platform.");
        }

        AssertTierMatchesScalar(CH.SimdSupport.Neon, inputLength);
    }

    /// <summary>
    /// Asserts that one SIMD tier derives the same key as the scalar path.
    /// </summary>
    /// <param name="simdSupport">The tier to compare against scalar.</param>
    /// <param name="inputLength">The key-material length.</param>
    private static void AssertTierMatchesScalar(CH.SimdSupport simdSupport, int inputLength)
    {
        byte[] keyMaterial = GenerateTestInput(inputLength);
        byte[] contextUtf8 = Encoding.UTF8.GetBytes(OfficialContext);

        using var scalar = Blake3.CreateDeriveKey(CH.SimdSupport.None, contextUtf8, 32);
        using var tier = Blake3.CreateDeriveKey(simdSupport, contextUtf8, 32);

        Assert.That(tier.ComputeHash(keyMaterial), Is.EqualTo(scalar.ComputeHash(keyMaterial)));
    }
}
