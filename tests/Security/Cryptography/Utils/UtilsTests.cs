// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Cryptography.Tests.Utils;

using NUnit.Framework;
using System.Security.Cryptography;

/// <summary>
/// Tests for misc. functions.
/// </summary>
[TestFixture, Category("Utils")]
[SetCulture("en-us"), SetUICulture("en-us")]
[Parallelizable]
public class UtilsTests
{
    [Test]
    public void UtilsTest()
    {
        using var sha256 = SHA256.Create();
    }
}
