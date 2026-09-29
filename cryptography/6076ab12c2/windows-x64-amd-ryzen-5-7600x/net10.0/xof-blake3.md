| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.659 μs | 0.0007 μs | 0.0006 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.667 μs | 0.0007 μs | 0.0006 μs |  13,109 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.678 μs | 0.0006 μs | 0.0005 μs |  13,111 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.752 μs | 0.0006 μs | 0.0005 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.934 μs | 0.0015 μs | 0.0013 μs |  18,444 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.396 μs | 0.0015 μs | 0.0014 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.847 μs | 0.0030 μs | 0.0028 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    22.918 μs | 0.0239 μs | 0.0212 μs |  28,670 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     1.723 μs | 0.0007 μs | 0.0006 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     1.751 μs | 0.0011 μs | 0.0010 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.981 μs | 0.0023 μs | 0.0021 μs |  18,598 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.263 μs | 0.0015 μs | 0.0014 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.381 μs | 0.0005 μs | 0.0005 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.091 μs | 0.0014 μs | 0.0012 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     4.055 μs | 0.0069 μs | 0.0065 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    33.968 μs | 0.0725 μs | 0.0643 μs |  28,873 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     2.677 μs | 0.0015 μs | 0.0014 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     2.821 μs | 0.0013 μs | 0.0013 μs |  18,224 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.146 μs | 0.0019 μs | 0.0015 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.094 μs | 0.0041 μs | 0.0038 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     7.386 μs | 0.0023 μs | 0.0022 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     8.555 μs | 0.0059 μs | 0.0055 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    13.731 μs | 0.0135 μs | 0.0119 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   117.351 μs | 0.1325 μs | 0.1174 μs |  28,638 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    17.674 μs | 0.0058 μs | 0.0051 μs |  18,576 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    19.164 μs | 0.0225 μs | 0.0210 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.821 μs | 0.0238 μs | 0.0223 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    89.921 μs | 0.0237 μs | 0.0210 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    93.154 μs | 0.0470 μs | 0.0417 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   102.582 μs | 0.0362 μs | 0.0339 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   179.021 μs | 0.2404 μs | 0.2007 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,583.984 μs | 1.4465 μs | 1.2823 μs |  28,642 B |      56 B |