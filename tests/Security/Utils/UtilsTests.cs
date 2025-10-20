// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Tests.UtilsTests;

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
