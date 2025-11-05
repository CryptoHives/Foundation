// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using System;
using System.Runtime.CompilerServices;

[assembly: CLSCompliant(false)]

#if SIGNASSEMBLY
[assembly: InternalsVisibleTo("CryptoHives.Memory.Tests, PublicKey = " +
    // Strong Name Public Key
    "0024000004800000940000000602000000240000525341310004000001000100d987b12f068b35" +
    "80429f3dde01397508880fc7e62621397618456ca1549aeacfbdb90c62adfe918f05ce3677b390" +
    "f78357b8745cb6e1334655afce1a9527ac92fc829ff585ea79f007e52ba0f83ead627e3edda40b" +
    "ec5ae574128fc9342cb57cb8285aa4e5b589c0ebef3be571b5c8f2ab1067f7c880e8f8882a73c8" +
    "0a12a1ef")]
#else
[assembly: InternalsVisibleTo("CryptoHives.Memory.Tests")]
#endif
