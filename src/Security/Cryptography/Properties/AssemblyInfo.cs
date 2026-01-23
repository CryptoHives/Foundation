// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

using System;
using System.Runtime.CompilerServices;

[assembly: CLSCompliant(false)]

#if SIGNASSEMBLY
[assembly: InternalsVisibleTo("Cryptography.Tests, PublicKey = " +
    // Strong Name Public Key
    "002400000480000094000000060200000024000052534131000400000100010079ff8565b99f24" +
    "7c1b8461da6d8abfd37f7a34babee05d2144d3621e239dd97c51784549a7a1e5016a5a32a80cba" +
    "cecfe588452577ce462c92cd1ed7cb6641e0e376d18a5a36b876b73b2a5e57fdae91a08ca5e14c" +
    "10beb5f15fb09bf55c26d26d6dd6f315e247a6c228cacf73973cee4e6756be163f939752753bc1" +
    "cd6047dc")]
#else
[assembly: InternalsVisibleTo("Cryptography.Tests")]
#endif
